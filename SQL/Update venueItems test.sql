DECLARE @username varchar(50),
	@VName varchar(20),
	@TableNr int,
	@Pax int,
	@Type varchar(20),
	@tableID int

exec [UpdateVenueItem] @username,@VName,@TableNr,@Pax,@Type,@tableID