USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBooking]    Script Date: 08-02-2023 15:44:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBookingStatus] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@BoID int,
	@Status int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;		
    -- Insert statements for procedure here
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)
	select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue',uvi.Username 'Venue owner' ,s.Status 
	into #oldbooking
	from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
							join status s on b.status = s.ID
							where b.id = @BoID 

	IF (@AdminLvl = 1)
		BEGIN

			UPDATE Bookings
			set status = @Status
			where ID = @BoID
			
			UPDATE VenueItems
			set Status = @Status
			where TableID = (select TableID from bookings where ID = @BoID)
				
	
	select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue',uvi.Username 'Venue owner' ,s.Status 
	into #newbooking
	from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
							join status s on b.status = s.ID
							where b.id = @BoID  
		END
select 'OLD',* from #oldbooking
select 'NEW',* from #newbooking

END


