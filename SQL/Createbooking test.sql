DECLARE	@username varchar(50) ='yaf'
DECLARE	@VName varchar(50) = 'bar8'
DECLARE	@datetime datetime ='2023-02-07 10:55'
DECLARE	@Pax int =9
DECLARE	@note varchar(max)='Gay OG'

exec CreateBooking
	@username,
	@VName,
	@datetime,
	@Pax,
	@note
	
	

	select * from Bookings

