INSERT INTO Messages(MessageId, MessageType, MessageStatus, MessageBody, FK_Account) VALUES (?, ?, ?, ?, ?);
INSERT INTO PropertyListing__Amenities(FK_PropertyListing, FK__Amenities) VALUES (?, ?);
INSERT INTO _Roles(RoleId, RoleName, RoleDescription) VALUES (?, ?, ?);
INSERT INTO Reservations(ReservationId, FK_PropertyListing, FK_Account, ReservationStatus, ReservationStart, ReservationEnd, ReservationNote, FK__Currency) VALUES (?, ?, ?, ?, ?, ?, ?, ?);
INSERT INTO Messages(MessageId, MessageType, MessageStatus, MessageBody, FK_Account) VALUES (?, ?, ?, ?, ?);
INSERT INTO GuestReviews(ReviewId, FK_Account, FK_PropertyListing, Review, RatingScore) VALUES (?, ?, ?, ?, ?);
INSERT INTO _Amenities(id, Name, Description, IsActive) VALUES (?, ?, ?, ?);
INSERT INTO _Currency([Column], Country, Currency, Code, Symbol) VALUES (?, ?, ?, ?, ?);
INSERT INTO PropertyListing(PropertyId, State, PricePerNight, PricePerMonth, PricePerWeek, Photos, GreatTitle, GreatSummary, BedRoom, Bathroom, HomeType, RoomType, Accommodates, Address1, Address2, City, State2, Zip, FK__Country) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);
INSERT INTO _Country(id, IsoCode, Name) VALUES (?, ?, ?);
INSERT INTO Account(id, AccountId, FK__Roles, FirstName, LastName, Email, City, FK__Country, Address, Mobile, Gender, PostalCode, Language, IsValidated) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);

