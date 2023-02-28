DECLARE @AdminLvl int = 1,
	@firstname varchar(20)= 'Brian',
	@lastname varchar(50)='Nanayakkara',
	@username varchar(20)='brian',
	@email varchar(50)='dimalbrian@gamil.com',
	@phone int = 60212189,
	@region nvarchar(50)='CPH',
	@bday datetime= '1999-07-15',
	@pass nvarchar(50) ='pass2Test!'

exec CreateUser @AdminLvl,@firstname,@lastname,@username,@email,@phone,@region,@bday,@pass

select * from users 

select * from UserLogin







