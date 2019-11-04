create database T_Roman;

use T_Roman;


-- DDL 

create table Usuarios(
	idUsuario int identity primary key,
	nome varchar (500),
	email varchar (550),
	senha varchar (500)
);

create table Temas(
	idTema int identity primary key,
	nome varchar (500)
);

create table Aulas(
	idAula int primary key identity,
	nome varchar(500),
	idUsuario int foreign key references Usuarios (idUsuario),
	idTema int foreign key references Temas (idTema)
);

--DML

insert into Temas 
			values  ('Ética'),
					('Relevo'),
					('Binomiais'),
					('Ecologia');

insert into Usuarios
			values ('Alcides','tidis@email.com','123456'),
				   ('Cesão','cesar@email.com','654321'),
				   ('Ana Luiza','analu@email.com','1346');

insert into Aulas
			values('Sociologia', 2, 1),
				  ('Matemática', 1, 3),
				  ('Geografia', 3, 2);

--DQL

select * from Temas 

select * from Usuarios

select * from Aulas
