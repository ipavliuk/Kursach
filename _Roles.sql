use [RentApartments]
Go
INSERT INTO _Roles(RoleName, RoleDescription) VALUES (N'Client', N'Reular user');
INSERT INTO _Roles(RoleName, RoleDescription) VALUES (N'Owner', N' Provide at least one item to rent');
INSERT INTO _Roles(RoleName, RoleDescription) VALUES (N'Manager', N'Menage and approve rent deals with rent');

Go

select* from _Roles 