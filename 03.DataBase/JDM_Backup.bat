@echo off

DATE /T 
TIME /T

set folder=".\Database"

if not exist %folder% md %folder%

echo ���ڱ���...
echo.
echo ��ϸ��Ϣ:
osql -U sa -P libra -i ".\Scripts\JDM_Backup.sql" -p -b

echo.
echo.
echo ���ݳɹ�!

timeout /t 3