USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[CreateVenue]    Script Date: 02-02-2023 15:37:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[CreateVenue] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@Name varchar(20),
	@Limit int,
	@EmployeeQty int,
	@region nvarchar(50),
	@type varchar(50),
	@cvr varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @UserID int = (select UserID from Users where username = @username)

	DECLARE @VenueID int= 0
	DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

	IF NOT EXISTS (select * from Venues v join VenueOwners vo on vo.VenueID = v.VenueID where Name = @Name)
		BEGIN
			IF (select @AdminLvl) = 1
				BEGIN
					INSERT INTO Venues(Name,Limit,EmployeeQty,Region,Type,CVR)
					select @Name,@Limit,@EmployeeQty,@region,@type,@cvr

					set @VenueID = (select VenueID from Venues where Name = @Name)

					INSERT INTO VenueOwners(UserID,VenueID)
					select @UserID,@VenueID
				END
			else 

			BEGIN
					Select 'Admin requred!'
				END
			END


END
