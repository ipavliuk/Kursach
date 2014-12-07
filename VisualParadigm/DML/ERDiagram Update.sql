UPDATE Messages SET MessageType = ?, MessageStatus = ?, MessageBody = ?, FK_Account = ? WHERE MessageId = ?;
UPDATE PropertyListing__Amenities SET  WHERE FK_PropertyListing = ? AND FK__Amenities = ?;
UPDATE _Roles SET RoleName = ?, RoleDescription = ? WHERE RoleId = ?;
UPDATE Reservations SET FK_PropertyListing = ?, FK_Account = ?, ReservationStatus = ?, ReservationStart = ?, ReservationEnd = ?, ReservationNote = ?, FK__Currency = ? WHERE ReservationId = ?;
UPDATE Messages SET MessageType = ?, MessageStatus = ?, MessageBody = ?, FK_Account = ? WHERE MessageId = ?;
UPDATE GuestReviews SET FK_Account = ?, FK_PropertyListing = ?, Review = ?, RatingScore = ? WHERE ReviewId = ?;
UPDATE _Amenities SET Name = ?, Description = ?, IsActive = ? WHERE id = ?;
UPDATE _Currency SET Country = ?, Currency = ?, Code = ?, Symbol = ? WHERE [Column] = ?;
UPDATE PropertyListing SET State = ?, PricePerNight = ?, PricePerMonth = ?, PricePerWeek = ?, Photos = ?, GreatTitle = ?, GreatSummary = ?, BedRoom = ?, Bathroom = ?, HomeType = ?, RoomType = ?, Accommodates = ?, Address1 = ?, Address2 = ?, City = ?, State2 = ?, Zip = ?, FK__Country = ? WHERE PropertyId = ?;
UPDATE _Country SET IsoCode = ?, Name = ? WHERE id = ?;
UPDATE Account SET AccountId = ?, FK__Roles = ?, FirstName = ?, LastName = ?, Email = ?, City = ?, FK__Country = ?, Address = ?, Mobile = ?, Gender = ?, PostalCode = ?, Language = ?, IsValidated = ? WHERE id = ?;

