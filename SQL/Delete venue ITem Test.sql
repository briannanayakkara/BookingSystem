declare @username varchar(50)='brian',
		@VName varchar(20)='bar1',
		@tableID int = 9
exec [DeleteVenueItem] @username,@VName,@tableID

select * from VenueItems
