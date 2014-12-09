use [RentApartments]
Go

create procedure dbo.ReservationsCreate
	  @AccountId         int, 
	  @PropertyListingId int, 
	  @ReservationStatus  int, 
	  @ReservationStart   datetime, 
	  @ReservationEnd     datetime, 
	  @ReservationNote    nvarchar(255), 
	  @CurrencyId       int
as
begin	
	INSERT INTO Reservations(FK_Account, FK_PropertyListing, ReservationStatus, ReservationStart, ReservationEnd, ReservationNote, FK__Currency) 
	VALUES (@AccountId, @PropertyListingId, @ReservationStatus, @ReservationStart, @ReservationEnd, @ReservationNote, @CurrencyId);
end
GO
--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsCreate]
--		@AccountId = 2,
--		@PropertyListingId = 2,
--		@ReservationStatus = 0,
--		@ReservationStart = N'012/12/2014',
--		@ReservationEnd = N'012/15/2014',
--		@ReservationNote = N'This is the test reservation',
--		@CurrencyId = 1
--SELECT	'Return Value' = @return_value
--GO
--select * from Reservations
--select * from PropertyListing
--GO

----------------------------------------------------------------

----------------------------------------------------------------
create procedure dbo.ReservationsUpdate
	@ReservationId		int,
	@PropertyListingId	int = null, 
	@ReservationStatus  int = null, 
	@ReservationStart   datetime = null, 
	@ReservationEnd     datetime = null, 
	@ReservationNote    nvarchar(255) = null, 
	@CurrencyId			int = null
as
begin	
	--SET NOCOUNT ON;
	update Reservations
	set	FK_PropertyListing = ISNULL(@PropertyListingId,FK_PropertyListing), 
		ReservationStatus = ISNULL(@ReservationStatus,ReservationStatus), 
		ReservationStart = ISNULL(@ReservationStart,ReservationStart),  
		ReservationEnd = ISNULL(@ReservationEnd,ReservationEnd),  
		ReservationNote = ISNULL(@ReservationNote,ReservationNote),  
		FK__Currency = ISNULL(@CurrencyId, FK__Currency)
	where ReservationId = @ReservationId
end
GO
----Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsUpdate]
--		@ReservationId = 3,
--		@ReservationStatus = 1,
--		@ReservationNote = N'this the updated'
--SELECT	'Return Value' = @return_value

--GO
--select * from Reservations
--GO
----------------------------------------------------------------

----------------------------------------------------------------
create procedure dbo.ReservationsGetAll
as
begin
	set nocount on;
	  select [ReservationId]
      ,[FK_Account]
      ,[FK_PropertyListing]
      ,[ReservationStatus]
      ,[ReservationStart]
      ,[ReservationEnd]
      ,[ReservationNote]
      ,[FK__Currency]
  FROM [RentApartments].[dbo].[Reservations]
end
GO
----EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsGetAll]
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
create procedure dbo.ReservationsGetByAccId
	@AccId int
as
begin
	set nocount on;
 select [ReservationId]
      ,[FK_Account]
      ,[FK_PropertyListing]
      ,[ReservationStatus]
      ,[ReservationStart]
      ,[ReservationEnd]
      ,[ReservationNote]
      ,[FK__Currency]
  FROM [RentApartments].[dbo].[Reservations]
  where FK_Account = @AccId
end
GO
-----EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsGetByAccId]
--		@AccId = 2
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
----------------------------------------------------------------
create procedure dbo.ReservationsGetByPropertyId
	@PropertyId int
as
begin
	set nocount on;
 select [ReservationId]
      ,[FK_Account]
      ,[FK_PropertyListing]
      ,[ReservationStatus]
      ,[ReservationStart]
      ,[ReservationEnd]
      ,[ReservationNote]
      ,[FK__Currency]
  FROM [RentApartments].[dbo].[Reservations]
  where FK_PropertyListing = @PropertyId
end
GO
----EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsGetByPropertyId]
--		@PropertyId = 2
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
----------------------------------------------------------------
create procedure dbo.ReservationsGetById
	@ReservationId int
as
begin
	set nocount on;
 select [ReservationId]
      ,[FK_Account]
      ,[FK_PropertyListing]
      ,[ReservationStatus]
      ,[ReservationStart]
      ,[ReservationEnd]
      ,[ReservationNote]
      ,[FK__Currency]
  FROM [RentApartments].[dbo].[Reservations]
  where ReservationId = @ReservationId
end
GO
----EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsGetById]
--		@ReservationId = 3
--SELECT	'Return Value' = @return_value
--GO
----------------------------------------------------------------
----------------------------------------------------------------
------Delete
CREATE PROCEDURE dbo.ReservationsDelete
	@ReservationId int
AS
begin
	DELETE FROM Reservations
	 WHERE ReservationId = @ReservationId
end
go

--Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[ReservationsDelete]
--		@ReservationId = 3
--SELECT	'Return Value' = @return_value
--GO
--select * from Reservations;
----------------------------------------------------------------
