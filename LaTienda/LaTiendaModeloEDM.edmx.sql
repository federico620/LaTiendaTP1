
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/20/2022 21:12:17
-- Generated from EDMX file: C:\Users\Trassani\source\repos\LaTienda\LaTienda\LaTiendaModeloEDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LaTienda];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClienteVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VentaSet] DROP CONSTRAINT [FK_ClienteVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_ColorStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_ColorStock];
GO
IF OBJECT_ID(N'[dbo].[FK_MarcaProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductoSet] DROP CONSTRAINT [FK_MarcaProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_ProductoStock];
GO
IF OBJECT_ID(N'[dbo].[FK_RubroProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductoSet] DROP CONSTRAINT [FK_RubroProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_StockSetLineaDeVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LineaDeVentaSet] DROP CONSTRAINT [FK_StockSetLineaDeVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_SucursalPuntoDeVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntoDeVentaSet] DROP CONSTRAINT [FK_SucursalPuntoDeVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_SucursalStockSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_SucursalStockSet];
GO
IF OBJECT_ID(N'[dbo].[FK_SucursalUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet] DROP CONSTRAINT [FK_SucursalUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_TalleStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StockSet] DROP CONSTRAINT [FK_TalleStock];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VentaSet] DROP CONSTRAINT [FK_UsuarioVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_VentaLineaDeVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LineaDeVentaSet] DROP CONSTRAINT [FK_VentaLineaDeVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_VentaSetComprobanteSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComprobanteSet] DROP CONSTRAINT [FK_VentaSetComprobanteSet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteSet];
GO
IF OBJECT_ID(N'[dbo].[ColorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColorSet];
GO
IF OBJECT_ID(N'[dbo].[ComprobanteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComprobanteSet];
GO
IF OBJECT_ID(N'[dbo].[LineaDeVentaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LineaDeVentaSet];
GO
IF OBJECT_ID(N'[dbo].[MarcaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarcaSet];
GO
IF OBJECT_ID(N'[dbo].[ProductoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductoSet];
GO
IF OBJECT_ID(N'[dbo].[PuntoDeVentaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PuntoDeVentaSet];
GO
IF OBJECT_ID(N'[dbo].[RubroSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RubroSet];
GO
IF OBJECT_ID(N'[dbo].[StockSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StockSet];
GO
IF OBJECT_ID(N'[dbo].[SucursalSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SucursalSet];
GO
IF OBJECT_ID(N'[dbo].[TalleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TalleSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[VentaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VentaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClienteSet'
CREATE TABLE [dbo].[ClienteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NULL,
    [Documento] bigint  NULL,
    [Domicilio] nvarchar(max)  NULL,
    [CondicionTributaria] int  NOT NULL,
    [TipoDocumento] int  NOT NULL
);
GO

-- Creating table 'ColorSet'
CREATE TABLE [dbo].[ColorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComprobanteSet'
CREATE TABLE [dbo].[ComprobanteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CAE] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [FechaVen] datetime  NOT NULL,
    [Concepto] int  NOT NULL,
    [TipoComprobante] int  NOT NULL,
    [VentaSet_Id] int  NOT NULL
);
GO

-- Creating table 'LineaDeVentaSet'
CREATE TABLE [dbo].[LineaDeVentaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cantidad] int  NOT NULL,
    [PrecioDeVenta] float  NOT NULL,
    [StockSet_Id] int  NOT NULL,
    [Venta_Id] int  NOT NULL
);
GO

-- Creating table 'MarcaSet'
CREATE TABLE [dbo].[MarcaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] bigint  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductoSet'
CREATE TABLE [dbo].[ProductoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] bigint  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Costo] float  NOT NULL,
    [MargenDeGanancia] int  NOT NULL,
    [Iva] float  NOT NULL,
    [NetoGravado] float  NOT NULL,
    [PorcentajeIva] int  NOT NULL,
    [PrecioDeVenta] float  NOT NULL,
    [Rubro_Id] int  NOT NULL,
    [Marca_Id] int  NOT NULL
);
GO

-- Creating table 'PuntoDeVentaSet'
CREATE TABLE [dbo].[PuntoDeVentaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Sucursal_Id] int  NOT NULL
);
GO

-- Creating table 'RubroSet'
CREATE TABLE [dbo].[RubroSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] bigint  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StockSet'
CREATE TABLE [dbo].[StockSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cantidad] int  NOT NULL,
    [Color_Id] int  NOT NULL,
    [Talle_Id] int  NOT NULL,
    [Producto_Id] int  NOT NULL,
    [SucursalId] int  NOT NULL
);
GO

-- Creating table 'SucursalSet'
CREATE TABLE [dbo].[SucursalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Sign] nvarchar(max)  NOT NULL,
    [Cuit] bigint  NOT NULL,
    [TipoDocumento] int  NOT NULL
);
GO

-- Creating table 'TalleSet'
CREATE TABLE [dbo].[TalleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] bigint  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Legajo] bigint  NOT NULL,
    [UsuarioNick] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [RolUsuario1] int  NOT NULL,
    [Sucursal_Id] int  NOT NULL
);
GO

-- Creating table 'VentaSet'
CREATE TABLE [dbo].[VentaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Total] float  NOT NULL,
    [Comprobante_Id] int  NULL,
    [Cliente_Id] int  NULL,
    [Usuario_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [PK_ClienteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ColorSet'
ALTER TABLE [dbo].[ColorSet]
ADD CONSTRAINT [PK_ColorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComprobanteSet'
ALTER TABLE [dbo].[ComprobanteSet]
ADD CONSTRAINT [PK_ComprobanteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LineaDeVentaSet'
ALTER TABLE [dbo].[LineaDeVentaSet]
ADD CONSTRAINT [PK_LineaDeVentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarcaSet'
ALTER TABLE [dbo].[MarcaSet]
ADD CONSTRAINT [PK_MarcaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductoSet'
ALTER TABLE [dbo].[ProductoSet]
ADD CONSTRAINT [PK_ProductoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PuntoDeVentaSet'
ALTER TABLE [dbo].[PuntoDeVentaSet]
ADD CONSTRAINT [PK_PuntoDeVentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RubroSet'
ALTER TABLE [dbo].[RubroSet]
ADD CONSTRAINT [PK_RubroSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [PK_StockSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SucursalSet'
ALTER TABLE [dbo].[SucursalSet]
ADD CONSTRAINT [PK_SucursalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TalleSet'
ALTER TABLE [dbo].[TalleSet]
ADD CONSTRAINT [PK_TalleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VentaSet'
ALTER TABLE [dbo].[VentaSet]
ADD CONSTRAINT [PK_VentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cliente_Id] in table 'VentaSet'
ALTER TABLE [dbo].[VentaSet]
ADD CONSTRAINT [FK_ClienteVenta]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteVenta'
CREATE INDEX [IX_FK_ClienteVenta]
ON [dbo].[VentaSet]
    ([Cliente_Id]);
GO

-- Creating foreign key on [Color_Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_ColorStock]
    FOREIGN KEY ([Color_Id])
    REFERENCES [dbo].[ColorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColorStock'
CREATE INDEX [IX_FK_ColorStock]
ON [dbo].[StockSet]
    ([Color_Id]);
GO

-- Creating foreign key on [StockSet_Id] in table 'LineaDeVentaSet'
ALTER TABLE [dbo].[LineaDeVentaSet]
ADD CONSTRAINT [FK_StockSetLineaDeVenta]
    FOREIGN KEY ([StockSet_Id])
    REFERENCES [dbo].[StockSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockSetLineaDeVenta'
CREATE INDEX [IX_FK_StockSetLineaDeVenta]
ON [dbo].[LineaDeVentaSet]
    ([StockSet_Id]);
GO

-- Creating foreign key on [Venta_Id] in table 'LineaDeVentaSet'
ALTER TABLE [dbo].[LineaDeVentaSet]
ADD CONSTRAINT [FK_VentaLineaDeVenta]
    FOREIGN KEY ([Venta_Id])
    REFERENCES [dbo].[VentaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentaLineaDeVenta'
CREATE INDEX [IX_FK_VentaLineaDeVenta]
ON [dbo].[LineaDeVentaSet]
    ([Venta_Id]);
GO

-- Creating foreign key on [Marca_Id] in table 'ProductoSet'
ALTER TABLE [dbo].[ProductoSet]
ADD CONSTRAINT [FK_MarcaProducto]
    FOREIGN KEY ([Marca_Id])
    REFERENCES [dbo].[MarcaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcaProducto'
CREATE INDEX [IX_FK_MarcaProducto]
ON [dbo].[ProductoSet]
    ([Marca_Id]);
GO

-- Creating foreign key on [Producto_Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_ProductoStock]
    FOREIGN KEY ([Producto_Id])
    REFERENCES [dbo].[ProductoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoStock'
CREATE INDEX [IX_FK_ProductoStock]
ON [dbo].[StockSet]
    ([Producto_Id]);
GO

-- Creating foreign key on [Rubro_Id] in table 'ProductoSet'
ALTER TABLE [dbo].[ProductoSet]
ADD CONSTRAINT [FK_RubroProducto]
    FOREIGN KEY ([Rubro_Id])
    REFERENCES [dbo].[RubroSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RubroProducto'
CREATE INDEX [IX_FK_RubroProducto]
ON [dbo].[ProductoSet]
    ([Rubro_Id]);
GO

-- Creating foreign key on [Sucursal_Id] in table 'PuntoDeVentaSet'
ALTER TABLE [dbo].[PuntoDeVentaSet]
ADD CONSTRAINT [FK_SucursalPuntoDeVenta]
    FOREIGN KEY ([Sucursal_Id])
    REFERENCES [dbo].[SucursalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SucursalPuntoDeVenta'
CREATE INDEX [IX_FK_SucursalPuntoDeVenta]
ON [dbo].[PuntoDeVentaSet]
    ([Sucursal_Id]);
GO

-- Creating foreign key on [SucursalId] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_SucursalStockSet]
    FOREIGN KEY ([SucursalId])
    REFERENCES [dbo].[SucursalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SucursalStockSet'
CREATE INDEX [IX_FK_SucursalStockSet]
ON [dbo].[StockSet]
    ([SucursalId]);
GO

-- Creating foreign key on [Talle_Id] in table 'StockSet'
ALTER TABLE [dbo].[StockSet]
ADD CONSTRAINT [FK_TalleStock]
    FOREIGN KEY ([Talle_Id])
    REFERENCES [dbo].[TalleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TalleStock'
CREATE INDEX [IX_FK_TalleStock]
ON [dbo].[StockSet]
    ([Talle_Id]);
GO

-- Creating foreign key on [Sucursal_Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [FK_SucursalUsuario]
    FOREIGN KEY ([Sucursal_Id])
    REFERENCES [dbo].[SucursalSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SucursalUsuario'
CREATE INDEX [IX_FK_SucursalUsuario]
ON [dbo].[UsuarioSet]
    ([Sucursal_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'VentaSet'
ALTER TABLE [dbo].[VentaSet]
ADD CONSTRAINT [FK_UsuarioVenta]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioVenta'
CREATE INDEX [IX_FK_UsuarioVenta]
ON [dbo].[VentaSet]
    ([Usuario_Id]);
GO

-- Creating foreign key on [VentaSet_Id] in table 'ComprobanteSet'
ALTER TABLE [dbo].[ComprobanteSet]
ADD CONSTRAINT [FK_VentaSetComprobanteSet]
    FOREIGN KEY ([VentaSet_Id])
    REFERENCES [dbo].[VentaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentaSetComprobanteSet'
CREATE INDEX [IX_FK_VentaSetComprobanteSet]
ON [dbo].[ComprobanteSet]
    ([VentaSet_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------