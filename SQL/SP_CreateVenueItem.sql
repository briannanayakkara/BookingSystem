USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[CreateVenueItem]    Script Date: 03-02-2023 00:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[CreateVenueItem] 
	-- Add the parameters for the stored procedure here
	@username varchar(50),
	@VName varchar(20),
	@TableNr int,
	@Pax int,
	@Type varchar(20)

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

	IF NOT EXISTS (	select * from VenueItems vi join Venues v on vi.VenueID = v.VenueID where vi.TableNr = @TableNr and v.VenueID = @VenueID)
		BEGIN
			IF (select @AdminLvl) = 1 and @VenueID is not null
				BEGIN
					INSERT INTO VenueItems(VenueID,TableNr,Pax,TableType)
					select @VenueID,@TableNr,@Pax,@Type
				
				END
			else 

			BEGIN
					Select 'invalid enrty'
				END
			END

select * from VenueItems
END
