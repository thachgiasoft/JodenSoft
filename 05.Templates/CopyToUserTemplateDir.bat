@echo off
echo 正在复制Entity模板... 
Copy ".\Entity.zip" "c:\users\%username%\Documents\Visual Studio 2013\Templates\ItemTemplates"
echo.
echo 正在复制SingleView模板...
Copy ".\SingleView.zip" "c:\users\%username%\Documents\Visual Studio 2013\Templates\ItemTemplates"
echo.
echo 正在复制MasterDetailView模板...
Copy ".\MasterDetailView.zip" "c:\users\%username%\Documents\Visual Studio 2013\Templates\ItemTemplates"
echo.
echo.
echo 复制完成.

timeout /t 3