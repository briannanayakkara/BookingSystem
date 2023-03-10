USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBooking]    Script Date: 09-02-2023 14:12:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBooking] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@BoID int,
	@datetime datetime = null,
	@Pax int = null,
	@note varchar(MAX) = null,
	@TableID int = null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	DECLARE @UID int = (select userID from Users where Username = @username)

	IF (@datetime is null)
		begin
			set @datetime = (select Time from bookings where ID = @BoID)
		end
	IF (@Pax is null)
		begin
			set @Pax = (select Pax from bookings where ID = @BoID)
		end
	IF (@note is null)
		begin
			set @note = (select Note from bookings where ID = @BoID)
		end
	IF (@TableID is null)
		begin
			set @TableID = (select TableID from bookings where ID = @BoID)
		 end
    -- Insert statements for procedure here
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)
	
	select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue' 
	into #oldbooking
	from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							where b.id = @BoID 

	IF (@AdminLvl = 1)and(select VenueID from Bookings where ID = @BoID) in (select VenueID from VenueOwners where UserID = @UID)
		BEGIN			

			UPDATE Bookings
			set Time = @datetime,Pax = @Pax,Note = @note,TableID = @TableID
			where ID = @BoID
			
			select b.ID,u.Firstname+' '+u.Lastname 'Full Name',u.Email,u.Phone,b.Pax 'Amount of people',vi.Pax 'Table size',b.Note,b.Time,v.name 'Venue' 
	into #newbooking
	from bookings b 
							join users u on u.UserID = b.UserID 
							join Venues v on b.VenueID = v.VenueID
							join VenueItems vi on b.TableID = vi.TableID
							where b.id = @BoID 
		
select 'OLD',* from #oldbooking
select 'NEW',* from #newbooking
END
else select 'No admin'
END


