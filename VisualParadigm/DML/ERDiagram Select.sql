SELECT MessageId, MessageType, MessageStatus, MessageBody, FK_Account FROM Messages;
SELECT FK_PropertyListing, FK__Amenities FROM PropertyListing__Amenities;
SELECT RoleId, RoleName, RoleDescription FROM _Roles;
SELECT ReservationId, FK_PropertyListing, FK_Account, ReservationStatus, ReservationStart, ReservationEnd, ReservationNote, FK__Currency FROM Reservations;
SELECT MessageId, MessageType, MessageStatus, MessageBody, FK_Account FROM Messages;
SELECT ReviewId, FK_Account, FK_PropertyListing, Review, RatingScore FROM GuestReviews;
SELECT id, Name, Description, IsActive FROM _Amenities;
SELECT [Column], Country, Currency, Code, Symbol FROM _Currency;
SELECT PropertyId, State, PricePerNight, PricePerMonth, PricePerWeek, Photos, GreatTitle, GreatSummary, BedRoom, Bathroom, HomeType, RoomType, Accommodates, Address1, Address2, City, State2, Zip, FK__Country FROM PropertyListing;
SELECT id, IsoCode, Name FROM _Country;
SELECT id, AccountId, FK__Roles, FirstName, LastName, Email, City, FK__Country, Address, Mobile, Gender, PostalCode, Language, IsValidated FROM Account;

