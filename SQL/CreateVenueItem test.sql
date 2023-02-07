exec [CreateVenueItem] 
	-- Add the parameters for the stored procedure here
	@username ='brian',
	@VName ='bar8',
	@TableNr = 6,
	@Pax = 10,
	@Type = 'Dance Floor'

	select * from VenueItems

	select Firstname +' '+ Lastname as 'Full name', v.Name as 'Venue name', vi.TableID,vi.Pax,vi.TableType from Venues v join  VenueItems vi on vi.VenueID = v.VenueID join VenueOwners vo on vo.VenueID = v.VenueID
									join Users u on u.UserID = vo.UserID
								


