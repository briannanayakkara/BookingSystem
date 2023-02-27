DECLARE @username varchar(50)='brian',
	@VName varchar(20)='bar1',
	@Fdate date='2022-02-09',
	@Tdate date ='2025-02-09',
	@statusID int = 11

exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,@statusID

exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,1
exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,2
exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,11
exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,22


