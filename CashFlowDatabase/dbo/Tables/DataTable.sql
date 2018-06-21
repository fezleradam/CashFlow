CREATE TABLE [dbo].[DataTable] (
    [Id]                INT           NOT NULL IDENTITY,
    [TransactionTypeId] INT           NOT NULL,
    [UserId]            INT           NOT NULL,
    [Date]              DATETIME      NOT NULL,
    [Description]       NVARCHAR (30) NOT NULL,
    [Value]             DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_DataTable] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DataTable_TransactionType] FOREIGN KEY ([TransactionTypeId]) REFERENCES [dbo].[TransactionType] ([Id]),
    CONSTRAINT [FK_DataTable_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



