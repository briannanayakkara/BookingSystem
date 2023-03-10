USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[UpdateVenue]    Script Date: 17-02-2023 01:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
ALTER PROCEDURE [dbo].[UpdateVenue] 
	@username varchar(50),
	@Name varchar(20),
	@Limit int,
	@EmployeeQty int,
	@region nvarchar(50),
	@type varchar(50),
	@cvr varchar(50),
	@VenueName varchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @venueID int = (select VenueID from Venues where name = @VenueName)
	DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	IF EXISTS (select * from Venues v join VenueOwners vo on vo.VenueID = v.VenueID where v.VenueID = @venueID and vo.UserID = @UserID)
		BEGIN	
			IF  (@Name = @VenueName) or not exists (select * from Venues v where Name = @Name)
				begin 
				update Venues
				set Name = @Name,Limit =@Limit,EmployeeQty = @EmployeeQty,Type = @type,CVR = @cvr,Region = @region	
				where VenueID = @venueID
				select * from Venues where VenueID = @venueID
				END
				else select 'Venue name is taken'
			END
			else 
			BEGIN
					Select 'Admin requred!'
				END
			END

