--Equipo de Agenda Telefonica
--Abigail Alexandra Colocho Flamenco 260494
--René Alejandro Guevara Guevara 260595
--Josue Mateo Villalta Abrego 261002
--Dennis Alejandro Rivera Manzanares 261337

create database DB_AgendaTel
GO

use DB_AgendaTel
GO

--creamos tabla usuarios--
create table Usuarios(
IdUsuario int primary key identity (1,1),
Nombre varchar(50) not null unique,
Usuario varchar(50) not null,
Contraseña varchar(100) not null
)
GO
--creamos tabla contactos--
create table Contactos(
IdContacto int primary key identity(1,1),
IdUsuario int not null,
Nombres varchar(50) not null,
Apellido varchar(50) null,
Edad int null,
constraint fk_Usuario foreign key (IdUsuario)
references Usuarios(IdUsuario)
)
GO
--creamos tabla telefonos--
create table Telefonos(
IdTelefonos int primary key identity(1,1),
IdContacto int not null,
Numero varchar(15),
constraint fk_Contacto foreign key (IdContacto)
references Contactos(IdContacto)
)
GO

--Modificamos la tabla contactos y la tabla telefonos para activar el borrado cascada--
--Para hacer la modificacion es necesario borrar la regla antigua--
ALTER TABLE Contactos DROP constraint  fk_Usuario

GO

ALTER TABLE Contactos ADD constraint fk_Usuario FOREIGN KEY (IdUsuario) 
references Usuarios(IdUsuario) 
ON DELETE CASCADE 
GO

ALTER TABLE Telefonos DROP constraint fk_Contacto

GO

ALTER TABLE Telefonos ADD constraint fk_Contacto FOREIGN KEY (IdContacto) 
references Contactos(IdContacto) 
ON DELETE CASCADE 

GO

--Instruccion para poder visualizar tablas--
Select * from Usuarios
Select * from Contactos
Select * from Telefonos

GO

--Ahora ingresamos datos de prueba--
INSERT INTO Usuarios (Nombre, Usuario, Contraseña) VALUES
('Juan', 'Juanpi1', 'pio12345'),
('Maria', 'Mar225', 'Maria335'),
('Natalia', 'Naty2', 'Natalia22020'),
('Marcos', 'MarcIng', 'M190325'),
('Mario', 'MarioAlex', 'Alexito23')

GO

INSERT INTO Contactos (IdUsuario, Nombres, Apellido, Edad) VALUES
(1,'Pedrito','Peréz',null),
(2,'Marta','Hernandez',30),
(2,'José','Casas',45),
(3,'Miranda','Miramonte',null),
(4,'Leodon','Argueta',25),
(4,'Josefa',null, null),
(5,'Leonor',null, 13)

GO

INSERT INTO Telefonos (IdContacto, Numero) VALUES
(1,'24566755'),
(2,'+503 24005679'),
(3,'80974124'),
(4,'+502 12345678'),
(5,'47398739'),
(6,'96325871'),
(7,'78945612')


GO