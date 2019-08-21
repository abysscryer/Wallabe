CREATE TABLE [Cranes] (
    [Id] char(36) NOT NULL,
    [Name] nvarchar(32) NOT NULL,
    [Status] int NOT NULL,
    [ImagePath] varchar(256) NULL,
    CONSTRAINT [PK_Cranes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Players] (
    [Id] char(36) NOT NULL,
    [Name] nvarchar(32) NOT NULL,
    [ImagePath] varchar(256) NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Dolls] (
    [Id] char(36) NOT NULL,
    [Name] nvarchar(32) NOT NULL,
    [Quantity] int NOT NULL,
    [ImagePath] varchar(256) NULL,
    [OnCreated] datetime2 NOT NULL,
    [CraneId] char(36) NULL,
    CONSTRAINT [PK_Dolls] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dolls_Cranes_CraneId] FOREIGN KEY ([CraneId]) REFERENCES [Cranes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [CraneRecords] (
    [Date] char(8) NOT NULL,
    [CraneId] char(36) NOT NULL,
    [PlayerId] char(36) NOT NULL,
    [Rank] int NOT NULL,
    [Shift] int NOT NULL,
    [Try] int NOT NULL,
    [Hit] int NOT NULL,
    [Rate] real NOT NULL,
    CONSTRAINT [PK_CraneRecords] PRIMARY KEY ([Date], [CraneId], [PlayerId]),
    CONSTRAINT [FK_CraneRecords_Cranes_CraneId] FOREIGN KEY ([CraneId]) REFERENCES [Cranes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CraneRecords_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Games] (
    [Id] char(36) NOT NULL,
    [PlayerId] char(36) NOT NULL,
    [CraneId] char(36) NOT NULL,
    [Status] int NOT NULL,
    [State] bit NOT NULL,
    [OnCreated] datetime2 NOT NULL DEFAULT (getdate()),
    [OnUpdated] datetime2 NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Games_Players_CraneId] FOREIGN KEY ([CraneId]) REFERENCES [Players] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Games_Cranes_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Cranes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Records] (
    [Date] char(8) NOT NULL,
    [PlayerId] char(36) NOT NULL,
    [Rank] int NOT NULL,
    [Shift] int NOT NULL,
    [Try] int NOT NULL,
    [Hit] int NOT NULL,
    [Rate] real NOT NULL,
    CONSTRAINT [PK_Records] PRIMARY KEY ([Date], [PlayerId]),
    CONSTRAINT [FK_Records_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Plays] (
    [Id] char(36) NOT NULL,
    [GameId] char(36) NOT NULL,
    [Status] int NOT NULL,
    [State] int NOT NULL,
    [OnCreated] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Plays] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plays_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_CraneRecords_CraneId] ON [CraneRecords] ([CraneId]);

GO

CREATE INDEX [IX_CraneRecords_PlayerId] ON [CraneRecords] ([PlayerId]);

GO

CREATE INDEX [IX_Dolls_CraneId] ON [Dolls] ([CraneId]);

GO

CREATE INDEX [IX_Games_CraneId] ON [Games] ([CraneId]);

GO

CREATE INDEX [IX_Games_PlayerId] ON [Games] ([PlayerId]);

GO

CREATE INDEX [IX_Plays_GameId] ON [Plays] ([GameId]);

GO

CREATE INDEX [IX_Records_PlayerId] ON [Records] ([PlayerId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190821093359_InitialCreate', N'2.1.11-servicing-32099');

GO

