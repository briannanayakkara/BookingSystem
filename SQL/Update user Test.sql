
declare @AdminLvl int = 0,
	@firstname varchar(20) = 'Niko',
	@lastname varchar(50) = null,
	@username varchar(20)= 'Niko' ,
	@email varchar(50)= 'Niko@gmail.com',
	@phone int = 60212568,
	@region nvarchar(50)= 'CPH',
	@bday datetime = '2000-07-15',
	@pass nvarchar(50) = 'Test21234',
	@ID int = 2

exec [UpdateUser] 
	@AdminLvl,
	@firstname,
	@lastname,
	@username,
	@email,
	@phone,
	@region,
	@bday,
	@pass,
	@ID

	select * from users
	select * from UserLogin