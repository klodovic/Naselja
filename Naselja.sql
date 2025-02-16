create database Naselja

create table Drzave(
	Id int identity(1,1) primary key, 
	Naziv nvarchar(100) not null
)

create table Naselja(
	Id int identity(1,1) primary key,
	DrzavaId int not null,
	PostanskiBroj nvarchar(10) not null,
	Naziv nvarchar(100) not null,
	foreign key (DrzavaId) references Drzave(Id)
)

insert into Drzave (Naziv) values ('Hrvatska'), ('Slovenija'), ('Austrija');

insert into Naselja (DrzavaID, PostanskiBroj, Naziv) 
values (1, '10000', 'Zagreb'), (1, '21000', 'Split'), (2, '1000', 'Ljubljana');
