DECLARE @username varchar(50),
	@VName varchar(20),
	@TableNr int,
	@Pax int,
	@Type varchar(20)

exec [CreateVenueItem] @username,@VName,@TableNr,@Pax,@Type

	select * from VenueItems

	select Firstname +' '+ Lastname as 'Full name', v.Name as 'Venue name', vi.TableID,vi.Pax,vi.TableType from Venues v join  VenueItems vi on vi.VenueID = v.VenueID join VenueOwners vo on vo.VenueID = v.VenueID
									join Users u on u.UserID = vo.UserID
								


