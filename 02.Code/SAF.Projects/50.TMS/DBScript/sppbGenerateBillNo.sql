IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sppbGenerateBillNo]') 
	AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sppbGenerateBillNo]
IF OBJECT_ID(N'pbTableDefine') IS NOT NULL
    DELETE FROM dbo.pbTableDefine WHERE sTableName=N'sppbGenerateBillNo.sql'
GO

--���ݱ��������
CREATE PROCEDURE dbo.sppbGenerateBillNo(
@iFormulaId int, --���ݱ�����ɹ�ʽID
@sParameters NVARCHAR(1000), --���ɵ��ݺ�ʱ����Ҫ����Ĳ���ֵ(�������ͨ��������)
@bIsSave BIT, --�Ƿ񱣴�˵������
@iIncNum int=1, --������ˮ�ŵ�����ֵ��Ĭ������1
@iStart int=0,--������ˮ�ŵ���ʼ�ţ����ص���ˮ�Ŵ��ڴ���ˮ��
@sNewBillNo NVARCHAR(50) OUTPUT, --�������µ��ݺ�
@sFormulaResetNo NVARCHAR(50)=N'' OUTPUT,	--����������
@sBillFormula NVARCHAR(100)=N'',		--�Զ��嵥�ݹ�ʽ�������ã����Դ˹�ʽ���м���
@sBillFormulaReset NVARCHAR(100)=N''		--�Զ��嵥�����ù�ʽ�������ã����Դ˹�ʽ���м���
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
  
	SET @iStart = CASE WHEN @iStart > 1 THEN @iStart - 1 ELSE 0 END /*������ʼ��,�����+1 bely zhou*/

	SET @sNewBillNo=N''
	SET @sFormulaResetNo=N''

	---���Ҷ���ĵ��ݹ�ʽ�����û���򷵻ؿ�
	IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.pbBillNoFormula WITH(NOLOCK) WHERE iFormulaId=@iFormulaId) 
	BEGIN
		RAISERROR(N'�����õ��ݱ�����ɹ���[%d]!',16,1,@iFormulaId)
		RETURN
	END

	--DECLARE @sFormulaResetNo NVARCHAR(100)		--���蹫ʽ���
	DECLARE @iNewBillSequence int				--�µ�����ˮ��
	DECLARE @iBillNoLength INT					--�������ݵĹ̶�����
	
	DECLARE @sFormulaName NVARCHAR(50)			--������㹫ʽ
	DECLARE @sFormulaValue NVARCHAR(50)			--������㹫ʽ��ֵ

	---�����б���ʱ���ݼ�
	SELECT @sParameters=REPLACE(@sParameters, N';', N',') 
	SELECT iIden=IDENTITY(INT, 1, 1),sParamName = CONVERT(VARCHAR(20), N''),sParamValue=[No]
	INTO #Params_6804 
	FROM dbo.fnpbConvertStrToTable(@sParameters, N',')
	
	UPDATE #Params_6804 
	SET sParamName=N'[@����'+CONVERT(VARCHAR(10), iIden)+N']'

	---��ѯ��ʽ
	SELECT @sBillFormula=CASE WHEN @sBillFormula=N'' THEN sBillFormula ELSE @sBillFormula END
	,@sBillFormulaReset=CASE WHEN @sBillFormulaReset=N'' THEN sBillFormulaReset ELSE @sBillFormulaReset END  
	FROM pbBillNoFormula WITH(NOLOCK) 
	WHERE iFormulaId=@iFormulaId
	
	DECLARE curBillFormulaReset CURSOR
	FOR
		SELECT sFormulaReset=sNo
		FROM dbo.fnpbConvertStrToIndexTable(@sBillFormulaReset, N'+')
		ORDER BY iIndex
		--WHERE [No] NOT LIKE '%��ˮ��%'
	OPEN curBillFormulaReset
	
	--�������赥��
	SET @sFormulaResetNo=N''
	FETCH NEXT FROM curBillFormulaReset INTO @sFormulaName
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @sFormulaValue=N''
		IF @sFormulaName LIKE N'[[]@����%]'
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
	
	--����Ҫ���ص������ˮ��
	SELECT @iStart=iBillSequence
	FROM dbo.pbBillNoFormulaDtl 
	WHERE iFormulaId=@iFormulaId AND sBillFormulaResetNo=@sFormulaResetNo AND iBillSequence > @iStart ;
	
	SET @iNewBillSequence=@iStart+CASE WHEN @iIncNum>0 THEN 1 ELSE 0 END
		
	---������ˮ��
	IF @bIsSave=1 AND @iIncNum>0 
	BEGIN
		UPDATE dbo.pbBillNoFormulaDtl 
		SET iBillSequence=iBillSequence+@iIncNum 
		WHERE iFormulaId=@iFormulaId AND sBillFormulaResetNo=@sFormulaResetNo
		--������������
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
	
	--�������µ���
	FETCH NEXT FROM curBillFormula INTO @sFormulaName
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @sFormulaValue=N''
		IF @sFormulaName LIKE N'[[]@����%]'
		BEGIN
			SELECT @sFormulaValue=ISNULL(sParamValue,N'') 
			FROM #Params_6804 
			WHERE sParamName=@sFormulaName
		END
		ELSE IF @sFormulaName LIKE N'[[]@��λ��ˮ��%]'
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

	---�����λ��ˮ��(�̶���������λ��)
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
VALUES(1,1,'PN+[2λ��]+[2λ��]','a','PN+[2λ��]+[2λ��]+[@����1]+[��ĸ��ˮ��]','b')

declare @sNewBillNo varchar(50),@s varchar(50)
EXEC dbo.sppbGenerateBillNo 1,'ZZ',0,1,0,@sNewBillNo output,@s output
select @sNewBillNo,@s

declare @sNewBillNo varchar(50),@s varchar(50)
EXEC dbo.sppbGenerateBillNo 1,'ZZ',0,1,10,@sNewBillNo output
select @sNewBillNo

*/