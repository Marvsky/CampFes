@echo off
setlocal enabledelayedexpansion

REM Set the paths for the projects
set "modelProject=CampFes.Models"
set "webApiProject=CampFes.WebApi"

REM Execute the database update command
echo Updating database...
dotnet ef database update -p %modelProject% -s %webApiProject%

REM Check if the command was successful
if errorlevel 1 (
    echo Database update failed.
    pause
    exit /b 1
)

echo Database update completed successfully.

endlocal
pause
