IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Citas] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Citas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Pacientes] (
    [Id] int NOT NULL IDENTITY,
    [Active] bit NOT NULL,
    [Date] datetime2 NOT NULL,
    [PatientId] nvarchar(450) NULL,
    [Prueba] nvarchar(max) NULL,
    CONSTRAINT [PK_Pacientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pacientes_Citas_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Citas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Pacientes_PatientId] ON [Pacientes] ([PatientId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200424212026_AppointmentMigration', N'3.1.3');

GO

