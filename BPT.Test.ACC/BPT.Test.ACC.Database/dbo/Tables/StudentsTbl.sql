CREATE TABLE [dbo].[StudentsTbl] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [DateOfBirth] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_StudentsTbl] PRIMARY KEY CLUSTERED ([Id] ASC)
);

