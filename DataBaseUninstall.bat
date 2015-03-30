echo  Delete RentApartment database
echo .

echo  Running Drop tables script 1...
sqlcmd -S localhost\sqlexpress -i  DropTable.sql -b


echo  Running Drop Database script 1...
sqlcmd -S localhost\sqlexpress -i  DropDatabase.sql -b


echo.
echo Uninstall Complete.
pause

