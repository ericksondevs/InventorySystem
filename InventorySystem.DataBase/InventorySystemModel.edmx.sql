
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2018 00:19:10
-- Generated from EDMX file: C:\Users\Rafael Garcia\source\repos\InventorySystem\InventorySystem.DataBase\InventorySystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InventorySystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_pk_product_caterogy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_t] DROP CONSTRAINT [FK_pk_product_caterogy];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_employee_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee_t] DROP CONSTRAINT [FK_pk_employee_user];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_employee_warehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee_t] DROP CONSTRAINT [FK_pk_employee_warehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_product_unit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_t] DROP CONSTRAINT [FK_pk_product_unit];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_product_warehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_t] DROP CONSTRAINT [FK_pk_product_warehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_user_role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_t] DROP CONSTRAINT [FK_pk_user_role];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationProduct_t]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operation_t] DROP CONSTRAINT [FK_OperationProduct_t];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationOperation_type_t]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operation_t] DROP CONSTRAINT [FK_OperationOperation_type_t];
GO
IF OBJECT_ID(N'[dbo].[FK_SellOperation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operation_t] DROP CONSTRAINT [FK_SellOperation];
GO
IF OBJECT_ID(N'[dbo].[FK_SellOperation_type_t]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sell_t] DROP CONSTRAINT [FK_SellOperation_type_t];
GO
IF OBJECT_ID(N'[dbo].[FK_SellPerson_t1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sell_t] DROP CONSTRAINT [FK_SellPerson_t1];
GO
IF OBJECT_ID(N'[dbo].[FK_SellUser_t1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sell_t] DROP CONSTRAINT [FK_SellUser_t1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category_t];
GO
IF OBJECT_ID(N'[dbo].[Employee_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee_t];
GO
IF OBJECT_ID(N'[dbo].[inventario_v]', 'U') IS NOT NULL
    DROP TABLE [dbo].[inventario_v];
GO
IF OBJECT_ID(N'[dbo].[Product_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_t];
GO
IF OBJECT_ID(N'[dbo].[Role_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role_t];
GO
IF OBJECT_ID(N'[dbo].[Unit_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Unit_t];
GO
IF OBJECT_ID(N'[dbo].[User_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_t];
GO
IF OBJECT_ID(N'[dbo].[Warehouse_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warehouse_t];
GO
IF OBJECT_ID(N'[dbo].[Operation_type_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operation_type_t];
GO
IF OBJECT_ID(N'[dbo].[Person_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person_t];
GO
IF OBJECT_ID(N'[dbo].[Operation_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operation_t];
GO
IF OBJECT_ID(N'[dbo].[Sell_t]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sell_t];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Category_t'
CREATE TABLE [dbo].[Category_t] (
    [category_id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(100)  NOT NULL,
    [description] varchar(200)  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'Employee_t'
CREATE TABLE [dbo].[Employee_t] (
    [employee_id] int IDENTITY(1,1) NOT NULL,
    [first_name] varchar(100)  NOT NULL,
    [last_name_1] varchar(100)  NOT NULL,
    [last_name_2] varchar(100)  NULL,
    [identification] varchar(11)  NULL,
    [address] varchar(200)  NULL,
    [hiring_date] datetime  NULL,
    [user_id] int  NULL,
    [warehouse_id] int  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'inventario_v'
CREATE TABLE [dbo].[inventario_v] (
    [Producto] varchar(100)  NOT NULL,
    [Almacen] varchar(200)  NOT NULL,
    [Categoria] varchar(100)  NOT NULL
);
GO

-- Creating table 'Product_t'
CREATE TABLE [dbo].[Product_t] (
    [product_id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(100)  NOT NULL,
    [description] varchar(200)  NULL,
    [price] decimal(9,2)  NOT NULL,
    [existence] decimal(9,2)  NOT NULL,
    [unit_id] int  NULL,
    [category_id] int  NULL,
    [warehouse_id] int  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'Role_t'
CREATE TABLE [dbo].[Role_t] (
    [role_id] int IDENTITY(1,1) NOT NULL,
    [description] varchar(200)  NOT NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'Unit_t'
CREATE TABLE [dbo].[Unit_t] (
    [unit_id] int IDENTITY(1,1) NOT NULL,
    [description] varchar(100)  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'User_t'
CREATE TABLE [dbo].[User_t] (
    [user_id] int IDENTITY(1,1) NOT NULL,
    [email] varchar(100)  NOT NULL,
    [password] varchar(200)  NOT NULL,
    [role_id] int  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'Warehouse_t'
CREATE TABLE [dbo].[Warehouse_t] (
    [warehouse_id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(200)  NOT NULL,
    [address] varchar(200)  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] varchar(100)  NULL
);
GO

-- Creating table 'Operation_type_t'
CREATE TABLE [dbo].[Operation_type_t] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdOperacion] int  NOT NULL,
    [Description] varchar(50)  NOT NULL
);
GO

-- Creating table 'Person_t'
CREATE TABLE [dbo].[Person_t] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(100)  NOT NULL,
    [lastName] varchar(100)  NOT NULL,
    [company] varchar(100)  NULL,
    [address1] varchar(100)  NULL,
    [address2] varchar(100)  NULL,
    [phone] varchar(100)  NULL,
    [email] varchar(100)  NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] nvarchar(max)  NULL
);
GO

-- Creating table 'Operation_t'
CREATE TABLE [dbo].[Operation_t] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sell_Id] int  NOT NULL,
    [product_id] int  NOT NULL,
    [Operation_type_Id] int  NOT NULL,
    [last_update_date] datetime  NULL,
    [creation_Date] datetime  NULL,
    [last_user_update] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Sell_t'
CREATE TABLE [dbo].[Sell_t] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [total] float  NOT NULL,
    [cash] float  NOT NULL,
    [discount] nvarchar(max)  NOT NULL,
    [Person_Id] int  NOT NULL,
    [Operation_type_Id] int  NOT NULL,
    [user_id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [category_id] in table 'Category_t'
ALTER TABLE [dbo].[Category_t]
ADD CONSTRAINT [PK_Category_t]
    PRIMARY KEY CLUSTERED ([category_id] ASC);
GO

-- Creating primary key on [employee_id] in table 'Employee_t'
ALTER TABLE [dbo].[Employee_t]
ADD CONSTRAINT [PK_Employee_t]
    PRIMARY KEY CLUSTERED ([employee_id] ASC);
GO

-- Creating primary key on [Producto], [Almacen], [Categoria] in table 'inventario_v'
ALTER TABLE [dbo].[inventario_v]
ADD CONSTRAINT [PK_inventario_v]
    PRIMARY KEY CLUSTERED ([Producto], [Almacen], [Categoria] ASC);
GO

-- Creating primary key on [product_id] in table 'Product_t'
ALTER TABLE [dbo].[Product_t]
ADD CONSTRAINT [PK_Product_t]
    PRIMARY KEY CLUSTERED ([product_id] ASC);
GO

-- Creating primary key on [role_id] in table 'Role_t'
ALTER TABLE [dbo].[Role_t]
ADD CONSTRAINT [PK_Role_t]
    PRIMARY KEY CLUSTERED ([role_id] ASC);
GO

-- Creating primary key on [unit_id] in table 'Unit_t'
ALTER TABLE [dbo].[Unit_t]
ADD CONSTRAINT [PK_Unit_t]
    PRIMARY KEY CLUSTERED ([unit_id] ASC);
GO

-- Creating primary key on [user_id] in table 'User_t'
ALTER TABLE [dbo].[User_t]
ADD CONSTRAINT [PK_User_t]
    PRIMARY KEY CLUSTERED ([user_id] ASC);
GO

-- Creating primary key on [warehouse_id] in table 'Warehouse_t'
ALTER TABLE [dbo].[Warehouse_t]
ADD CONSTRAINT [PK_Warehouse_t]
    PRIMARY KEY CLUSTERED ([warehouse_id] ASC);
GO

-- Creating primary key on [Id] in table 'Operation_type_t'
ALTER TABLE [dbo].[Operation_type_t]
ADD CONSTRAINT [PK_Operation_type_t]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person_t'
ALTER TABLE [dbo].[Person_t]
ADD CONSTRAINT [PK_Person_t]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operation_t'
ALTER TABLE [dbo].[Operation_t]
ADD CONSTRAINT [PK_Operation_t]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sell_t'
ALTER TABLE [dbo].[Sell_t]
ADD CONSTRAINT [PK_Sell_t]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [category_id] in table 'Product_t'
ALTER TABLE [dbo].[Product_t]
ADD CONSTRAINT [FK_pk_product_caterogy]
    FOREIGN KEY ([category_id])
    REFERENCES [dbo].[Category_t]
        ([category_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_product_caterogy'
CREATE INDEX [IX_FK_pk_product_caterogy]
ON [dbo].[Product_t]
    ([category_id]);
GO

-- Creating foreign key on [user_id] in table 'Employee_t'
ALTER TABLE [dbo].[Employee_t]
ADD CONSTRAINT [FK_pk_employee_user]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[User_t]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_employee_user'
CREATE INDEX [IX_FK_pk_employee_user]
ON [dbo].[Employee_t]
    ([user_id]);
GO

-- Creating foreign key on [warehouse_id] in table 'Employee_t'
ALTER TABLE [dbo].[Employee_t]
ADD CONSTRAINT [FK_pk_employee_warehouse]
    FOREIGN KEY ([warehouse_id])
    REFERENCES [dbo].[Warehouse_t]
        ([warehouse_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_employee_warehouse'
CREATE INDEX [IX_FK_pk_employee_warehouse]
ON [dbo].[Employee_t]
    ([warehouse_id]);
GO

-- Creating foreign key on [unit_id] in table 'Product_t'
ALTER TABLE [dbo].[Product_t]
ADD CONSTRAINT [FK_pk_product_unit]
    FOREIGN KEY ([unit_id])
    REFERENCES [dbo].[Unit_t]
        ([unit_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_product_unit'
CREATE INDEX [IX_FK_pk_product_unit]
ON [dbo].[Product_t]
    ([unit_id]);
GO

-- Creating foreign key on [warehouse_id] in table 'Product_t'
ALTER TABLE [dbo].[Product_t]
ADD CONSTRAINT [FK_pk_product_warehouse]
    FOREIGN KEY ([warehouse_id])
    REFERENCES [dbo].[Warehouse_t]
        ([warehouse_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_product_warehouse'
CREATE INDEX [IX_FK_pk_product_warehouse]
ON [dbo].[Product_t]
    ([warehouse_id]);
GO

-- Creating foreign key on [role_id] in table 'User_t'
ALTER TABLE [dbo].[User_t]
ADD CONSTRAINT [FK_pk_user_role]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Role_t]
        ([role_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_user_role'
CREATE INDEX [IX_FK_pk_user_role]
ON [dbo].[User_t]
    ([role_id]);
GO

-- Creating foreign key on [product_id] in table 'Operation_t'
ALTER TABLE [dbo].[Operation_t]
ADD CONSTRAINT [FK_OperationProduct_t]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[Product_t]
        ([product_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationProduct_t'
CREATE INDEX [IX_FK_OperationProduct_t]
ON [dbo].[Operation_t]
    ([product_id]);
GO

-- Creating foreign key on [Operation_type_Id] in table 'Operation_t'
ALTER TABLE [dbo].[Operation_t]
ADD CONSTRAINT [FK_OperationOperation_type_t]
    FOREIGN KEY ([Operation_type_Id])
    REFERENCES [dbo].[Operation_type_t]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationOperation_type_t'
CREATE INDEX [IX_FK_OperationOperation_type_t]
ON [dbo].[Operation_t]
    ([Operation_type_Id]);
GO

-- Creating foreign key on [Sell_Id] in table 'Operation_t'
ALTER TABLE [dbo].[Operation_t]
ADD CONSTRAINT [FK_SellOperation]
    FOREIGN KEY ([Sell_Id])
    REFERENCES [dbo].[Sell_t]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellOperation'
CREATE INDEX [IX_FK_SellOperation]
ON [dbo].[Operation_t]
    ([Sell_Id]);
GO

-- Creating foreign key on [Operation_type_Id] in table 'Sell_t'
ALTER TABLE [dbo].[Sell_t]
ADD CONSTRAINT [FK_SellOperation_type_t]
    FOREIGN KEY ([Operation_type_Id])
    REFERENCES [dbo].[Operation_type_t]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellOperation_type_t'
CREATE INDEX [IX_FK_SellOperation_type_t]
ON [dbo].[Sell_t]
    ([Operation_type_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'Sell_t'
ALTER TABLE [dbo].[Sell_t]
ADD CONSTRAINT [FK_SellPerson_t1]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[Person_t]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellPerson_t1'
CREATE INDEX [IX_FK_SellPerson_t1]
ON [dbo].[Sell_t]
    ([Person_Id]);
GO

-- Creating foreign key on [user_id] in table 'Sell_t'
ALTER TABLE [dbo].[Sell_t]
ADD CONSTRAINT [FK_SellUser_t1]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[User_t]
        ([user_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellUser_t1'
CREATE INDEX [IX_FK_SellUser_t1]
ON [dbo].[Sell_t]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------