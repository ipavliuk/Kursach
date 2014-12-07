DELETE FROM Messages WHERE MessageId = ?;
DELETE FROM PropertyListing__Amenities WHERE FK_PropertyListing = ? AND FK__Amenities = ?;
DELETE FROM _Roles WHERE RoleId = ?;
DELETE FROM Reservations WHERE ReservationId = ?;
DELETE FROM Messages WHERE MessageId = ?;
DELETE FROM GuestReviews WHERE ReviewId = ?;
DELETE FROM _Amenities WHERE id = ?;
DELETE FROM _Currency WHERE [Column] = ?;
DELETE FROM PropertyListing WHERE PropertyId = ?;
DELETE FROM _Country WHERE id = ?;
DELETE FROM Account WHERE id = ?;

