﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Slug] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tag] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Slug] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [Bio] nvarchar(max) NOT NULL,
    [GitHub] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Summary] nvarchar(max) NOT NULL,
    [Body] nvarchar(max) NOT NULL,
    [Slug] nvarchar(450) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [LastUpdateDate] SMALLDATETIME NOT NULL DEFAULT (GETDATE()),
    [CategoryId] int NOT NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY ([AuthorId]) REFERENCES [User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PostTag] (
    [PostsId] int NOT NULL,
    [TagsId] int NOT NULL,
    [PostId] int NULL,
    [RoleId] int NULL,
    [TagId] int NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostsId], [TagsId]),
    CONSTRAINT [FK_PostTag_PostId] FOREIGN KEY ([PostId]) REFERENCES [Tag] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTag_TagId] FOREIGN KEY ([TagId]) REFERENCES [Post] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Category_Slug] ON [Category] ([Slug]);
GO

CREATE UNIQUE INDEX [IX_Category_Slug] ON [Post] ([Slug]);
GO

CREATE INDEX [IX_Post_AuthorId] ON [Post] ([AuthorId]);
GO

CREATE INDEX [IX_Post_CategoryId] ON [Post] ([CategoryId]);
GO

CREATE INDEX [IX_PostTag_PostId] ON [PostTag] ([PostId]);
GO

CREATE INDEX [IX_PostTag_RoleId] ON [PostTag] ([RoleId]);
GO

CREATE INDEX [IX_PostTag_TagId] ON [PostTag] ([TagId]);
GO

CREATE INDEX [IX_PostTag_UserId] ON [PostTag] ([UserId]);
GO

CREATE UNIQUE INDEX [IX_User_Slug] ON [User] ([Slug]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404201127_InitialCreation', N'7.0.4');
GO

COMMIT;
GO

