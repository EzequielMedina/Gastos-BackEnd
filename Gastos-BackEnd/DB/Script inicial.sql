--USE master

--GO

CREATE DATABASE GastosDB

GO

USE GastosDB

GO
-- Tablas

CREATE TABLE [Persona] (
    [Personald] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Nombre] VARCHAR(50) NOT NULL,
    [Apellido] VARCHAR(50) NOT NULL
);

CREATE TABLE [Tarjeta] (
    [TarjetaId] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Nombre] VARCHAR(50) NOT NULL,
);

CREATE TABLE [Categoria] (
    [Categoriald] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Nombre] VARCHAR(50) NOT NULL
);

CREATE TABLE [Periodo] (
    [Periodold] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Fecha] DATE NOT NULL,
    [Monto] DECIMAL(18, 2) NOT NULL,
    [TarjetaId] UNIQUEIDENTIFIER NOT NULL
        
    FOREIGN KEY ([TarjetaId]) REFERENCES [Tarjeta]([TarjetaId])
);

CREATE TABLE [TipoGasto] (
    [TipoGastold] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Nombre] VARCHAR(50) NOT NULL
);

CREATE TABLE [Gasto] (
    [GastoId] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Monto] DECIMAL(18, 2) NOT NULL,
    [Fecha] DATE NOT NULL,
    [NombreGasto] VARCHAR(50) NOT NULL,
    [Descripcion] VARCHAR(MAX) NULL,
    [Personald] UNIQUEIDENTIFIER NOT NULL,
    [Categoriald] UNIQUEIDENTIFIER NOT NULL,
    [TipoGastold] UNIQUEIDENTIFIER NOT NULL,
    [TarjetaId] UNIQUEIDENTIFIER  NULL,

    FOREIGN KEY ([Personald]) REFERENCES [Persona]([Personald]),
    FOREIGN KEY ([Categoriald]) REFERENCES [Categoria]([Categoriald]),
    FOREIGN KEY ([TipoGastold]) REFERENCES [TipoGasto]([TipoGastold]),
    FOREIGN KEY ([TarjetaId]) REFERENCES [Tarjeta]([TarjetaId])
);

CREATE TABLE [Movimiento] (
    [Movimientold] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [MontoTotal] DECIMAL(18, 2) NOT NULL,
    [Fecha] DATE NOT NULL,
    [Descripcion] VARCHAR(MAX) NULL,
    [GastoId] UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY ([GastoId]) REFERENCES [Gasto]([GastoId])
);

CREATE TABLE [Ingreso] (
    [Ingresold] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Monto] DECIMAL(18, 2) NOT NULL,
    [Fecha] DATE NOT NULL,
    [Descripcion] VARCHAR(MAX) NULL,

);
-- Relaciones

CREATE TABLE [TarjetaPorPeriodo] (
    [TarjetaId ]UNIQUEIDENTIFIER NOT NULL,
    [Periodold] UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY ([TarjetaId]) REFERENCES [Tarjeta]([TarjetaId]),
    FOREIGN KEY ([Periodold]) REFERENCES [Periodo]([Periodold])
);

CREATE TABLE [PeriodoPorGasto] (
    [Periodold] UNIQUEIDENTIFIER NOT NULL,
    [GastoId] UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY ([Periodold]) REFERENCES [Periodo]([Periodold]),
    FOREIGN KEY ([GastoId]) REFERENCES [Gasto]([GastoId])
);

CREATE TABLE [IngresoPorPersona] (
    [Ingresold] UNIQUEIDENTIFIER NOT NULL,
    [Personald] UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY ([Ingresold]) REFERENCES [Ingreso]([Ingresold]),
    FOREIGN KEY ([Personald]) REFERENCES [Persona]([Personald])
);

