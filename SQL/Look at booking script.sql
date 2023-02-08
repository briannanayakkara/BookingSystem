USE BookingSystem

select b.ID,v.Name,vi.TableID,vi.Pax,vi.Status,s.Status,b.Time from VenueItems vi 
						join status s on vi.Status= s.ID	
						join Venues v on vi.VenueID = v.VenueID
						join VenueOwners vo on vo.VenueID = v.VenueID
						join Users u on vo.UserID = u.UserID
						join Bookings b on v.VenueID = b.VenueID
						where b.Time < getdate()-1
						--join bookings b on b.VenueID = v.VenueID

					
	select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue',uvi.Username 'Venue owner' ,s.Status from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
							join status s on b.status = s.ID
							
				
						

						select * from Bookings
						select * from Users
						select * from Venues
						select * from VenueItems

						select * from status

						/*update VenueItems 
						set Status = 2
						where tableid = 1*/

						select vi.TableID,s.status from VenueItems vi join status s on s.ID = vi.Status  
						