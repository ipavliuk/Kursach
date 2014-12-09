use [RentApartments]
Go

create procedure dbo.PropertyListingCreate
	@AccountId int,
	@State tinyint, 
	@PricePerNight bigint = NULL,
	@PricePerMonth bigint = NULL,
	@PricePerWeek bigint = NULL, 
	@Photos nvarchar(2000) = NULL, 
	@GreatTitle nvarchar(40) = NULL, 
	@GreatSummary nvarchar(255) = NULL, 
	@BedRoom tinyint, 
	@Bathroom int, 
	@HomeType tinyint, 
	@RoomType tinyint, 
	@Accommodates tinyint,
	@Address1 nvarchar(50) = NULL,
	@Address2 nvarchar(50) = NULL, 
	@City nvarchar(20) = NULL, 
	@State2 nvarchar(255) = NULL, 
	@Zip nvarchar(10) = NULL, 
	@Country int 
as
begin	
	INSERT INTO PropertyListing(FK_Account, State, PricePerNight, PricePerMonth, PricePerWeek, Photos, GreatTitle, GreatSummary, BedRoom, Bathroom, HomeType, RoomType, Accommodates, Address1, Address2, City, State2, Zip, FK__Country) 
	VALUES (@AccountId, @State, @PricePerNight, @PricePerMonth, @PricePerWeek, @Photos, @GreatTitle, @GreatSummary, @BedRoom, @Bathroom, @HomeType, @RoomType, @Accommodates, @Address1, @Address2, @City, @State2, @Zip, @Country);
end
GO

--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[PropertyListingCreate]
--		@AccountId = 2,
--		@State = 1,
--		@PricePerNight = 200,
--		@BedRoom = 1,
--		@Bathroom = 2,
--		@HomeType = 2,
--		@RoomType = 3,
--		@Accommodates = 3,
--		@Address1 = N'ssdfdsf',
--		@Country = 2

--SELECT	'Return Value' = @return_value
--GO
--select * from PropertyListing

----------------------------------------------------------------

----------------------------------------------------------------
create procedure dbo.PropertyListingUpdate
	@PropertyId int,
	@State tinyint = null, 
	@PricePerNight bigint = NULL,
	@PricePerMonth bigint = NULL,
	@PricePerWeek bigint = NULL, 
	@Photos nvarchar(2000) = NULL, 
	@GreatTitle nvarchar(40) = NULL, 
	@GreatSummary nvarchar(255) = NULL, 
	@BedRoom tinyint = NULL, 
	@Bathroom int = NULL, 
	@HomeType tinyint = NULL, 
	@RoomType tinyint = NULL, 
	@Accommodates tinyint = NULL,
	@Address1 nvarchar(50) = NULL,
	@Address2 nvarchar(50) = NULL, 
	@City nvarchar(20) = NULL, 
	@State2 nvarchar(255) = NULL, 
	@Zip nvarchar(10) = NULL, 
	@Country int = NULL 
as
begin	
	--SET NOCOUNT ON;
	update PropertyListing
	set	State = ISNULL(@State,State), 
		PricePerNight = ISNULL(@PricePerNight, PricePerNight),
		PricePerMonth = ISNULL(@PricePerMonth,PricePerMonth),
		PricePerWeek = ISNULL(@PricePerWeek,PricePerWeek), 
		Photos = ISNULL(@Photos,Photos), 
		GreatTitle = ISNULL(@GreatTitle,GreatTitle), 
		GreatSummary = ISNULL(@GreatSummary,GreatSummary), 
		BedRoom = ISNULL(@BedRoom,BedRoom), 
		Bathroom = ISNULL(@Bathroom,Bathroom), 
		HomeType = ISNULL(@HomeType,HomeType), 
		RoomType = ISNULL(@RoomType,RoomType), 
		Accommodates = ISNULL(@Accommodates,Accommodates),
		Address1 = ISNULL(@Address1,Address1),
		Address2 = ISNULL(@Address2,Address2), 
		City = ISNULL(@City,City), 
		State2 = ISNULL(@State2,State2), 
		Zip = ISNULL(@Zip,Zip), 
		FK__Country = ISNULL(@Country,FK__Country) 
	where PropertyId = @PropertyId
end
GO
---Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[PropertyListingUpdate]
--		@PropertyId = 1,
--		@PricePerNight = 200,
--		@PricePerMonth = 1200
--SELECT	'Return Value' = @return_value
--GO
--select * from PropertyListing
--GO
----------------------------------------------------------------

----------------------------------------------------------------
create procedure dbo.PropertyListingGetAll
as
begin
	set nocount on;
	SELECT [PropertyId]
      ,[FK_Account]
      ,[State]
      ,[PricePerNight]
      ,[PricePerMonth]
      ,[PricePerWeek]
      ,[Photos]
      ,[GreatTitle]
      ,[GreatSummary]
      ,[BedRoom]
      ,[Bathroom]
      ,[HomeType]
      ,[RoomType]
      ,[Accommodates]
      ,[Address1]
      ,[Address2]
      ,[City]
      ,[State2]
      ,[Zip]
      ,[FK__Country]
  FROM [RentApartments].[dbo].[PropertyListing]
end
GO

--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[PropertyListingGetAll]
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
create procedure dbo.PropertyListingGetByPropertyId
	@PropertyId int
as
begin
	set nocount on;
	SELECT [PropertyId]
	  ,[FK_Account]
      ,[State]
      ,[PricePerNight]
      ,[PricePerMonth]
      ,[PricePerWeek]
      ,[Photos]
      ,[GreatTitle]
      ,[GreatSummary]
      ,[BedRoom]
      ,[Bathroom]
      ,[HomeType]
      ,[RoomType]
      ,[Accommodates]
      ,[Address1]
      ,[Address2]
      ,[City]
      ,[State2]
      ,[Zip]
      ,[FK__Country]
  FROM [RentApartments].[dbo].[PropertyListing]
  where PropertyId = @PropertyId
end
GO
--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[PropertyListingGetByPropertyId]
--		@PropertyId = 1
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
----------------------------------------------------------------
create procedure dbo.PropertyListingGetByAccountId
	@AccId int
as
begin
	set nocount on;
	SELECT [PropertyId]
	  ,[FK_Account]
      ,[State]
      ,[PricePerNight]
      ,[PricePerMonth]
      ,[PricePerWeek]
      ,[Photos]
      ,[GreatTitle]
      ,[GreatSummary]
      ,[BedRoom]
      ,[Bathroom]
      ,[HomeType]
      ,[RoomType]
      ,[Accommodates]
      ,[Address1]
      ,[Address2]
      ,[City]
      ,[State2]
      ,[Zip]
      ,[FK__Country]
  FROM [RentApartments].[dbo].[PropertyListing]
  where FK_Account = @AccId
end
GO
----EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[PropertyListingGetByAccountId]
--		@AccId = 2
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
----------------------------------------------------------------
------Delete
CREATE PROCEDURE dbo.PropertyListingDelete
	@PropertyId int
AS
begin
	DELETE FROM PropertyListing
	 WHERE PropertyId = @PropertyId
end
go

--Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].PropertyListingDelete
--		@PropertyId = 1
--SELECT	'Return Value' = @return_value
--GO
--select * from PropertyListing;
----------------------------------------------------------------
