USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetBookings]    Script Date: 16-02-2023 19:57:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
ALTER PROCEDURE [dbo].[GetBookings] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@VName varchar(20),
	@date date null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @UserID int = (select UserID from Users where username = @username)
	DECLARE @VenueID int= (select VenueID from Venues where Name = @VName)

	IF exists (select * from VenueOwners vo 
				join Bookings b on vo.VenueID = b.VenueID  
				where vo.VenueID = @VenueID and vo.UserID = @UserID)
		BEGIN
		if(isnull(@date,'') != '')
			begin
			select b.ID,u.Firstname+' '+u.Lastname as 'fullname',u.Email,u.Phone,b.Pax as pax,vi.Pax as'tableSize', vi.TableNr,b.Note,
						b.Time ,v.name 'Venue',uvi.Firstname+' '+uvi.Lastname as 'venueOwner' ,s.Status from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
							join status s on b.status = s.ID
							where v.VenueID = @VenueID and convert(date,b.time,111) = @date
			end
			else 
			begin
			select b.ID,u.Firstname+' '+u.Lastname as 'fullname',u.Email,u.Phone,b.Pax as pax,vi.Pax as'tableSize', vi.TableNr,b.Note,
						b.Time ,v.name 'Venue',uvi.Firstname+' '+uvi.Lastname as 'venueOwner' ,s.Status from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							join VenueOwners vo on v.VenueID = vo.VenueID
							join Users uvi on vo.UserID = uvi.UserID
							join status s on b.status = s.ID
							where v.VenueID = @VenueID
							end
		END
		else select 'No bookings availeble'

END


