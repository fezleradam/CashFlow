﻿CREATE TABLE [dbo].[TransactionType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_TransferName] PRIMARY KEY CLUSTERED ([Id] ASC)
);

