CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Email]    NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [AK_User] UNIQUE ([Email])
);

