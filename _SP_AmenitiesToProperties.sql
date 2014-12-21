use [RentApartments]
Go

create procedure dbo.AddAmenitiesToProperty
	  @PropertyListingId int, 
	  @AmenityId  int
as
begin	
	INSERT INTO PropertyListing__Amenities(FK_PropertyListing, FK__Amenities) 
	VALUES (@PropertyListingId, @AmenityId);
end
GO
