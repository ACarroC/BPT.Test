CREATE TABLE [dbo].[AssigmentStudents] (
    [StudentId]   INT NOT NULL,
    [AssigmentId] INT NOT NULL,
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_AssigmentStudents] PRIMARY KEY CLUSTERED ([StudentId] ASC, [AssigmentId] ASC),
    CONSTRAINT [FK_AssigmentStudents_AssigmentsTbl_AssigmentId] FOREIGN KEY ([AssigmentId]) REFERENCES [dbo].[AssigmentsTbl] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AssigmentStudents_StudentsTbl_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[StudentsTbl] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AssigmentStudents_AssigmentId]
    ON [dbo].[AssigmentStudents]([AssigmentId] ASC);

