CREATE DATABASE [Empresa];
go
USE [Empresa];
go
 
CREATE TABLE [Dependencia]
(
[Id] INT IDENTITY(1,1),
[Nombre] VARCHAR (50)
CONSTRAINT PK_Dependencia PRIMARY KEY (Id),
);
GO

CREATE TABLE [Empleado]
(
[Id] INT IDENTITY(1,1),
[Id_Dependencia] INT NULL,
[Nombre] VARCHAR(30)
CONSTRAINT PK_Empleado PRIMARY KEY (Id),
CONSTRAINT FK_EmpleadoDependencia FOREIGN KEY ([Id_Dependencia]) REFERENCES [Dependencia]([Id])
);
GO

/*Se insertan datos en base de datos*/
INSERT INTO [dbo].[Dependencia]
           ([Nombre])
     VALUES
           ('Produccion'),
		   ('Logistica'),
		   ('Recursos humanos'),
		   ('Comercial'),
		   ('Finanzas'),
		   ('Ingenieria')
GO


INSERT INTO [dbo].[Empleado]
           ([Id_Dependencia]
           ,[Nombre])
     VALUES
		   ('1','Juan Andres Carrillo')           
GO
