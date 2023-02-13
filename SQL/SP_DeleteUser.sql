USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 14-02-2023 00:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
ALTER PROCEDURE [dbo].[DeleteUser] 
	-- Add the parameters for the stored procedure here
	@AdminLvl int = 0,
	@ID int,
	@pass nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	IF EXISTS (select username from users where UserID = @ID)
		BEGIN
			delete from UserLogin where userID = @ID					
			delete from Users where userID = @ID
				
		END


END
