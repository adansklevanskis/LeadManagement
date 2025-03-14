CREATE TABLE [dbo].[StoredEvents] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [AggregateId] INT            NOT NULL,
    [EventType]   NVARCHAR (500) NOT NULL,
    [Data]        NVARCHAR (MAX) NOT NULL,
    [OccurredOn]  DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

