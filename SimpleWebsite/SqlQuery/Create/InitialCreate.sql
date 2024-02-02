USE SimpleWebsiteLedgerDb;
GO

--WITH (LEDGER = ON (APPEND_ONLY = ON));  --AppendOnly Ledger Database

--WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = [Table].[TableHistory]), LEDGER = ON);  --Updatable Ledger Database

CREATE TABLE [dbo].[Posts] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
)
WITH 
(
  SYSTEM_VERSIONING = ON,
  LEDGER = ON
);
GO


CREATE TABLE [dbo].[Tags] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
)
WITH 
(
  SYSTEM_VERSIONING = ON,
  LEDGER = ON
);
GO


CREATE TABLE [dbo].[PostTags] (
    [PostId] int NOT NULL,
    [TagId] int NOT NULL,
    CONSTRAINT [PK_PostTags] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_PostTags_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
)
WITH 
(
  SYSTEM_VERSIONING = ON,
  LEDGER = ON
);
GO


CREATE INDEX [IX_PostTags_TagId] ON [PostTags] ([TagId]);
GO
