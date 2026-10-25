@echo off
title Push Examination Management System to GitHub
chcp 65001 > nul
cd /d "D:\School Management"
echo ========================================================
echo   កំពុងបញ្ជូនទិន្នន័យទៅកាន់ GitHub (Push to GitHub)
echo   Repository: https://github.com/ritthyhong-arch/Examination-Preparation-.git
echo ========================================================
echo.
git push -u origin main
echo.
if %errorlevel% equ 0 (
    echo ========================================================
    echo   [ជោគជ័យ] បាន Push ឡើងទៅកាន់ GitHub រួចរាល់ហើយ!
    echo   គេហទំព័រ Online នឹងធ្វើបច្ចុប្បន្នភាពក្នុងរយៈពេល ១ ទៅ ២ នាទី។
    echo ========================================================
) else (
    echo ========================================================
    echo   [បរាជ័យ] ការតភ្ជាប់ GitHub ត្រូវការចូលគណនី (Login)
    echo   សូមពិនិត្យមើលផ្ទាំង Browser ដែលបានបើកឡើងដើម្បី Sign in GitHub
    echo ========================================================
)
echo.
pause
