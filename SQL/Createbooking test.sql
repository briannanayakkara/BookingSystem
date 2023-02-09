DECLARE	@username varchar(50) ='niko'
DECLARE	@VName varchar(50) = 'bar1'
DECLARE	@datetime datetime ='2023-02-08 22:55'
DECLARE	@Pax int =2
DECLARE	@note varchar(max)='Reunion'

exec CreateBooking
	@username,
	@VName,
	@datetime,
	@Pax,
	@note		

	select * from Bookings


					