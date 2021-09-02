CREATE TABLE [dbo].[AssigmentsTbl] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_AssigmentsTbl] PRIMARY KEY CLUSTERED ([Id] ASC)
);

