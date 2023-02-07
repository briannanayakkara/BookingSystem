DECLARE	@username varchar(50) ='niko'
DECLARE	@VName varchar(50) = 'bar7'
DECLARE	@datetime datetime ='2023-02-05 10:55'
DECLARE	@Pax int =2
DECLARE	@note varchar(max)='Some table'

	DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @VenueID int= (select VenueID from Venues where Name = @VName)
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	-- selecting tableID

DECLARE @tbID int = (select top 1 vi.TableID from VenueItems vi 
							where vi.VenueID = @VenueID 
									and vi.Pax > @Pax 
									and vi.TableID not in (select TableID from Bookings where cast(Time as date) >=  cast(@datetime as date)))


select * from Bookings where UserID = 2 and VenueID = 1 
					and cast(Time as date) >= cast(@datetime as date) and TableID = @tbID
					and @tbID is not null

/*
exec CreateBooking
	@username ='niko',
	@VName = 'bar72',
	@datetime ='2023-02-05 10:53',
	@Pax =2,
	@note ='Some table'
	
	*/

	select * from Bookings

	select u.Firstname,v.Name,b.Time,b.Pax,b.Note,b.TableID,vi.TableNr from bookings b join Venues v on v.VenueID = b.VenueID join VenueItems vi on vi.VenueID = b.VenueID join Users u on u.UserID = b.UserID 
