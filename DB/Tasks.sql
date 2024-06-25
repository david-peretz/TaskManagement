CREATE TABLE [dbo].[Tasks] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [Subject]     NVARCHAR (250) NOT NULL,
    [TargetDate]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [IsCompleted] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tasks_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

