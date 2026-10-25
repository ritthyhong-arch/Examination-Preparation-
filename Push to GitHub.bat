@echo off
title Push Examination Management System to GitHub
cd /d "D:\School Management"
cls
echo ========================================================
echo   Pushing to GitHub: Examination-Preparation-
echo   Repository: https://github.com/ritthyhong-arch/Examination-Preparation-.git
echo ========================================================
echo.
git push -u origin main
echo.
if %errorlevel% equ 0 (
    echo ========================================================
    echo   [SUCCESS / CHOKCHEY]
    echo   Ban push laeng tov GitHub ruoch reul!
    echo   Online site will update in 1-2 minutes:
    echo   https://ritthyhong-arch.github.io/Examination-Preparation-/
    echo ========================================================
) else (
    echo ========================================================
    echo   [FAILED]
    echo   Please check GitHub login or credentials.
    echo ========================================================
)
echo.
pause
