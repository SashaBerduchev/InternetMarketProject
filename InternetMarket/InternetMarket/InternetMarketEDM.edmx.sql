
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/13/2020 10:11:41
-- Generated from EDMX file: D:\Projects\C#\InternetMarketProject\InternetMarket\InternetMarket\InternetMarketEDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InternetMarket];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BankSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankSetSet];
GO
IF OBJECT_ID(N'[dbo].[BoilersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoilersSet];
GO
IF OBJECT_ID(N'[dbo].[CityDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CityDataSet];
GO
IF OBJECT_ID(N'[dbo].[CkladSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CkladSetSet];
GO
IF OBJECT_ID(N'[dbo].[ComputersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComputersSet];
GO
IF OBJECT_ID(N'[dbo].[CountrySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountrySet];
GO
IF OBJECT_ID(N'[dbo].[CPUSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CPUSet];
GO
IF OBJECT_ID(N'[dbo].[DirectorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DirectorSet];
GO
IF OBJECT_ID(N'[dbo].[DocForPainSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocForPainSet];
GO
IF OBJECT_ID(N'[dbo].[DogovorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DogovorSet];
GO
IF OBJECT_ID(N'[dbo].[Entity1Set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Entity1Set];
GO
IF OBJECT_ID(N'[dbo].[GraphicsCardSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GraphicsCardSet];
GO
IF OBJECT_ID(N'[dbo].[KassaSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KassaSetSet];
GO
IF OBJECT_ID(N'[dbo].[LaptopsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LaptopsSet];
GO
IF OBJECT_ID(N'[dbo].[MailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailSet];
GO
IF OBJECT_ID(N'[dbo].[OblastDataSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OblastDataSetSet];
GO
IF OBJECT_ID(N'[dbo].[OrganizationPositionSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationPositionSetSet];
GO
IF OBJECT_ID(N'[dbo].[OrganizationSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationSetSet];
GO
IF OBJECT_ID(N'[dbo].[PhonesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhonesSet];
GO
IF OBJECT_ID(N'[dbo].[PrintersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrintersSet];
GO
IF OBJECT_ID(N'[dbo].[RegionDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionDataSet];
GO
IF OBJECT_ID(N'[dbo].[SmtpServersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SmtpServersSet];
GO
IF OBJECT_ID(N'[dbo].[StreetSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StreetSetSet];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TabletSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TabletSetSet];
GO
IF OBJECT_ID(N'[dbo].[TivisetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TivisetSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ZakazPokupatelyaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZakazPokupatelyaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BankSetSet'
CREATE TABLE [dbo].[BankSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameBank] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BoilersSet'
CREATE TABLE [dbo].[BoilersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] nvarchar(max)  NOT NULL,
    [Power] nvarchar(max)  NOT NULL,
    [Voltage] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CityDataSet'
CREATE TABLE [dbo].[CityDataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CountryName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CkladSetSet'
CREATE TABLE [dbo].[CkladSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Organisation] nvarchar(max)  NOT NULL,
    [Oblast] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComputersSet'
CREATE TABLE [dbo].[ComputersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firm] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Processor] nvarchar(max)  NOT NULL,
    [RAM] nvarchar(max)  NOT NULL,
    [VRAM] nvarchar(max)  NOT NULL,
    [Graphics] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CountrySet'
CREATE TABLE [dbo].[CountrySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameCountry] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CPUSet'
CREATE TABLE [dbo].[CPUSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Architecture] nvarchar(max)  NOT NULL,
    [Cores] nvarchar(max)  NOT NULL,
    [Chastota] nvarchar(max)  NOT NULL,
    [KESHL1] nvarchar(max)  NOT NULL,
    [KESHL2] nvarchar(max)  NOT NULL,
    [KESHL3] nvarchar(max)  NOT NULL,
    [GPU] nvarchar(max)  NOT NULL,
    [RAM] nvarchar(max)  NOT NULL,
    [TDP] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DirectorSet'
CREATE TABLE [dbo].[DirectorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Oblast] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DocForPainSet'
CREATE TABLE [dbo].[DocForPainSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Organization] nvarchar(max)  NOT NULL,
    [Contragent] nvarchar(max)  NOT NULL,
    [DataLoad] nvarchar(max)  NOT NULL,
    [DataLoad1] nvarchar(max)  NOT NULL,
    [Dataload2] nvarchar(max)  NOT NULL,
    [Dataload3] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DogovorSet'
CREATE TABLE [dbo].[DogovorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Entity1Set'
CREATE TABLE [dbo].[Entity1Set] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'GraphicsCardSet'
CREATE TABLE [dbo].[GraphicsCardSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GraphicsCore] nvarchar(max)  NOT NULL,
    [Cores] nvarchar(max)  NOT NULL,
    [Herts] nvarchar(max)  NOT NULL,
    [VRAM] nvarchar(max)  NOT NULL,
    [Voltage] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PDF] varbinary(max)  NOT NULL
);
GO

-- Creating table 'KassaSetSet'
CREATE TABLE [dbo].[KassaSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bank] nvarchar(max)  NOT NULL,
    [Organization] nvarchar(max)  NOT NULL,
    [Valuta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LaptopsSet'
CREATE TABLE [dbo].[LaptopsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Procc] nvarchar(max)  NOT NULL,
    [RAM] nvarchar(max)  NOT NULL,
    [VRAM] nvarchar(max)  NOT NULL,
    [GPU] nvarchar(max)  NOT NULL,
    [SCREEN] nvarchar(max)  NOT NULL,
    [Resolution] nvarchar(max)  NOT NULL,
    [Battery] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MailSet'
CREATE TABLE [dbo].[MailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OblastDataSetSet'
CREATE TABLE [dbo].[OblastDataSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrganizationPositionSetSet'
CREATE TABLE [dbo].[OrganizationPositionSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CodeKP] nvarchar(max)  NOT NULL,
    [Organization] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrganizationSetSet'
CREATE TABLE [dbo].[OrganizationSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PhonesSet'
CREATE TABLE [dbo].[PhonesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firm] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Processor] nvarchar(max)  NOT NULL,
    [RAM] nvarchar(max)  NOT NULL,
    [Battery] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PDF] varbinary(max)  NOT NULL
);
GO

-- Creating table 'PrintersSet'
CREATE TABLE [dbo].[PrintersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Colors] nvarchar(max)  NOT NULL,
    [Speed] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RegionDataSet'
CREATE TABLE [dbo].[RegionDataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Oblast] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SmtpServersSet'
CREATE TABLE [dbo].[SmtpServersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Smtp] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StreetSetSet'
CREATE TABLE [dbo].[StreetSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [NameStreen] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TabletSetSet'
CREATE TABLE [dbo].[TabletSetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Processor] nvarchar(max)  NOT NULL,
    [RAM] nvarchar(max)  NOT NULL,
    [GPU] nvarchar(max)  NOT NULL,
    [Resolution] nvarchar(max)  NOT NULL,
    [Battery] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TivisetSet'
CREATE TABLE [dbo].[TivisetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firm] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PDF] varbinary(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ZakazPokupatelyaSet'
CREATE TABLE [dbo].[ZakazPokupatelyaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Organization] nvarchar(max)  NOT NULL,
    [Contragent] nvarchar(max)  NOT NULL,
    [Sklad] nvarchar(max)  NOT NULL,
    [Ysluga] nvarchar(max)  NOT NULL,
    [Data] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BankSetSet'
ALTER TABLE [dbo].[BankSetSet]
ADD CONSTRAINT [PK_BankSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BoilersSet'
ALTER TABLE [dbo].[BoilersSet]
ADD CONSTRAINT [PK_BoilersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CityDataSet'
ALTER TABLE [dbo].[CityDataSet]
ADD CONSTRAINT [PK_CityDataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CkladSetSet'
ALTER TABLE [dbo].[CkladSetSet]
ADD CONSTRAINT [PK_CkladSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComputersSet'
ALTER TABLE [dbo].[ComputersSet]
ADD CONSTRAINT [PK_ComputersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CountrySet'
ALTER TABLE [dbo].[CountrySet]
ADD CONSTRAINT [PK_CountrySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CPUSet'
ALTER TABLE [dbo].[CPUSet]
ADD CONSTRAINT [PK_CPUSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DirectorSet'
ALTER TABLE [dbo].[DirectorSet]
ADD CONSTRAINT [PK_DirectorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocForPainSet'
ALTER TABLE [dbo].[DocForPainSet]
ADD CONSTRAINT [PK_DocForPainSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DogovorSet'
ALTER TABLE [dbo].[DogovorSet]
ADD CONSTRAINT [PK_DogovorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Entity1Set'
ALTER TABLE [dbo].[Entity1Set]
ADD CONSTRAINT [PK_Entity1Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GraphicsCardSet'
ALTER TABLE [dbo].[GraphicsCardSet]
ADD CONSTRAINT [PK_GraphicsCardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KassaSetSet'
ALTER TABLE [dbo].[KassaSetSet]
ADD CONSTRAINT [PK_KassaSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LaptopsSet'
ALTER TABLE [dbo].[LaptopsSet]
ADD CONSTRAINT [PK_LaptopsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailSet'
ALTER TABLE [dbo].[MailSet]
ADD CONSTRAINT [PK_MailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OblastDataSetSet'
ALTER TABLE [dbo].[OblastDataSetSet]
ADD CONSTRAINT [PK_OblastDataSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizationPositionSetSet'
ALTER TABLE [dbo].[OrganizationPositionSetSet]
ADD CONSTRAINT [PK_OrganizationPositionSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizationSetSet'
ALTER TABLE [dbo].[OrganizationSetSet]
ADD CONSTRAINT [PK_OrganizationSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhonesSet'
ALTER TABLE [dbo].[PhonesSet]
ADD CONSTRAINT [PK_PhonesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrintersSet'
ALTER TABLE [dbo].[PrintersSet]
ADD CONSTRAINT [PK_PrintersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegionDataSet'
ALTER TABLE [dbo].[RegionDataSet]
ADD CONSTRAINT [PK_RegionDataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SmtpServersSet'
ALTER TABLE [dbo].[SmtpServersSet]
ADD CONSTRAINT [PK_SmtpServersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StreetSetSet'
ALTER TABLE [dbo].[StreetSetSet]
ADD CONSTRAINT [PK_StreetSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'TabletSetSet'
ALTER TABLE [dbo].[TabletSetSet]
ADD CONSTRAINT [PK_TabletSetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TivisetSet'
ALTER TABLE [dbo].[TivisetSet]
ADD CONSTRAINT [PK_TivisetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ZakazPokupatelyaSet'
ALTER TABLE [dbo].[ZakazPokupatelyaSet]
ADD CONSTRAINT [PK_ZakazPokupatelyaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------