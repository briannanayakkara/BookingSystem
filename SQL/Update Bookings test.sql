DECLARE @username varchar(50) ='brian'
DECLARE @BoID int = 6
DECLARE @datetime datetime = null
DECLARE @Pax int = null
DECLARE @note varchar(MAX) = null
DECLARE @TableID int = 9

exec UpdateBooking 
	@username,
	@BoID,
	@datetime,
	@Pax,
	@note,
	@TableID

	select * from Bookings
	-- Look at bookings
	select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue',uvi.Username 'Venue owner' from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
	
	-- look at availeble tables
	select b.ID,v.Name,vi.TableID,vi.Pax,vi.Status,s.Status,b.Time from VenueItems vi 
						join status s on vi.Status= s.ID	
						join Venues v on vi.VenueID = v.VenueID
						join VenueOwners vo on vo.VenueID = v.VenueID
						join Users u on vo.UserID = u.UserID
						join Bookings b on v.VenueID = b.VenueID
						where b.Time < getdate()-1 and v.Name = 'bar7'



select * from VenueItems 