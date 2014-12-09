use [RentApartments]
Go

create procedure dbo.AccountCreate
	@AccountId nvarchar(255), 
	@PasswordHash nvarchar(255), 
	@FirstName nvarchar(255), 
	@LastName nvarchar(255), 
	@Email nvarchar(255), 
	@Country int, 
	@City nvarchar(255) = NULL, 
	@Address nvarchar(255) = NULL, 
	@Mobile nvarchar(15) = NULL, 
	@Gender tinyint = NULL, 
	@PostalCode nvarchar(255) = NULL, 
	@Language int = NULL, 
	@ImageSourceId nvarchar(255) = NULL
as
begin	
	INSERT INTO Account(AccountId, PasswordHash, FirstName, LastName, Email, IsEmailConfirmed, FK__Country, FK__Roles, City, Address, Mobile, Gender, PostalCode, Language, IsValidated, ImageSourceId) 
	VALUES (@AccountId, @PasswordHash, @FirstName, @LastName, @Email, 0, @Country, 1, @City, @Address, @Mobile, @Gender, @PostalCode, @Language, 0, @ImageSourceId);
end


--DECLARE	@return_value int

--EXEC	@return_value = [dbo].[AccountCreate]
--		@AccountId = N'SomeId2',
--		@PasswordHash = N'asdasd',
--		@FirstName = N'Druidd',
--		@LastName = N'asdasd',
--		@Email = N'sadasd',
--		@Country = 1,
--		@City = N'Ney-York',
--		@Address = N'asdf',
--		@Mobile = N'asdf',
--		@Gender = 0,
--		@PostalCode = N'123213',
--		@Language = 1,
--		@ImageSourceId = N'asdf'

--SELECT	'Return Value' = @return_value

GO
--select * from account
----------------------------------------------------------------

----------------------------------------------------------------
create procedure dbo.AccountUpdate
	@Acc_Id int,
	@PasswordHash nvarchar(255) = null, 
	@FirstName nvarchar(255) = NULL, 
	@LastName nvarchar(255) = NULL, 
	@Email nvarchar(255) = NULL, 
	@IsEmailConfirmed bit = NULL, 
	@Country int = NULL, 
	@Roles tinyint = NULL, 
	@City nvarchar(255) = NULL, 
	@Address nvarchar(255) = NULL, 
	@Mobile nvarchar(15) = NULL, 
	@Gender tinyint = NULL, 
	@PostalCode nvarchar(255) = NULL, 
	@Language int = NULL, 
	@IsValidated bit = NULL,
	@ImageSourceId nvarchar(255) = NULL
as
begin	
	--SET NOCOUNT ON;
	update Account
	set PasswordHash = ISNULL(@PasswordHash,PasswordHash), 
		FirstName = ISNULL(@FirstName,FirstName), 
		LastName = ISNULL(@LastName,LastName), 
		Email = ISNULL(@Email, Email), 
		IsEmailConfirmed = ISNULL(@IsEmailConfirmed, IsEmailConfirmed), 
		FK__Country = ISNULL(@Country,FK__Country), 
		FK__Roles = ISNULL(@Roles,FK__Roles), 
		City = ISNULL(@City, City), 
		Address = ISNULL(@Address, Address), 
		Mobile = ISNULL(@Mobile, Mobile), 
		Gender = ISNULL(@Gender, Gender), 
		PostalCode = ISNULL(@PostalCode, PostalCode), 
		Language = ISNULL(@Language, Language), 
		IsValidated = ISNULL(@IsValidated, IsValidated),
		ImageSourceId = ISNULL(@ImageSourceId, ImageSourceId)
	where Id = @Acc_Id
