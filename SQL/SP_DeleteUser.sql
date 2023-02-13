USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 13-02-2023 20:10:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser] 
	-- Add the parameters for the stored procedure here
	@AdminLvl int = 0,
	@ID int,
	@pass nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	IF EXISTS (select username from users where UserID = @ID)
		BEGIN
			
			IF (@AdminLvl = 2)
				BEGIN
					delete from Users where userID = @ID
					delete from UserLogin where userID = @ID
				END					
		END


END
