USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBooking]    Script Date: 09-02-2023 13:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBooking] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@BoID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here	
	DECLARE @UID int = (select userID from Users where Username = @username)
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)
	DECLARE @time datetime = (select CURRENT_TIMESTAMP)
	IF (@AdminLvl = 1 and (select VenueID from Bookings where ID = @BoID) in (select VenueID from VenueOwners where UserID = @UID))
		BEGIN
			insert into deletebookinglog(ID,UserID,VenueID,Time,Pax,Note,TableID,status,deletedtime)
			select ID,UserID,VenueID,Time,Pax,Note,TableID,status, @time from Bookings where ID = @BoID		
			delete Bookings where ID = @BoID
								
		END
		
END


