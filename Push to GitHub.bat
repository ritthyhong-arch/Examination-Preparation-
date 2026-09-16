@echo off
title Push Examination Management System to GitHub
chcp 65001 > nul
cd /d "%~dp0"
echo ========================================================
echo   កំពុងរុញទិន្នន័យទៅកាន់ GitHub (Push to GitHub)
echo   Repository: https://github.com/ritthyhong-arch/Examination-Preparation-.git
echo ========================================================
echo.
git push -u origin main
echo.
if %errorlevel% equ 0 (
    echo ========================================================
    echo   [ជោគជ័យ] បាន Push ឡើងទៅ GitHub ដោយជោគជ័យ!
    echo ========================================================
) else (
    echo ========================================================
    echo   [បរាជ័យ] សូមពិនិត្យការ Login លើ GitHub របស់អ្នក។
    echo ========================================================
)
echo.
pause
