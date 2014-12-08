use [RentApartments]
Go

create procedure _AmenitiesGetById
	@id int = null
as
begin
if @id is null 
	SELECT [id]
      ,[Name]
      ,[Description]
      ,[IsActive]
	FROM [RentApartments].[dbo].[_Amenities]
else
	SELECT [id]
      ,[Name]
      ,[Description]
      ,[IsActive]
	FROM [RentApartments].[dbo].[_Amenities]
	where  id = @id
end
--------------------------------------------------
GO
create procedure _CountryGetById
	@id int
as
begin
if @id is null 
	SELECT [id]
		  ,[IsoCode]
		,[Name]
	FROM [RentApartments].[dbo].[_Country]
else
	SELECT [id]
		  ,[IsoCode]
		,[Name]
	FROM [RentApartments].[dbo].[_Country]
	where id = @id
end
GO
create procedure _CurrencyGetById
	@id int
as
begin
if @id is null 
	SELECT [Id]
      ,[Country]
      ,[Currency]
      ,[Code]
      ,[Symbol]
  FROM [RentApartments].[dbo].[_Currency]
else
	SELECT [Id]
      ,[Country]
      ,[Currency]
      ,[Code]
      ,[Symbol]
  FROM [RentApartments].[dbo].[_Currency]
	where id = @id
end
GO
create procedure _RolesGetById
	@id int
as
begin
if @id is null 
	SELECT [RoleId]
		  ,[RoleName]
		  ,[RoleDescription]
	FROM [RentApartments].[dbo].[_Roles]
else
	SELECT [RoleId]
		  ,[RoleName]
		  ,[RoleDescription]
	FROM [RentApartments].[dbo].[_Roles]
	where RoleId = @id
	
end
GO