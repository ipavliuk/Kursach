USE [RentApartments]
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1915,
		@PropertyListingId = 2,
		@ReservationStatus = 0,
		@ReservationStart = N'01/02/2015',
		@ReservationEnd = N'03/02/2015',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1917,
		@PropertyListingId = 5,
		@ReservationStatus = 0,
		@ReservationStart = N'05/02/2015 00:00:00',
		@ReservationEnd = N'06/02/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5
SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1916,
		@PropertyListingId = 4,
		@ReservationStatus = 0,
		@ReservationStart = N'01/20/2015 00:00:00',
		@ReservationEnd = N'01/25/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5
SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1918,
		@PropertyListingId = 6,
		@ReservationStatus = 0,
		@ReservationStart = N'12/20/2015 00:00:00',
		@ReservationEnd = N'12/25/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1918,
		@PropertyListingId = 7,
		@ReservationStatus = 0,
		@ReservationStart = N'01/20/2015 00:00:00',
		@ReservationEnd = N'01/25/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1919,
		@PropertyListingId = 6,
		@ReservationStatus = 0,
		@ReservationStart = N'01/25/2015 00:00:00',
		@ReservationEnd = N'01/28/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO


----------------------------------------
DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1919,
		@PropertyListingId = 2,
		@ReservationStatus = 0,
		@ReservationStart = N'03/02/2015',
		@ReservationEnd = N'03/22/2015',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1918,
		@PropertyListingId = 3,
		@ReservationStatus = 0,
		@ReservationStart = N'09/10/2015 00:00:00',
		@ReservationEnd = N'09/25/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5
SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1917,
		@PropertyListingId = 4,
		@ReservationStatus = 0,
		@ReservationStart = N'10/20/2015 00:00:00',
		@ReservationEnd = N'10/25/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5
SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1918,
		@PropertyListingId = 5,
		@ReservationStatus = 0,
		@ReservationStart = N'12/20/2014 00:00:00',
		@ReservationEnd = N'12/25/2014 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1918,
		@PropertyListingId = 6,
		@ReservationStatus = 0,
		@ReservationStart = N'03/07/2015 00:00:00',
		@ReservationEnd = N'03/10/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1919,
		@PropertyListingId = 6,
		@ReservationStatus = 0,
		@ReservationStart = N'01/25/2015 00:00:00',
		@ReservationEnd = N'01/28/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[ReservationsCreate]
		@AccountId = 1919,
		@PropertyListingId = 7,
		@ReservationStatus = 0,
		@ReservationStart = N'08/25/2015 00:00:00',
		@ReservationEnd = N'08/28/2015 00:00:00',
		@reservationNote = N'-',
		@CurrencyId = 5

SELECT	'Return Value' = @return_value

GO