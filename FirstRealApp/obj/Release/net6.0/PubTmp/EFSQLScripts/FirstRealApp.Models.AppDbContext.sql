IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [Images] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Url] nvarchar(max) NULL,
        [PedigreeUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Images] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [PoodleColors] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_PoodleColors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [PoodleSizes] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_PoodleSizes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE TABLE [Poodles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [GeneticTests] bit NOT NULL,
        [PedigreeNumber] nvarchar(11) NULL,
        [PoodleSizeId] int NULL,
        [PoodleColorId] int NULL,
        [ImageId] int NULL,
        CONSTRAINT [PK_Poodles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Poodles_Images_ImageId] FOREIGN KEY ([ImageId]) REFERENCES [Images] ([Id]),
        CONSTRAINT [FK_Poodles_PoodleColors_PoodleColorId] FOREIGN KEY ([PoodleColorId]) REFERENCES [PoodleColors] ([Id]),
        CONSTRAINT [FK_Poodles_PoodleSizes_PoodleSizeId] FOREIGN KEY ([PoodleSizeId]) REFERENCES [PoodleSizes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[PoodleColors]'))
        SET IDENTITY_INSERT [PoodleColors] ON;
    EXEC(N'INSERT INTO [PoodleColors] ([Id], [Name])
    VALUES (1, N''Black''),
    (2, N''White''),
    (3, N''Brown''),
    (4, N''Gray''),
    (5, N''Apricot''),
    (6, N''Red''),
    (7, N''Black and tan'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[PoodleColors]'))
        SET IDENTITY_INSERT [PoodleColors] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[PoodleSizes]'))
        SET IDENTITY_INSERT [PoodleSizes] ON;
    EXEC(N'INSERT INTO [PoodleSizes] ([Id], [Name])
    VALUES (1, N''Toy''),
    (2, N''Miniature''),
    (3, N''Medium''),
    (4, N''Standard'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[PoodleSizes]'))
        SET IDENTITY_INSERT [PoodleSizes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_Poodles_ImageId] ON [Poodles] ([ImageId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_Poodles_PoodleColorId] ON [Poodles] ([PoodleColorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    CREATE INDEX [IX_Poodles_PoodleSizeId] ON [Poodles] ([PoodleSizeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913114856_new db')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220913114856_new db', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913131839_test2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220913131839_test2', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913132358_pedigree upd')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PedigreeUrl', N'Url') AND [object_id] = OBJECT_ID(N'[Images]'))
        SET IDENTITY_INSERT [Images] ON;
    EXEC(N'INSERT INTO [Images] ([Id], [Name], [PedigreeUrl], [Url])
    VALUES (1, N''Don'', N''https://i.imgur.com/buICnwV.png'', N''https://i.imgur.com/xOseBFm.jpeg''),
    (2, N''Ruza'', N''https://i.imgur.com/5wGPffP.png'', N''https://i.imgur.com/6Ll5PQL.jpeg''),
    (3, N''Luna'', N''https://i.imgur.com/1HvFBCZ.png'', N''https://i.imgur.com/QnE8Brd.jpeg''),
    (4, N''Sosa'', N''https://i.imgur.com/FFnFmyy.png'', N''https://i.imgur.com/nuBvd3X.jpeg''),
    (5, N''Dolly'', N''https://i.imgur.com/YHBaAPu.png'', N''https://i.imgur.com/t2q0Put.jpeg''),
    (6, N''Cici'', N''https://i.imgur.com/P5ZegtI.png'', N''https://i.imgur.com/dWBkNFR.jpeg'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'PedigreeUrl', N'Url') AND [object_id] = OBJECT_ID(N'[Images]'))
        SET IDENTITY_INSERT [Images] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913132358_pedigree upd')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfBirth', N'GeneticTests', N'ImageId', N'Name', N'PedigreeNumber', N'PoodleColorId', N'PoodleSizeId') AND [object_id] = OBJECT_ID(N'[Poodles]'))
        SET IDENTITY_INSERT [Poodles] ON;
    EXEC(N'INSERT INTO [Poodles] ([Id], [DateOfBirth], [GeneticTests], [ImageId], [Name], [PedigreeNumber], [PoodleColorId], [PoodleSizeId])
    VALUES (1, ''2020-02-01T00:00:00.0000000'', CAST(1 AS bit), 1, N''Toy Love Story Don Juan'', N''JR 70883'', 6, 2),
    (2, ''2020-11-03T00:00:00.0000000'', CAST(1 AS bit), 2, N''Scarlet Rain  Von Apalusso'', N''JR 70883'', 6, 1),
    (3, ''2017-05-13T00:00:00.0000000'', CAST(1 AS bit), 3, N''Loko Loko Crveni Mayestoso'', N''JR 70883'', 7, 1),
    (4, ''2020-11-03T00:00:00.0000000'', CAST(1 AS bit), 4, N''Skyler Von Apalusso'', N''JR 70883'', 6, 2),
    (5, ''2018-11-04T00:00:00.0000000'', CAST(1 AS bit), 5, N''Greta Garbo Von Apalusso'', N''JR 70883'', 5, 2),
    (6, ''2020-11-14T00:00:00.0000000'', CAST(1 AS bit), 6, N''Cici'', N''JR 81231'', 5, 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfBirth', N'GeneticTests', N'ImageId', N'Name', N'PedigreeNumber', N'PoodleColorId', N'PoodleSizeId') AND [object_id] = OBJECT_ID(N'[Poodles]'))
        SET IDENTITY_INSERT [Poodles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913132358_pedigree upd')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220913132358_pedigree upd', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Poodles]') AND [c].[name] = N'PedigreeNumber');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Poodles] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Poodles] ALTER COLUMN [PedigreeNumber] nvarchar(13) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    ALTER TABLE [Poodles] ADD [Sex] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    EXEC(N'UPDATE [Poodles] SET [PedigreeNumber] = N''JR 70310tp'', [Sex] = N''Male''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    EXEC(N'UPDATE [Poodles] SET [PedigreeNumber] = N''JR 78838'', [Sex] = N''Female''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    EXEC(N'UPDATE [Poodles] SET [PedigreeNumber] = N''JR 70296tp'', [Sex] = N''Female''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    EXEC(N'UPDATE [Poodles] SET [PedigreeNumber] = N''JR 78837'', [Sex] = N''Female''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    EXEC(N'UPDATE [Poodles] SET [PedigreeNumber] = N''JR 82652'', [Sex] = N''Female''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    EXEC(N'UPDATE [Poodles] SET [PedigreeNumber] = N''JR 78844'', [Sex] = N''Female''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220920182538_testing property addition')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220920182538_testing property addition', N'6.0.5');
END;
GO

COMMIT;
GO

