
/*

exec dbo.sysPageQuery 'select Iden, Name, FileName, FileVersion, FileSize, LastWriteTime, Remark from sysFile with(nolock)',10,1

*/

CREATE PROCEDURE [dbo].[sysPageQuery]
@CommandText NVARCHAR(MAX), --查询字符串
@PageSize INT, --每页行数
@CurrPage INT --第N页
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @cursor int 
	DECLARE @RowCount int --总行数
	DECLARE @PageCount int  --总页数
	DECLARE @StartRow int --当前行
	
	IF @PageSize<=0
		EXEC(@CommandText)
	ELSE BEGIN
		EXEC sp_cursoropen @cursor OUTPUT,@CommandText,@scrollopt=1,@ccopt=1,@RowCount=@RowCount OUTPUT
		SET @PageCount=CEILING(1.0*@RowCount/@PageSize) 
		SELECT PageSize=@PageSize, CurrPage=@CurrPage, TotalPage= @PageCount,TotalRowCount=@RowCount
		IF @CurrPage>@PageCount
			Set @CurrPage=@PageCount
		SET @StartRow=(@CurrPage-1)*@PageSize+1
		EXEC sp_cursorfetch @cursor,16,@StartRow,@PageSize  
		EXEC sp_cursorclose @cursor
	END
	SET NOCOUNT OFF
END
