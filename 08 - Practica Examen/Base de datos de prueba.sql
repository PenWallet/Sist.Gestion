CREATE DATABASE PruebaExamen
GO
USE PruebaExamen
GO

CREATE TABLE Departamentos (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(20)
)

GO

CREATE TABLE Personas (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	IDDepartamento int NOT NULL FOREIGN KEY REFERENCES Departamentos(ID),
	nombre varchar(20),
	apellidos varchar(40),
	telefono varchar(12)
)

GO

INSERT INTO Departamentos (nombre) VALUES	('Informatica'), ('Limpieza'), ('Administracion'), 
											('Contabilidad'), ('RR.HH.')

GO

INSERT INTO Personas (IDDepartamento, nombre, apellidos, telefono)
VALUES
(1, 'Oscar', 'Funes', '564879213'),
(3, 'Sefuran', 'Flowered', '897651845'),
(4, 'Jose', 'Algo', '879546154'),
(4, 'Dylan', 'Soler', '872137454'),
(1, 'Rafa', 'Mateos', '411484654'),
(2, 'Eva', 'María', '987613432'),
(2, 'Joruje', 'Watashi no apellido', '321873218'),
(3, 'Nacho', 'Van Loy', '843763786'),
(5, 'Samuel', 'Apellido 1', '783786378'),
(1, 'Luis', 'Zummaraga', '784176723'),
(1, 'Angel', 'Apellido 2', '87478424')

--Usuarios
CREATE LOGIN PruebaExamen with password = '123qweasd!', default_database=PruebaExamen
GO
CREATE USER PruebaExamen FOR LOGIN PruebaExamen GRANT INSERT, UPDATE, DELETE, EXECUTE TO prueba