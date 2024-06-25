CREATE TABLE [dbo].[Users] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

