USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[DeleteVenueItem]    Script Date: 17-02-2023 01:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
ALTER PROCEDURE [dbo].[DeleteVenueItem] 
	@username varchar(50),
	@VName varchar(20),
	@tableID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @VenueID int= (select v.VenueID from Venues v join VenueOwners vo on v.VenueID = vo.VenueID 
													join Users u on vo.UserID = u.UserID 
													where v.Name = @VName and vo.UserID = @UserID)

	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	IF EXISTS (select * from VenueItems vi 
					join Venues v on vi.VenueID = v.VenueID 
					join VenueOwners vo on vo.VenueID = v.VenueID
					where vo.UserID = @UserID and v.VenueID = @VenueID and vi.TableID = @tableID) 
			BEGIN
				IF NOT EXISTS (select * from Bookings where TableID = @tableID and Time > GETDATE())
				begin
					delete VenueItems
					where TableID = @tableID
				end
				else 
			BEGIN
					Select 'Venue item cannot be deleted because there is a booking ahead'
				END
			END
			else select 'no item availeble'
			
	select * from VenueItems

			END

