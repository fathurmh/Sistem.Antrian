@ECHO OFF
CLS
ECHO 1.Add New Migrations
ECHO 2.Update Database
ECHO.

CHOICE /C 12 /M "Enter your choice:"
IF ERRORLEVEL 2 GOTO Update Database
IF ERRORLEVEL 1 GOTO Add New Migrations

:Add New Migrations
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "HH=%dt:~8,2%" & set "Min=%dt:~10,2%" & set "Sec=%dt:~12,2%"
set "stamp=Migrate_%YYYY%-%MM%-%DD%_%HH%-%Min%-%Sec%"
dotnet-ef migrations add %stamp% --verbose
dotnet-ef database update --verbose
GOTO End

:Update Database
dotnet-ef database update --verbose
GOTO End

:End
@pause
