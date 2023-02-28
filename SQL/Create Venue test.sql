use BookingSystem	

exec CreateVenue 				
				@username = 'brian',
				@Name ='bar5',
				@Limit = 50,
				@EmployeeQty = '5',
				@region ='cph',
				@type ='Cocktail bar',
				@cvr ='DK 52 52 52'

exec CreateVenue @username,@Name,@Limit,@EmployeeQty,@region,@type,@cvr


select * from venues
select * from VenueOwners