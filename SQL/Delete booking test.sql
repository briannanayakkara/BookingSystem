DECLARE @username varchar(50) = 'brian'
DECLARE @BoID int = 5

exec DeleteBooking
	@username,
	@BoID
	

	select * from bookings
	select * from deletebookinglog
