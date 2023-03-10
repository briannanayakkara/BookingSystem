USE [BookingSystem]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 14-02-2023 03:33:42 ******/
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
	@AdminLvl varchar(2) = null,
	@firstname varchar(20) = null,
	@lastname varchar(50) = null,
	@username varchar(20)= null ,
	@email varchar(50)= null,
	@phone int = null,
	@region nvarchar(50)= null,
	@bday datetime = null,
	@pass nvarchar(MAX) = null,
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (isnull(@AdminLvl,'') = '')
		begin
			set @AdminLvl = (select AdminLevel from users where UserID = @ID)
		end
	IF (isnull(@firstname,'') = '')
		begin
			set @firstname = (select Firstname from users where UserID = @ID)
		end
	IF (isnull(@lastname,'') = '')
		begin
			set @lastname = (select Lastname from users where UserID = @ID)
		end
	IF (isnull(@username,'') = '')
		begin
			set @username = (select Username from Users where UserID = @ID)
		end
	IF (isnull(@email,'') = '')
		begin
			set @email = (select Email from Users where UserID = @ID)
		end
	IF (@phone is null) or (@phone = '')
		begin
			set @phone = (select Phone from Users where UserID = @ID)
		end
	IF (isnull(@region,'') = '')
		begin
			set @region = (select Region from Users where UserID = @ID)
		end
	IF (isnull(@bday,'') = '')
		begin
			set @bday = (select Birthday from Users where UserID = @ID)
		end
	IF (isnull(@pass,'') = '')
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
			set password = @pass,
			Username = @username
			where UserID = @ID
					
		END
		
	SELECT * FROM Users WHERE UserID = @ID


END
