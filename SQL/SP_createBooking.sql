USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[CreateBooking]    Script Date: 09-02-2023 13:54:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[CreateBooking] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@VName varchar(20),
	@datetime datetime,
	@Pax int,
	@note varchar(MAX)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @VenueID int= (select VenueID from Venues where Name = @VName)
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	-- selecting tableID

	DECLARE @tbID int = (select top 1 vi.TableID from VenueItems vi 
							where vi.VenueID = @VenueID 
									and vi.Pax >= @Pax 
									and vi.TableID not in (select TableID from Bookings where cast(Time as date) >=  cast(@datetime as date))
									order by vi.Pax)

	IF NOT EXISTS (select * from Bookings where UserID = @UserID and VenueID = @VenueID 
					and cast(Time as date) >= cast(@datetime as date))-- AND TableID = @tbID) 
					and @tbID is not null
					and @datetime > dateadd(hh,+5,getdate())
		BEGIN
			IF @VenueID is not null 
				BEGIN
					INSERT INTO Bookings(UserID,VenueID,Time,Pax,Note,TableID,status)
					select @UserID,@VenueID,@datetime,@Pax,@note,@tbID,2

				END
		END

		else select 'Booking unavaileble contact the venue '+ (select convert(varchar(50),phone) from Users u 
			join VenueOwners vo on u.UserID = vo.UserID 
			where u.AdminLevel =1 and vo.VenueID = @VenueID) 

END


