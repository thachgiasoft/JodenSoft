
IF OBJECT_ID('dbo.sysGenerateBillNo') IS NOT NULL 
	DROP PROC dbo.sysGenerateBillNo
GO

CREATE PROCEDURE dbo.sysGenerateBillNo
(
@BillNoType VARCHAR(50)                  --流水号类别
,@DynamicContent VARCHAR(50) = ''         --动态内容
,@BillNo NVARCHAR(100) OUTPUT             --单据号输出
,@Return BIT=0							   --单据号是否做为数据集返回
)
AS 
BEGIN 
/*
    --流水号一般规则:流水号 = 前缀+动态内容+日期+中缀+流水号+后缀。
    --动态内容一般是执行存储过程取流水号的时候动态传入的
    插入内容示例:

	delete sysBillNo
    insert into sysBillNo([BillNoType],[IdenLength],[ResetType],[Separator],[Prefix],[YearFormat],
                                    [MonthFormat],[DayFormat],[Midfix],[CurrentIden],[CurrentDate],[Suffix])
    values('sdOrderNo',4,'month','','sd','yy','mm','dd','',0,getdate(),'')
  
    exec sysGenerateBillNo 'sdOrderNo2','','',1
  
*/

SET  NOCOUNT  ON 
SET  TRANSACTION  ISOLATION  LEVEL  SERIALIZABLE  

DECLARE    @Now DATETIME 
        ,@IdenLength INT 
        ,@ResetType VARCHAR(50) 
        ,@Separator VARCHAR(50)
        ,@Prefix VARCHAR(50)
        ,@YearFormat VARCHAR(50)
        ,@MonthFormat VARCHAR(50)
        ,@DayFormat VARCHAR(50)
        ,@Midfix VARCHAR(50)
        ,@CurrentIden INT 
        ,@CurrentIdenFirstback INT 
        ,@CurrentDate DATETIME 
        ,@Suffix VARCHAR(50)    
        ,@DateStr VARCHAR(50);

BEGIN TRAN
    
--读取配置信息
SELECT    @Now = getdate()           
        ,@IdenLength = IdenLength
        ,@ResetType = ResetType
        ,@separator = Separator
        ,@prefix = Prefix
        ,@YearFormat = YearFormat           
		,@MonthFormat = MonthFormat
        ,@DayFormat = DayFormat
        ,@midfix = Midfix
        ,@CurrentIden = CurrentIden
        ,@CurrentIdenFirstback = CurrentIden
        ,@CurrentDate=CurrentDate
        ,@suffix = Suffix
        ,@datestr = ''         
FROM sysBillNo 
WHERE BillNoType=@BillNoType;
 
IF @@rowcount = 0
BEGIN
	RAISERROR('无相应的单据号类别,请确认@BillNoType参数值是否正确!',16,1);
	ROLLBACK
	RETURN
END
   
IF @ResetType<>'' 
BEGIN   
SET  @datestr =  CASE  @YearFormat 
                        WHEN 'yyyy' THEN cast(year(@Now) AS VARCHAR(50)) ELSE right(cast(year(@Now) AS VARCHAR(50)),2) END 
                + CASE  @MonthFormat 
                        WHEN 'mm' THEN right('0'+ cast(month(@Now) AS VARCHAR (50)),2) ELSE cast(month(@Now) AS VARCHAR(50)) END 
                + CASE  @DayFormat 
                        WHEN 'dd' THEN right('0'+ cast(day(@Now) AS  VARCHAR (50)),2) ELSE cast(day(@Now) AS VARCHAR(50)) END 
  
END 
 
IF  CONVERT(VARCHAR(8), @Now, 112) = CONVERT(VARCHAR(8), @CurrentDate, 112)   
	SET @CurrentIden = @CurrentIden + 1; 
ELSE BEGIN 
	SET @CurrentIden = 1; --归1
	SET @CurrentIdenFirstback = 0;
END

SET @BillNo= @prefix 
    + @separator
    + @DynamicContent 
    + CASE  @DynamicContent WHEN  '' THEN  '' ELSE  @separator END 
    + @datestr
    + CASE  @datestr WHEN  '' THEN  '' ELSE  @separator END 
    + @midfix 
    + CASE  @midfix WHEN  '' THEN  '' ELSE  @separator END 
    + right( REPLICATE('0',@IdenLength)
                +CAST(@CurrentIdenFirstback+1 AS VARCHAR(50)),@IdenLength)
    + CASE  @suffix WHEN  '' THEN  '' ELSE  @separator END 
    + @suffix

UPDATE sysBillNo 
SET CurrentDate  = @CurrentDate 
    ,CurrentIden=@CurrentIden
WHERE BillNoType=@BillNoType;
    
COMMIT TRAN

IF @Return<>0
--获取流水号
SELECT BillNo= @BillNo

END