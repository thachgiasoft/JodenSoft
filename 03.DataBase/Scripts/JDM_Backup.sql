DECLARE @name nvarchar(50)
DECLARE @datetime nvarchar(14)
DECLARE @path nvarchar(255)
DECLARE @bakfile nvarchar(255)

set @name='JDM'
set @datetime=CONVERT(nvarchar(8),getdate(),112) + REPLACE(CONVERT(nvarchar(8),getdate(),108),':','')
set @path='D:\MyWorkspaces\JodenSoft\03.DataBase\Database\'
set @bakfile=@path+@name+'_backup'+'.bak'

backup database @name to disk=@bakfile with FORMAT,    COMPRESSION
go