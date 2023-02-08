DECLARE	@username varchar(50) ='brian'
DECLARE	@VName varchar(50) = 'bar7'
DECLARE	@datetime datetime ='2023-03-05 20:55'
DECLARE	@Pax int =2
DECLARE	@note varchar(max)='Gay OG'

exec CreateBooking
	@username,
	@VName,
	@datetime,
	@Pax,
	@note		

	select * from Bookings

	/*

	DECLARE	@username varchar(50) ='brian'
DECLARE	@VName varchar(50) = 'bar7'
DECLARE	@datetime datetime ='2023-03-05 20:55'
DECLARE	@Pax int =2
DECLARE	@note varchar(max)='Gay OG'



DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @VenueID int= (select VenueID from Venues where Name = @VName)
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	DECLARE @tbID int = (select top 1 vi.TableID from VenueItems vi 
							where vi.VenueID = @VenueID 
									and vi.Pax >= @Pax 
									and vi.TableID not in (select TableID from Bookings where cast(Time as date) >=  cast(@datetime as date))
									--and vi.status not in (2,22)
									order by vi.Pax) -- Not Available/booked or Arrived
select @tbID
select @VenueID
select * from Bookings where UserID = @UserID and VenueID = @VenueID 
					and cast(Time as datetime) >= cast(@datetime as datetime) and TableID = @tbID
					
					*/

					