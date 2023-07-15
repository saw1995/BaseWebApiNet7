create database IsiBoCoreNegocio;

use IsiBoCoreNegocio;

create table usuario(
id int auto_increment primary key,
idCanal int not null,
idDepartamento int not null,
ci varchar(12),
nombre varchar(50),
apellidoPaterno varchar(50),
apellidoMaterno varchar(50),
direccion varchar(250),
correo varchar(60),
celular varchar(20),
foto text,
pass varchar(50),
fechaCreacion datetime,
fechaActualizacion datetime,
estado bit
);

create table canal(
id int auto_increment key not null,
nombre varchar(50),
descripcion varchar(250),
token varchar(150),
fechaActualizacion datetime,
estado bit
);

create table appSistema(
id int auto_increment primary key,
idCanal int not null,
versionApp varchar(50),
nombre varchar(50),
fecha datetime,
estado bit
);

create table usuarioAppSistema(
id int auto_increment primary key,
idAppSistema int not null,
idUsuario int,
estado bit
);

create table usuarioLogin(
id int auto_increment primary key,
idAppSistema int not null,
idUsuario int not null,
dispositivo varchar(50),
detalle text,
fechaIngreso datetime,
fechaSalida datetime,
estado bit
);