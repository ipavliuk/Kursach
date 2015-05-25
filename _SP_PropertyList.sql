use [RentApartments]
Go

create procedure dbo.PropertyListingCreate
	@O_ErrCode						INT					OUTPUT,
	@O_ErrMsg						NVARCHAR(4000)		OUTPUT,
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
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

		----------------------------------- Parameters Validation -------------------------------------------
		
		IF @AccountId IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@AccountId cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END	
		IF @Country IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@Country cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END	

		INSERT INTO PropertyListing(FK_Account, State, PricePerNight, PricePerMonth, PricePerWeek, Photos, GreatTitle, GreatSummary, BedRoom, Bathroom, HomeType, RoomType, Accommodates, Address1, Address2, City, State2, Zip, FK__Country) 
		VALUES (@AccountId, @State, @PricePerNight, @PricePerMonth, @PricePerWeek, @Photos, @GreatTitle, @GreatSummary, @BedRoom, @Bathroom, @HomeType, @RoomType, @Accommodates, @Address1, @Address2, @City, @State2, @Zip, @Country);
	end try
	begin catch
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	end catch
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
	@O_ErrCode						INT					OUTPUT,
	@O_ErrMsg						NVARCHAR(4000)		OUTPUT,
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
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

		----------------------------------- Parameters Validation -------------------------------------------
		
		IF @PropertyId IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@PropertyId cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END
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
	end try
	begin catch
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	end catch
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
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
					,@O_ErrMsg	= ''

		IF @PropertyId IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@PropertyId cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END

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
	end try
	begin catch
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	end catch
end
GO
--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[PropertyListingGetByPropertyId]
--		@PropertyId = 1
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------

alter procedure dbo.PropertyListingGetByCity
	@O_ErrCode						INT					OUTPUT,
	@O_ErrMsg						NVARCHAR(4000)		OUTPUT,
	@City varchar(20)
as
begin
	set nocount on;
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
					,@O_ErrMsg	= ''

		SELECT [PropertyId]
		  ,Account.id as AccountId
		  ,Account.FirstName as FirstName
		  ,Account.LastName as LastName
		  ,Account.Address
		  ,Account.Email
		  ,State
		  ,PricePerNight
		  ,PricePerMonth
		  ,PricePerWeek
		  ,Photos
		  ,GreatTitle
		  ,GreatSummary
		  ,BedRoom
		  ,Bathroom
		  ,HomeType
		  ,RoomType
		  ,Accommodates
		  ,Address1
		  ,Address2
		  ,PropertyListing.City
		  ,State2
		  ,Zip
		  ,PropertyListing.FK__Country
	  FROM [RentApartments].[dbo].[PropertyListing]
	  inner join Account on Account.id = FK_Account
	  where PropertyListing.City = @City	
	end try
	begin catch
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	end catch
end
GO

----------------------------------------------------------------
create procedure dbo.PropertyListingGetByAccountId
	@AccId int
as
begin
	set nocount on;
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

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
	end try
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
	@O_ErrCode						INT					OUTPUT,
	@O_ErrMsg						NVARCHAR(4000)		OUTPUT,
	@PropertyId int
AS
begin
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

		----------------------------------- Parameters Validation -------------------------------------------
		
		IF @PropertyId IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@PropertyId cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END

		BEGIN TRANSACTION
			DELETE FROM PropertyListing
			WHERE PropertyId = @PropertyId

			 -- Rollback the transaction if there were any errors
			IF @@ERROR <> 0
			 BEGIN
				-- Rollback the transaction
				ROLLBACK

				-- Raise an error and return
				RAISERROR ('Error in deleting Apartment in PropertyListing.', 16, 1)
				RETURN
			 END

			 --Delete all reservation
			DELETE FROM Reservations
			WHERE FK_PropertyListing = @PropertyId

			-- Rollback the transaction if there were any errors
			IF @@ERROR <> 0
			 BEGIN
				-- Rollback the transaction
				ROLLBACK

				-- Raise an error and return
				RAISERROR ('Error in deleting reservations in Reservations.', 16, 1)
				RETURN
			 END
		--         Commit the transaction....
		COMMIT
	end try
	begin catch
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	end catch
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
