--1.查看开启状态
EXEC sp_configure 'clr enabled'
--2.启用clr(1为启用，0为关闭)
EXEC sp_configure 'clr enabled',1
--执行以上语句会有提示:请运行RECONFIGURE语句进行安装
RECONFIGURE WITH OVERRIDE