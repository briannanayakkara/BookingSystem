USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 13-02-2023 20:06:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
ALTER PROCEDURE [dbo].[UpdateUser] 
	-- Add the parameters for the stored procedure here
	@AdminLvl int = null,
	@firstname varchar(20) = null,
	@lastname varchar(50) = null,
	@username varchar(20)= null ,
	@email varchar(50)= null,
	@phone int = null,
	@region nvarchar(50)= null,
	@bday datetime = null,
	@pass nvarchar(50) = null,
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@AdminLvl is null)
		begin
			set @AdminLvl = (select AdminLevel from users where UserID = @ID)
		end
	IF (@firstname is null)
		begin
			set @firstname = (select Firstname from users where UserID = @ID)
		end
	IF (@lastname is null)
		begin
			set @lastname = (select Lastname from users where UserID = @ID)
		end
	IF (@username is null)
		begin
			set @username = (select Username from Users where UserID = @ID)
		end
	IF (@email is null)
		begin
			set @email = (select Email from Users where UserID = @ID)
		end
	IF (@phone is null)
		begin
			set @phone = (select Phone from Users where UserID = @ID)
		end
	IF (@region is null)
		begin
			set @region = (select Region from Users where UserID = @ID)
		end
	IF (@bday is null)
		begin
			set @bday = (select Birthday from Users where UserID = @ID)
		end
	IF (@pass is null)
		begin
			set @pass = (select password from UserLogin where UserID = @ID)
		end
		

	IF EXISTS (select * from users where UserID = @ID)
		BEGIN
			update Users  		
			set Username= @username,
				firstname = @firstname,
				lastname = @lastname,
				Email = @email,
				Phone = @phone,
				Region = @region,
				Birthday = @bday,
				AdminLevel = @AdminLvl
			where UserID = @ID

			update UserLogin
			set password = @pass
			where UserID = @ID
					
		END


END
