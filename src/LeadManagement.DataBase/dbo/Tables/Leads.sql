CREATE TABLE [dbo].[Leads] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (100)  NOT NULL,
    [LastName]    NVARCHAR (100)  NOT NULL,
    [Status]      INT             NOT NULL,
    [DateCreated] DATETIME        DEFAULT (getdate()) NOT NULL,
    [Suburb]      NVARCHAR (100)  NULL,
    [Category]    NVARCHAR (100)  NULL,
    [Description] NVARCHAR (500)  NULL,
    [Price]       DECIMAL (18, 2) NULL,
    [Email]       NVARCHAR (150)  NULL,
    [PhoneNumber] NVARCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

