

select v.Name,vi.TableID,vi.Pax,vi.Status from VenueItems vi join status s on vi.Status= s.ID	
						join Venues v on vi.VenueID = v.VenueID
						join VenueOwners vo on vo.VenueID = v.VenueID
						join Users u on vo.UserID = u.UserID
						--join bookings b on b.VenueID = v.VenueID







						
select u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue' from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							
							
						

						select * from Bookings
						select * from Users
						select * from Venues
						select * from VenueItems

						select * from status