@echo off
@echo 正在准备安装SAF.SqlClr...
sqlcmd -S LOCALHOST -E -i SAF.SqlClr.publish.sql
pause