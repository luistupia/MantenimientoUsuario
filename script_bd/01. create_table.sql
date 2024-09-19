--
-- Create table [dbo].[Usuario]
--
PRINT (N'Create table [dbo].[Usuario]')
GO
CREATE TABLE dbo.Usuario (
  Id int IDENTITY,
  Nombres varchar(100) NOT NULL,
  Apellidos varchar(100) NOT NULL,
  NumeroDocumento varchar(11) NOT NULL,
  Avatar varchar(350) NULL,
  PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO