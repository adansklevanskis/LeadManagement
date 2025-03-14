using LeadManagement.Domain.SeedWork;
using LeadManagement.Infrastructure;
using LeadManagement.Infrastructure.EventStore;
using MediatR;

namespace LeadManagement.Api.Application.Behavior;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest
{
    private readonly LeadContext _context;
    private readonly IEventStore _eventStore;

    public TransactionBehavior(LeadContext context, IEventStore eventStore)
    {
        _context = context;
        _eventStore = eventStore;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // If there is already an active transaction, just continue.
        if (_context.Database.CurrentTransaction != null)
        {
            return await next();
        }

        TResponse response;
        // Begin a new transaction.
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            // Execute the handler.
            response = await next();

            // Flush all aggregate changes.
            await _context.SaveChangesAsync(cancellationToken);

            // Retrieve aggregates that have pending domain events.
            var entitiesWithEvents = _context.ChangeTracker.Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();

            // For each aggregate, persist its events using the IEventStore.
            foreach (var entity in entitiesWithEvents)
            {
                if (entity.DomainEvents.Any())
                {
                    await _eventStore.SaveEventsAsync(entity.Id, entity.DomainEvents);
                    entity.ClearDomainEvents();
                }
            }

            // Persist stored events; optionally flush them if your IEventStore implementation relies on context changes.
            await _context.SaveChangesAsync(cancellationToken);

            // Commit the transaction.
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            // Roll back if any error occurs.
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

        return response;
    }
}