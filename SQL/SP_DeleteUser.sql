USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 16-02-2023 00:40:44 ******/
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
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (select * from Bookings where UserID = @ID and getdate() < Time)
		begin
			IF EXISTS (select username from users where UserID = @ID)
				BEGIN
					delete from UserLogin where userID = @ID					
					delete from Users where userID = @ID
						select 'Employee have been sucsusfully deleted' result
				END
			ELSE select 'The user do not exist' result
		end
	ELSE select 'This user cannot be deleted, User have an upcoming booking' result

END
