use [RentApartments]
Go

create procedure _AmenitiesGetById
	@id int
as
begin
	SELECT [id]
      ,[Name]
      ,[Description]
      ,[IsActive]
	FROM [RentApartments].[dbo].[_Amenities]
	where id = @id
end
--------------------------------------------------
GO
create procedure _CountryGetById
	@id int
as
begin
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
	SELECT [RoleId]
		  ,[RoleName]
		  ,[RoleDescription]
	FROM [RentApartments].[dbo].[_Roles]
	where RoleId = @id
end
GO