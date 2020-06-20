drop table Pet;
create table Pet
(
	PetID int not null identity,
	Name nvarchar(max) not null,
	Age nvarchar(3) not null,
	Type nvarchar(max) not null,
	constraint PK_Pet primary key (PetID)
);