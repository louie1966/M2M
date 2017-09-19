
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2017 15:38:46
-- Generated from EDMX file: c:\Dev\M2M\M2M\JobPortal.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [M2M];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'JobPosts'
CREATE TABLE [dbo].[JobPosts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [EmployerId] int  NOT NULL
);
GO

-- Creating table 'Employers'
CREATE TABLE [dbo].[Employers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JobTags'
CREATE TABLE [dbo].[JobTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tag] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JobPostJobTag'
CREATE TABLE [dbo].[JobPostJobTag] (
    [JobPosts_Id] int  NOT NULL,
    [JobTags_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'JobPosts'
ALTER TABLE [dbo].[JobPosts]
ADD CONSTRAINT [PK_JobPosts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employers'
ALTER TABLE [dbo].[Employers]
ADD CONSTRAINT [PK_Employers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobTags'
ALTER TABLE [dbo].[JobTags]
ADD CONSTRAINT [PK_JobTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [JobPosts_Id], [JobTags_Id] in table 'JobPostJobTag'
ALTER TABLE [dbo].[JobPostJobTag]
ADD CONSTRAINT [PK_JobPostJobTag]
    PRIMARY KEY CLUSTERED ([JobPosts_Id], [JobTags_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [JobPosts_Id] in table 'JobPostJobTag'
ALTER TABLE [dbo].[JobPostJobTag]
ADD CONSTRAINT [FK_JobPostJobTag_JobPost]
    FOREIGN KEY ([JobPosts_Id])
    REFERENCES [dbo].[JobPosts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JobTags_Id] in table 'JobPostJobTag'
ALTER TABLE [dbo].[JobPostJobTag]
ADD CONSTRAINT [FK_JobPostJobTag_JobTag]
    FOREIGN KEY ([JobTags_Id])
    REFERENCES [dbo].[JobTags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobPostJobTag_JobTag'
CREATE INDEX [IX_FK_JobPostJobTag_JobTag]
ON [dbo].[JobPostJobTag]
    ([JobTags_Id]);
GO

-- Creating foreign key on [EmployerId] in table 'JobPosts'
ALTER TABLE [dbo].[JobPosts]
ADD CONSTRAINT [FK_JobPostEmployer]
    FOREIGN KEY ([EmployerId])
    REFERENCES [dbo].[Employers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobPostEmployer'
CREATE INDEX [IX_FK_JobPostEmployer]
ON [dbo].[JobPosts]
    ([EmployerId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------