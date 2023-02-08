DECLARE @username varchar(50) = 'brian'
DECLARE @BoID int =  3
DECLARE @Status int = 11

exec UpdateBookingStatus
	@username, 
	@BoID,
	@Status

	select * from Bookings
		select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue',uvi.Username 'Venue owner' ,s.Status from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
							join status s on b.status = s.ID