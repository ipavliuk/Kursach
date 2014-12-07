use [RentApartments]
go
--DROP TABLE _Currency;
 
-- Create table variable
--CREATE TABLE _Currency (Id int IDENTITY(1,1) NOT NULL, Country nvarchar(255) NOT NULL, Currency nvarchar(255) NOT NULL, Code nvarchar(3) NOT NULL, Symbol nvarchar(255) NOT NULL, PRIMARY KEY (Id));
 
-- Insert currency records
INSERT INTO _Currency(Country, Currency, Code, Symbol)  VALUES ('Euro','Euro','EUR',N'€');
INSERT INTO _Currency(Country, Currency, Code, Symbol)  VALUES ('Switzerland','Francs','CHF',N'CHF');
INSERT INTO _Currency(Country, Currency, Code, Symbol)  VALUES ('Ukraine','Hryvnia','UAH',N'₴');
INSERT INTO _Currency(Country, Currency, Code, Symbol)  VALUES ('United Kingdom','Pounds','GBP',N'£');
INSERT INTO _Currency(Country, Currency, Code, Symbol)  VALUES ('United States of America','Dollars','USD',N'$');
 
-- Select values from table                        
SELECT * FROM dbo._Currency;

