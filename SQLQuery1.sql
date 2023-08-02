IF db_id('MyCLOSET') IS NULl
  CREATE DATABASE [MyCLOSET]
GO
USE [MyCLOSET]
GO

CREATE TABLE [Users] (
  [Id] int PRIMARY KEY IDENTITY,
  [UserName] nvarchar(255),
  [Email] nvarchar(255),
  [Password] nvarchar(255)
)
GO

CREATE TABLE [Clothes] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Size] nvarchar(255),
  [Status] bit,
  [Image] nvarchar(255),
  [Material] nvarchar(255),
  [Notes] nvarchar(255),
  [UserId] int
)
GO

CREATE TABLE [Gadgets] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Status] bit,
  [Image] nvarchar(255),
  [Notes] nvarchar(255),
  [UserId] int
)
GO

CREATE TABLE [Shoes] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Size] nvarchar(255),
  [Status] bit,
  [Image] nvarchar(255),
  [Notes] nvarchar(255),
  [UserId] int
)
GO

ALTER TABLE [Clothes] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [Gadgets] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [Shoes] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO
