use [RentApartments]
Go

create procedure dbo.AccountCreate
	@O_ErrCode INT OUTPUT,
	@O_ErrMsg NVARCHAR(4000) OUTPUT,
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
	begin try
		
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

		----------------------------------- Parameters Validation -------------------------------------------
				
		INSERT INTO Account(AccountId, PasswordHash, FirstName, LastName, Email, IsEmailConfirmed, FK__Country, FK__Roles, City, Address, Mobile, Gender, PostalCode, IsValidated, PictureUrl) 
		VALUES (@AccountId, @PasswordHash, @FirstName, @LastName, @Email, 0, @Country, 1, @City, @Address, @Mobile, @Gender, @PostalCode, 0, @ImageSourceId);
		SELECT SCOPE_IDENTITY()
	end try
	BEGIN CATCH
	
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	END CATCH
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
	@O_ErrCode						INT					OUTPUT,
	@O_ErrMsg						NVARCHAR(4000)		OUTPUT,
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
	SET NOCOUNT ON;
	begin try
		
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

		----------------------------------- Parameters Validation -------------------------------------------
		
		IF @Acc_Id IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@Acc_Id cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END
        IF @Country IS NULL 
		BEGIN 
			SET @O_ErrCode = -2
			SET @O_ErrMsg = '@Country cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END
		IF @Roles IS NULL 
		BEGIN 
			SET @O_ErrCode = -3
			SET @O_ErrMsg = '@Roles cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END

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
			--Language = ISNULL(@Language, Language), 
			IsValidated = ISNULL(@IsValidated, IsValidated),
			PictureUrl = ISNULL(@ImageSourceId, PictureUrl)
		where Id = @Acc_Id
	end try
	BEGIN CATCH
	
		--Handle the error 
		EXEC [dbo].[sp_HandleSPErrors]
			 @IO_ErrCode = @O_ErrCode	OUTPUT
			,@IO_ErrMsg  = @O_ErrMsg	OUTPUT   
	
	END CATCH

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
@PwdHash nvarchar(255)
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
		  ,[IsValidated]
		  ,[PictureUrl]
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
		  ,[IsValidated]
		  ,PictureUrl
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
		  ,[IsValidated]
		  ,PictureUrl
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
		  ,[IsValidated]
		  ,PictureUrl
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
	@O_ErrCode						INT					OUTPUT,
	@O_ErrMsg						NVARCHAR(4000)		OUTPUT,
	@Acc_Id int
AS
begin
	begin try
		-- Initialization
		SELECT	 @O_ErrCode	= 0
				,@O_ErrMsg	= ''

		----------------------------------- Parameters Validation -------------------------------------------
		
		IF @Acc_Id IS NULL 
		BEGIN 
			SET @O_ErrCode = -1
			SET @O_ErrMsg = '@Acc_Id cannot be NULL'		 
			RAISERROR(@O_ErrMsg, 16, 1)
		END
		BEGIN TRANSACTION
			DELETE FROM Account
			WHERE id = @Acc_Id

			 -- Rollback the transaction if there were any errors
			IF @@ERROR <> 0
			 BEGIN
				-- Rollback the transaction
				ROLLBACK

				-- Raise an error and return
				RAISERROR ('Error in deleting Account in Accounts.', 16, 1)
				RETURN
			 END

			 --Delete all reservation
			DELETE FROM Reservations
			WHERE FK_Account = @Acc_Id

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
--EXEC	@return_value = [dbo].[AccountDelete]
--		@Acc_Id = 1
--SELECT	'Return Value' = @return_value
GO

----------------------------------------------------------------
