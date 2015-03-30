echo  Update database
echo .

echo  Running CreateDB script 1...
sqlcmd -S localhost\sqlexpress -i  CreateDataBase.sql -b
echo  Running CreateTable script 1...

sqlcmd -S localhost\sqlexpress -i  CreateScript.sql -b

echo  Fill _dictionary with data
echo .

echo  _Amenities..
sqlcmd -S localhost\sqlexpress -i  _Amenities.sql -b 

echo  _Country..
sqlcmd -S localhost\sqlexpress -i  _Country.sql -b 

echo  _Currency..
sqlcmd -S localhost\sqlexpress -i  _Currency.sql -b 

echo _Roles...
sqlcmd -S localhost\sqlexpress -i  _Roles.sql -b 

echo  Added Sps
echo .

sqlcmd -S localhost\sqlexpress -i  _SP_Account.sql -b  
sqlcmd -S localhost\sqlexpress -i  _SP_AmenitiesToProperties.sql -b  
sqlcmd -S localhost\sqlexpress -i  _SP_Dictionaries.sql -b  
sqlcmd -S localhost\sqlexpress -i  _SP_PropertyList.sql -b  
sqlcmd -S localhost\sqlexpress -i  _SP_Reservations.sql -b  


echo.
echo Update Complete.
pause





