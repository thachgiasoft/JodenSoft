IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sppbGenerateBillNo]') 
	AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sppbGenerateBillNo]
IF OBJECT_ID(N'pbTableDefine') IS NOT NULL
    DELETE FROM dbo.pbTableDefine WHERE sTableName=N'sppbGenerateBillNo.sql'
GO

--单据编号生成器
CREATE PROCEDURE dbo.sppbGenerateBillNo(
@iFormulaId int, --单据编号生成公式ID
@sParameters NVARCHAR(1000), --生成单据号时所需要传入的参数值(多个参数通过，串联)
@bIsSave BIT, --是否保存此单据序号
@iIncNum int=1, --单据流水号的增加值，默认增加1
@iStart int=0,--单据流水号的起始号，返回的流水号大于此流水号
@sNewBillNo NVARCHAR(50) OUTPUT, --产生的新单据号
@sFormulaResetNo NVARCHAR(50)=N'' OUTPUT,	--单据重设编号
@sBillFormula NVARCHAR(100)=N'',		--自定义单据公式，若设置，则以此公式进行计算
@sBillFormulaReset NVARCHAR(100)=N''		--自定义单据重置公式，若设置，则以此公式进行计算
)
WITH ENCRYPTION
AS
BEGIN TRY
    SET NOCOUNT ON;
    IF OBJECT_ID(N'tempdb..#Params_6804') IS NOT NULL DROP TABLE #Params_6804
    IF EXISTS(SELECT TOP 1 1 FROM master.dbo.syscursors WHERE cursor_name='curBillFormulaReset')
        DEALLOCATE curBillFormulaReset
    IF EXISTS(SELECT TOP 1 1 FROM master.dbo.syscursors WHERE cursor_name='curBillFormula')
        DEALLOCATE curBillFormula
  
	SET @iStart = CASE WHEN @iStart > 1 THEN @iStart - 1 ELSE 0 END /*修正起始号,后面会+1 bely zhou*/

	SET @sNewBillNo=N''
	SET @sFormulaResetNo=N''

	---查找定义的单据公式，如果没有则返回空
	IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.pbBillNoFormula WITH(NOLOCK) WHERE iFormulaId=@iFormulaId) 
	BEGIN
		RAISERROR(N'请配置单据编号生成规则[%d]!',16,1,@iFormulaId)
		RETURN
	END

	--DECLARE @sFormulaResetNo NVARCHAR(100)		--重设公式编号
	DECLARE @iNewBillSequence int				--新单据流水号
	DECLARE @iBillNoLength INT					--整个单据的固定长度
	
	DECLARE @sFormulaName NVARCHAR(50)			--单项计算公式
	DECLARE @sFormulaValue NVARCHAR(50)			--单项计算公式的值

	---参数列表临时数据集
	SELECT @sParameters=REPLACE(@sParameters, N';', N',') 
	SELECT iIden=IDENTITY(INT, 1, 1),sParamName = CONVERT(VARCHAR(20), N''),sParamValue=[No]
	INTO #Params_6804 
	FROM dbo.fnpbConvertStrToTable(@sParameters, N',')
	
	UPDATE #Params_6804 
	SET sParamName=N'[@参数'+CONVERT(VARCHAR(10), iIden)+N']'

	---查询公式
	SELECT @sBillFormula=CASE WHEN @sBillFormula=N'' THEN sBillFormula ELSE @sBillFormula END
	,@sBillFormulaReset=CASE WHEN @sBillFormulaReset=N'' THEN sBillFormulaReset ELSE @sBillFormulaReset END  
	FROM pbBillNoFormula WITH(NOLOCK) 
	WHERE iFormulaId=@iFormulaId
	
	DECLARE curBillFormulaReset CURSOR
	FOR
		SELECT sFormulaReset=sNo
		FROM dbo.fnpbConvertStrToIndexTable(@sBillFormulaReset, N'+')
		ORDER BY iIndex
		--WHERE [No] NOT LIKE '%流水号%'
	OPEN curBillFormulaReset
	
	--计算重设单号
	SET @sFormulaResetNo=N''
	FETCH NEXT FROM curBillFormulaReset INTO @sFormulaName
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @sFormulaValue=N''
		IF @sFormulaName LIKE N'[[]@参数%]'
		BEGIN
			SELECT @sFormulaValue=sParamValue
			FROM #Params_6804 
			WHERE sParamName=@sFormulaName
		END
		ELSE
			EXEC dbo.sppbCalcBillFormulaValue @sFormulaName,@sFormulaValue OUTPUT
		
		SELECT @sFormulaResetNo=@sFormulaResetNo+RTRIM(LTRIM(ISNULL(@sFormulaValue,N'')))
		FETCH NEXT FROM curBillFormulaReset INTO @sFormulaName
	END
	CLOSE curBillFormulaReset
	DEALLOCATE curBillFormulaReset
	
	--计算要返回的最大流水号
	SELECT @iStart=iBillSequence
	FROM dbo.pbBillNoFormulaDtl 
	WHERE iFormulaId=@iFormulaId AND sBillFormulaResetNo=@sFormulaResetNo AND iBillSequence > @iStart ;
	
	SET @iNewBillSequence=@iStart+CASE WHEN @iIncNum>0 THEN 1 ELSE 0 END
		
	---保存流水号
	IF @bIsSave=1 AND @iIncNum>0 
	BEGIN
		UPDATE dbo.pbBillNoFormulaDtl 
		SET iBillSequence=iBillSequence+@iIncNum 
		WHERE iFormulaId=@iFormulaId AND sBillFormulaResetNo=@sFormulaResetNo
		--不存在则新增
		IF @@ROWCOUNT=0
		BEGIN
			INSERT INTO dbo.pbBillNoFormulaDtl([iFormulaId],[sBillFormulaResetNo],[iBillSequence])  
			VALUES(@iFormulaId,@sFormulaResetNo,@iStart+@iIncNum)
		END
	END

	DECLARE curBillFormula CURSOR
	FOR 
		SELECT sBillFormula=sNo
		FROM dbo.fnpbConvertStrToIndexTable(@sBillFormula, N'+')
		ORDER BY iIndex
	OPEN curBillFormula	
	
	--计算最新单号
	FETCH NEXT FROM curBillFormula INTO @sFormulaName
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @sFormulaValue=N''
		IF @sFormulaName LIKE N'[[]@参数%]'
		BEGIN
			SELECT @sFormulaValue=ISNULL(sParamValue,N'') 
			FROM #Params_6804 
			WHERE sParamName=@sFormulaName
		END
		ELSE IF @sFormulaName LIKE N'[[]@固位流水号%]'
		BEGIN
			SET @iBillNoLength=CONVERT(int,SUBSTRING(@sFormulaName,8,LEN(@sFormulaName)-8))
			SET @sFormulaValue=N'[@F]'
		END
		ELSE
		BEGIN
			SET @sFormulaValue=CONVERT(NVARCHAR(50),@iNewBillSequence)
			EXEC dbo.sppbCalcBillFormulaValue @sFormulaName,@sFormulaValue OUTPUT
		END
		SELECT @sNewBillNo=@sNewBillNo+RTRIM(LTRIM(ISNULL(@sFormulaValue,N'')))
		FETCH NEXT FROM curBillFormula INTO @sFormulaName
	END
	CLOSE curBillFormula
	DEALLOCATE curBillFormula

	---处理固位流水号(固定整个单据位数)
	DECLARE @iCount int
	IF @iBillNoLength>0 
	BEGIN
		SET @iCount=@iBillNoLength-(LEN(@sNewBillNo)-4)
		IF @iCount<=0
			SELECT @sFormulaValue=CONVERT(NVARCHAR(50), @iNewBillSequence)
		ELSE
			SELECT @sFormulaValue=RIGHT(N'0000000000'+CONVERT(NVARCHAR(50), @iNewBillSequence),@iCount)
		SELECT @sNewBillNo=REPLACE(@sNewBillNo, N'[@F]', @sFormulaValue) 	
	END

    IF OBJECT_ID(N'tempdb..#Params_6804') IS NOT NULL DROP TABLE #Params_6804
    IF EXISTS(SELECT TOP 1 1 FROM master.dbo.syscursors WHERE cursor_name='curBillFormulaReset')
        DEALLOCATE curBillFormulaReset
    IF EXISTS(SELECT TOP 1 1 FROM master.dbo.syscursors WHERE cursor_name='curBillFormula')
        DEALLOCATE curBillFormula
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK TRAN
    DECLARE @sErrorMessage NVARCHAR(MAX)
    SET @sErrorMessage=ERROR_MESSAGE()+CHAR(10)+LTRIM(STR(ERROR_NUMBER()))+'='+ISNULL(ERROR_PROCEDURE(),'')+'.'+LTRIM(STR(ERROR_LINE()))
    RAISERROR(@sErrorMessage,16,1)
END CATCH
GO

/*
delete from dbo.pbBillNoFormula
INSERT INTO dbo.pbBillNoFormula  
([iFormulaId],[iIden],[sBillFormulaReset],[sBillCaption],[sBillFormula],[sBillName])  
VALUES(1,1,'PN+[2位年]+[2位月]','a','PN+[2位年]+[2位月]+[@参数1]+[字母流水号]','b')

declare @sNewBillNo varchar(50),@s varchar(50)
EXEC dbo.sppbGenerateBillNo 1,'ZZ',0,1,0,@sNewBillNo output,@s output
select @sNewBillNo,@s

declare @sNewBillNo varchar(50),@s varchar(50)
EXEC dbo.sppbGenerateBillNo 1,'ZZ',0,1,10,@sNewBillNo output
select @sNewBillNo

*/