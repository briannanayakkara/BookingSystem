
DECLARE @AdminLvl int = 0,
	@ID int,
	@pass nvarchar(50)

exec DeleteUser 
	-- Add the parameters for the stored procedure here
	@AdminLvl,
	@ID,
	@pass

	select * from Users
	select * from UserLogin