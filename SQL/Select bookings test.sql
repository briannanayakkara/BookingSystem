declare @username varchar(50) ='dim',
		@VName varchar(20) ='bar2',
		@date varchar(50) = null,
		@status  int = null
exec [GetBookings] @username,@VName,@date,@status

	
