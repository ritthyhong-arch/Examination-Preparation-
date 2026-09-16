@echo off
cd /d "D:\School Management"
tasklist /FI "IMAGENAME eq server.exe" 2>NUL | find /I /N "server.exe">NUL
if "%ERRORLEVEL%"=="1" (
    start "" /min "D:\School Management\server.exe"
)
timeout /t 1 >nul
start "" "http://localhost:8080"
