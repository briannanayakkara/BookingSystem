declare @username varchar(50) ='brian',
		@VName varchar(20) ='bar1',
		@date varchar(50) = '2023-02-09'


exec [GetBookings] @username,@VName,@date

	
