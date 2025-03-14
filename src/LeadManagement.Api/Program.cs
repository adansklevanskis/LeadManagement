using LeadManagement.Api.Application.Behavior;
using LeadManagement.Api.Application.Queries;
using LeadManagement.Api.Application.Services;
using LeadManagement.Api.Extensions;
using LeadManagement.Domain.Repositories;
using LeadManagement.Infrastructure.EventStore;
using LeadManagement.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR((c) => {
    c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    c.AddOpenBehavior(typeof(LoggingBehavior<,>));
    c.AddOpenBehavior(typeof(TransactionBehavior<,>));


});

builder.Services.AddCors(opt=> {
    opt.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

});

builder.Services.AddScoped<IEmailService>(provider => new FileEmailService("Logs/EmailLog.txt"));

builder.Services.ConfigureEntityFramework(builder.Configuration);
builder.Services.AddScoped<ILeadRepository, LeadRepository>();

builder.Services.AddScoped<ILeadQuery, LeadQuery>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IEventStore, DatabaseEventStore>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
