USE [RentApartments]
GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[AccountCreate]
		@AccountId = N'3',
		@PasswordHash = N'630db2d0cd975123de63b8aea975f1424be5b9824561df208c28d25141800ace',
		@FirstName = N'Igor',
		@LastName = N'Pavliuk',
		@Email = N'email3@gmail.com',
		@Country = 184,
		@City = N'Vinnitsya',
		@Address = N'^00-ritchya 17 st. ',
		@Mobile = N'0975551231',
		@Gender = 1,
		@PostalCode = N'21000',
		@Language = 1,
		@ImageSourceId = N'"\imageTetiana1.jpg"'

SELECT	'Return Value' = @return_value
GO
