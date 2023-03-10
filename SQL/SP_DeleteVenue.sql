USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[DeleteVenue]    Script Date: 17-02-2023 01:13:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
ALTER PROCEDURE [dbo].[DeleteVenue] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@venuename varchar (10)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @VenueID int= (select VenueID from Venues where Name = @venuename)
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	IF EXISTS (select * from Venues v join VenueOwners vo on vo.VenueID = v.VenueID where vo.UserID = @UserID and vo.VenueID = @VenueID)
		BEGIN
			IF NOT EXISTS (select * from bookings where VenueID = @VenueID and Time > getdate())
				BEGIN
					DELETE from VenueItems where VenueID = @VenueID	
					DELETE from VenueOwners where VenueID = @VenueID
					DELETE from Venues where VenueID = @VenueID

				END
			else 

			BEGIN
					Select 'Booking in pending, Cannot delete the venue'
				END
			END


END
