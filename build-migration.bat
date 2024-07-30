@echo off

REM 設置輸出編碼為UTF-8
chcp 65001 > nul
setlocal enabledelayedexpansion

REM Prompt for migration name
set /p migrationName="Enter the migration name: "

REM Generate the migration
dotnet ef migrations add %migrationName% -p CampFes.Models -s CampFes.WebApi

REM Check if the migration was created successfully
if errorlevel 1 (
    echo Migration creation failed.
    pause
    exit /b 1
)

REM Set the path to the migrations folder
set "migrationsFolder=CampFes.Models\Migrations"

REM Get the latest migration file name that matches the input name
set "latestFile="
for /f "delims=" %%i in ('dir /b /o-d "%migrationsFolder%\*%migrationName%.cs"') do (
    if not "%%i"=="%migrationName%.Designer.cs" (
        set "latestFile=%%i"
        goto :break
    )
)
:break

if "%latestFile%"=="" (
    echo No migration file found matching the name %migrationName%.
    pause
    exit /b 1
)

REM Extract base file name without extension
set "baseFileName=%latestFile:~0,-3%"

REM Get the current date and time in UTC
for /f "tokens=2 delims==" %%i in ('wmic os get localdatetime /value') do set datetime=%%i

REM Extract individual components
set YYYY=%datetime:~0,4%
set MM=%datetime:~4,2%
set DD=%datetime:~6,2%
set HH=%datetime:~8,2%
set Min=%datetime:~10,2%
set Sec=%datetime:~12,2%

REM Format the new timestamp
set "newTimestamp=%YYYY%%MM%%DD%-%HH%%Min%%Sec%"

REM Rename the migration file and its designer file with the new timestamp
set "newFileName=%newTimestamp%_%migrationName%.cs"
set "newDesignerFileName=%newTimestamp%_%migrationName%.Designer.cs"

ren "%migrationsFolder%\%latestFile%" "%newFileName%"
ren "%migrationsFolder%\%baseFileName%.Designer.cs" "%newDesignerFileName%"

if errorlevel 1 (
    echo Failed to rename the migration files.
    pause
    exit /b 1
)

echo Migration files renamed to %newFileName% and %newDesignerFileName%.

REM Modify the MigrationId in Designer.cs
set "designerFile=%migrationsFolder%\%newDesignerFileName%"
set "oldMigrationId=%baseFileName%"
set "newMigrationId=%newTimestamp%_%migrationName%"


REM Replace old MigrationId with new MigrationId
set "tempFile=%designerFile%.tmp"
(for /f "usebackq delims=" %%A in ("%designerFile%") do (
    set "line=%%A"
    set "line=!line:%oldMigrationId%=%newMigrationId%!"
    echo !line!
)) > "%tempFile%"

move /y "%tempFile%" "%designerFile%"

echo MigrationId in %newDesignerFileName% updated to %newMigrationId%.

endlocal
pause
