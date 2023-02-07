-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian N
-- Create date: @today
-- Description:	Create User
-- =============================================
CREATE PROCEDURE CreateUser 
	-- Add the parameters for the stored procedure here
	@AdminLvl int = 0,
	@firstname varchar(20),
	@lastname varchar(50),
	@username varchar(20) ,
	@email varchar(50),
	@phone int = 0,
	@region nvarchar(50),
	@bday datetime,
	@pass nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @ID int= 0
	IF NOT EXISTS (select username from users where username = @username)
		BEGIN
			IF (select @AdminLvl) = 0
				BEGIN
					INSERT INTO Users(Username,Firstname,Lastname,Email,Phone,Region,Birthday,AdminLevel)
					select @username,@firstname,@lastname,@email,@phone,@region,@bday,@AdminLvl

					set @ID = (select UserID from Users where username = @username)

					INSERT INTO UserLogin(UserID,Username,password)
					select @ID,@username,@pass
				END
			else 

			BEGIN
					INSERT INTO Users(Username,Firstname,Lastname,Email,Phone,Region,Birthday,AdminLevel)
					select @username,@firstname,@lastname,@email,@phone,@region,@bday,@AdminLvl

					set @ID = (select UserID from Users where username = @username)

					INSERT INTO UserLogin(UserID,Username,password)
					select @ID,@username,@pass
				END
			END


END
