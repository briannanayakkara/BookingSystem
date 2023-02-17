declare @username varchar(50)='dim',
	@Name varchar(20)= 'bar2',
	@Limit int = 50,
	@EmployeeQty int = 21,
	@region nvarchar(50) = 'cph' ,
	@type varchar(50) ='Cocktail bar',
	@cvr varchar(50) = 'DK 52 52 52',
	@VenueName varchar(20) = 'bar2'

EXEC [UpdateVenue] @username,@Name,@Limit,@EmployeeQty,@region,@type,@cvr,@VenueName



