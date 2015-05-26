use [RentApartments]
Go
INSERT INTO _Roles(RoleName, RoleDescription) VALUES (N'Client', N'Reular cleint or owner');
INSERT INTO _Roles(RoleName, RoleDescription) VALUES (N'Owner', N' Provide at least one item to rent');
INSERT INTO _Roles(RoleName, RoleDescription) VALUES (N'Manager', N'Menage and approve rent deals with rent');

Go
use [RentApartments]
Go
update _Roles set RoleName = N'Admin', RoleDescription = N'Administrator of application' where RoleId = 2
update _Roles set RoleName = N'Client', RoleDescription = N'Regular cleint or owner' where RoleId = 1
update _Roles set RoleName = N'Root', RoleDescription = N'God mode' where RoleId = 3
select* from _Roles 