end
---Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[AccountUpdate]
--		@Acc_Id = 4,
--		@PasswordHash = NULL,
--		@FirstName = NULL,
--		@LastName = NULL,
--		@Email = NULL,
--		@IsEmailConfirmed = NULL,
--		@Country = NULL,
--		@Roles = NULL,
--		@City = NULL,
--		@Address = NULL,
--		@Mobile = NULL,
--		@Gender = NULL,
--		@PostalCode = NULL,
--		@Language = NULL,
--		@IsValidated = 1,
--		@ImageSourceId = NULL
--SELECT	'Return Value' = @return_value
--GO
--select * from account
GO
----------------------------------------------------------------
create procedure dbo.AccountGetbyPassword
@PwdHash int
as
begin
	set nocount on;
	SELECT [id]
		  ,[AccountId]
		  ,[PasswordHash]
		  ,[FirstName]
		  ,[LastName]
		  ,[Email]
		  ,[IsEmailConfirmed]
		  ,[FK__Country]
		  ,[FK__Roles]
		  ,[City]
		  ,[Address]
		  ,[Mobile]
		  ,[Gender]
		  ,[PostalCode]
		  ,[Language]
		  ,[IsValidated]
		  ,[ImageSourceId]
	  FROM [RentApartments].[dbo].[Account]
	  where PasswordHash = @PwdHash
end
--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[AccountGetbyId]
--		@PwdHash = 2
--SELECT	'Return Value' = @return_value
GO
----------------------------------------------------------------
----------------------------------------------------------------
create procedure dbo.AccountGetbyEmail
@Email nvarchar(255)
as
begin
	set nocount on;
	SELECT [id]
		  ,[AccountId]
		  ,[PasswordHash]
		  ,[FirstName]
		  ,[LastName]
		  ,[Email]
		  ,[IsEmailConfirmed]
		  ,[FK__Country]
		  ,[FK__Roles]
		  ,[City]
		  ,[Address]
		  ,[Mobile]
		  ,[Gender]
		  ,[PostalCode]
		  ,[Language]
		  ,[IsValidated]
		  ,[ImageSourceId]
	  FROM [RentApartments].[dbo].[Account]
	  where Email = @Email
end
--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[AccountGetbyId]
--		@Email = 'test@gmail.com'
--SELECT	'Return Value' = @return_value
GO
----------------------------------------------------------------

----------------------------------------------------------------
create procedure dbo.AccountGetbyId
@Acc_Id int
as
begin
	set nocount on;
	SELECT [id]
		  ,[AccountId]
		  ,[PasswordHash]
		  ,[FirstName]
		  ,[LastName]
		  ,[Email]
		  ,[IsEmailConfirmed]
		  ,[FK__Country]
		  ,[FK__Roles]
		  ,[City]
		  ,[Address]
		  ,[Mobile]
		  ,[Gender]
		  ,[PostalCode]
		  ,[Language]
		  ,[IsValidated]
		  ,[ImageSourceId]
	  FROM [RentApartments].[dbo].[Account]
	  where id = @Acc_Id
end
--EXEC
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[AccountGetbyId]
--		@Acc_Id = 2
--SELECT	'Return Value' = @return_value
GO
----------------------------------------------------------------
create procedure dbo.AccountGetAll
as
begin
	set nocount on;
	SELECT [id]
		  ,[AccountId]
		  ,[PasswordHash]
		  ,[FirstName]
		  ,[LastName]
		  ,[Email]
		  ,[IsEmailConfirmed]
		  ,[FK__Country]
		  ,[FK__Roles]
		  ,[City]
		  ,[Address]
		  ,[Mobile]
		  ,[Gender]
		  ,[PostalCode]
		  ,[Language]
		  ,[IsValidated]
		  ,[ImageSourceId]
	  FROM [RentApartments].[dbo].[Account]
end
--Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[AccountGetAll]
--SELECT	'Return Value' = @return_value
GO


----------------------------------------------------------------
------Delete
CREATE PROCEDURE dbo.AccountDelete
@Acc_Id int
AS
begin
	DELETE FROM Account
	 WHERE id = @Acc_Id
end
go

--Exec
--DECLARE	@return_value int
--EXEC	@return_value = [dbo].[AccountDelete]
--		@Acc_Id = 1
--SELECT	'Return Value' = @return_value
GO

----------------------------------------------------------------
