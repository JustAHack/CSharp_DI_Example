if exists (select * from Information_Schema.Tables where Table_Name = 'Pet')
begin
	insert into Pet values ('Daisy', 12, 'Dog');
	insert into Pet values ('Jasmine', 10, 'Dog');
	insert into Pet values ('Jacinta', 9, 'Dog');
	insert into Pet values ('Kitty', 14, 'Cat');
end
