@echo off

DATE /T 
TIME /T

set folder=".\Database"

if not exist %folder% md %folder%

echo 正在备份...
echo.
echo 详细信息:
osql -U sa -P libra -i ".\Scripts\JDM_Backup.sql" -p -b

echo.
echo.
echo 备份成功!

timeout /t 3