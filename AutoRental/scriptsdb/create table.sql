USE AutoRental
GO

create table manufacturer(
id_manufacturer int primary key identity,
name varchar(100) not null,
cnpj varchar(100),
cep int
);

create table auto (
id_auto int primary key identity,
plate varchar(100) unique not null,
id_manufacturer int not null,
model varchar(100) not null,
year date not null
foreign key (id_manufacturer) references manufacturer(id_manufacturer)
);

create table year(
year int unique not null
);

drop table year;
drop table auto;
drop table manufacturer;