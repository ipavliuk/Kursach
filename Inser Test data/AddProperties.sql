USE [RentApartments]
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[PropertyListingCreate]
		@AccountId = 1912,
		@State = 0,
		@PricePerNight = 20,
		@PricePerWeek = 100,
		@Photos = N'"img/appartment1"',
		@GreatTitle = N'квартира в центрі міста',
		@GreatSummary = N'2х кімнатна квартира в центрі міста з виглядом на ,,,,',
		@BedRoom = 2,
		@Bathroom = 1,
		@RoomType = 1,
		@HomeType = 1,
		@Accommodates = 4,
		@Address1 = N'вул. Костюшки 5',
		@City = N'Львів',
		@Zip = N'79000',
		@State2 = N'Львівська область',
		@Country = 184

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[PropertyListingCreate]
		@AccountId = 1912, -- user1 from account
		@State = 1,
		@PricePerNight = 25,
		@PricePerWeek = 140,
		@PricePerMonth = 2500,
		@Photos = N'"img/appartment2"',
		@GreatTitle = N'квартира 3x',
		@GreatSummary = N'3х кімнатна квартира в центрі міста з ,,,,',
		@BedRoom = 3,
		@Bathroom = 2,
		@RoomType = 1,
		@HomeType = 1,
		@Accommodates = 6,
		@Address1 = N'вул. Дорошенка 20',
		@City = N'Львів',
		@Zip = N'79000',
		@State2 = N'Львівська область',
		@Country = 184

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[PropertyListingCreate]
		@AccountId = 1913, -- user2 from account
		@State = 0,
		@PricePerNight = 50,
		@PricePerWeek = 300,
		@PricePerMonth = 4000,
		@Photos = N'"img/appartment1"',
		@GreatTitle = N'квартира 3x',
		@GreatSummary = N'3х кімнатна квартира в центрі міста з ,,,,',
		@BedRoom = 4,
		@Bathroom = 2,
		@RoomType = 1,
		@HomeType = 2,
		@Accommodates = 8,
		@Address1 = N'вул. Дорошенка 20',
		@City = N'Львів',
		@Zip = N'79000',
		@State2 = N'Львівська область',
		@Country = 184

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[PropertyListingCreate]
		@AccountId = 1914, -- user2 from account
		@State = 1,
		@PricePerNight = 23,
		@PricePerWeek = 100,
		@PricePerMonth = 2000,
		@Photos = N'"img/appartment1"',
		@GreatTitle = N'частина будинку ',
		@GreatSummary = N'2 кімнати в частині будинку і районі ,,,,',
		@BedRoom = 2,
		@Bathroom = 1,
		@RoomType = 2,
		@HomeType = 3,
		@Accommodates = 4,
		@Address1 = N'вул. Келецька 70/43',
		@City = N'Вінниця',
		@Zip = N'21000',
		@State2 = N'Вінницька область',
		@Country = 184

SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[PropertyListingCreate]
		@AccountId = 1914, -- user2 from account
		@State = 0,
		@PricePerNight = 15,
		@PricePerWeek = 70,
		@PricePerMonth = 1500,
		@Photos = N'"img/appartment2"',
		@GreatTitle = N'1 кімнатна квартира',
		@GreatSummary = N'1 кімнатна квартира в спальному районі',
		@BedRoom = 1,
		@Bathroom = 1,
		@RoomType = 1,
		@HomeType = 1,
		@Accommodates = 4,
		@Address1 = N'вул. Київська 27',
		@City = N'Вінниця',
		@Zip = N'21000',
		@State2 = N'Вінницька область',
		@Country = 184

SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[PropertyListingCreate]
		@AccountId = 1914, -- user2 from account
		@State = 0,
		@PricePerNight = 50,
		@PricePerWeek = 350,
		@PricePerMonth = 6000,
		@Photos = N'"img/appartment3"',
		@GreatTitle = N'3 кімнатна квартира',
		@GreatSummary = N'3 кімнатна квартира в центрі міста....',
		@BedRoom = 3,
		@Bathroom = 2,
		@RoomType = 2,
		@HomeType = 1,
		@Accommodates = 5,
		@Address1 = N'вул. Архітектора артинова 32',
		@City = N'Вінниця',
		@Zip = N'21000',
		@State2 = N'Вінницька область',
		@Country = 184

SELECT	'Return Value' = @return_value
GO
