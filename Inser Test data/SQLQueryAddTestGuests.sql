USE [RentApartments]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[AccountCreate]
		@AccountId = N'1fca422c-7da0-4fdf-a0e0-f61606400dc3',
		@PasswordHash = N'0cd0b08135c4dc3fd2ea998a7ae2542bfb54d43b7b5f33081b21bb59fbeed7fd',
		@FirstName = N'GuestUser1',
		@LastName = N'GuestUser1',
		@Email = N'GuestUser1@gmail.com',
		@Country = 184,
		@City = N'вінниця',
		@Address = N'40-річчя перемоги 21',
		@Mobile = N'09132532521',
		@Gender = 1,
		@PostalCode = N'21000',
		@Language = 1,
		@ImageSourceId = N'imgPhoto1'

SELECT	'Return Value' = @return_value

GO
DECLARE	@return_value int

EXEC	@return_value = [dbo].[AccountCreate]
		@AccountId = N'70334b39-4aaf-4bbe-acff-817fa7ecb4c9',
		@PasswordHash = N'0cd0b08135c4dc3fd2ea998a7ae2542bfb54d43b7b5f33081b21bb59fbeed7fd',
		@FirstName = N'GuestUser2',
		@LastName = N'GuestUser2',
		@Email = N'GuestUser2@gmail.com',
		@Country = 184,
		@City = N'вінниця',
		@Address = N'40-річчя перемоги 22',
		@Mobile = N'09132532522',
		@Gender = 1,
		@PostalCode = N'21000',
		@Language = 1,
		@ImageSourceId = N'imgPhoto1'

SELECT	'Return Value' = @return_value

GO
DECLARE	@return_value int
EXEC	@return_value = [dbo].[AccountCreate]
		@AccountId = N'01c529d2-918a-42ff-aa67-e4222d59975f',
		@PasswordHash = N'0cd0b08135c4dc3fd2ea998a7ae2542bfb54d43b7b5f33081b21bb59fbeed7fd',
		@FirstName = N'GuestUser3',
		@LastName = N'GuestUser3',
		@Email = N'GuestUser3@gmail.com',
		@Country = 184,
		@City = N'Київ',
		@Address = N'вул. Хрещатик 22',
		@Mobile = N'09132532522',
		@Gender = 1,
		@PostalCode = N'52000',
		@Language = 1,
		@ImageSourceId = N'imgPhoto1'

SELECT	'Return Value' = @return_value
GO
DECLARE	@return_value int

EXEC	@return_value = [dbo].[AccountCreate]
		@AccountId = N'dda73bf1-0378-4fe9-8664-3e026a38c602',
		@PasswordHash = N'0cd0b08135c4dc3fd2ea998a7ae2542bfb54d43b7b5f33081b21bb59fbeed7fd',
		@FirstName = N'GuestUser4',
		@LastName = N'GuestUser4',
		@Email = N'GuestUser4@gmail.com',
		@Country = 184,
		@City = N'Київ',
		@Address = N'вул. Хрещатик 24',
		@Mobile = N'09132532524',
		@Gender = 1,
		@PostalCode = N'52000',
		@Language = 1,
		@ImageSourceId = N'imgPhoto1'

SELECT	'Return Value' = @return_value
GO

DECLARE	@return_value int
EXEC	@return_value = [dbo].[AccountCreate]
		@AccountId = N'1ea37e23-92c6-4b2f-976d-eeec9e006aa8',
		@PasswordHash = N'0cd0b08135c4dc3fd2ea998a7ae2542bfb54d43b7b5f33081b21bb59fbeed7fd',
		@FirstName = N'GuestUser5',
		@LastName = N'GuestUser5',
		@Email = N'GuestUser5@gmail.com',
		@Country = 184,
		@City = N'Київ',
		@Address = N'вул. Хрещатик 25',
		@Mobile = N'09132532524',
		@Gender = 1,
		@PostalCode = N'52000',
		@Language = 1,
		@ImageSourceId = N'imgPhoto1'

SELECT	'Return Value' = @return_value
GO

