
IF OBJECT_ID('dbo.sysGenerateBillNo') IS NOT NULL 
DROP PROC dbo.sysGenerateBillNo
GO

create procedure dbo.sysGenerateBillNo
(
  @BillNoType varchar(50)                  --流水号类别
 ,@DynamicContent varchar(50) = ''         --动态内容
 ,@BillNo NVARCHAR(100) OUTPUT             --单据号输出
 ,@Return BIT=0							   --单据号是否做为数据集返回
)
as
begin
    /*
     --流水号一般规则:流水号 = 前缀+动态内容+日期+中缀+流水号+后缀。
     --动态内容一般是执行存储过程取流水号的时候动态传入的
     插入内容示例:

	 delete sysBillNo
     insert into sysBillNo([BillNoType],[IdenLength],[ResetType],[Separator],[Prefix],[YearFormat],
                                       [MonthFormat],[DayFormat],[Midfix],[CurrentIden],[CurrentDate],[Suffix])
     values('sdOrderNo',4,'month','','sd','yy','mm','dd','',0,getdate(),'')
  
     exec sysGenerateBillNo 'sdOrderNo','','',1
  
    */
 set nocount on;
 set transaction isolation level serializable; 

 declare   @Now datetime
          ,@IdenLength int
          ,@ResetType varchar(50)
          ,@Separator varchar(50)
          ,@Prefix varchar(50)
          ,@YearFormat varchar(50)
          ,@MonthFormat varchar(50)
          ,@DayFormat varchar(50)
          ,@Midfix varchar(50)
          ,@CurrentIden int
          ,@CurrentIdenFirstback int
          ,@CurrentDate datetime
          ,@Suffix varchar(50)    
          ,@DateStr varchar(50);
    
 begin tran
    
 --读取配置信息
 select    @Now = getdate()           
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
 from sysBillNo 
 WHERE BillNoType=@BillNoType;
 
 if @@rowcount = 0
 begin
   raiserror('无相应的流水号类别,请确认@BillNoType参数值是否正确!',16,1);
 end
   
 if @ResetType<>'' 
 begin  
  set @datestr =   case @YearFormat 
                            when 'yyyy' then cast(year(@Now) as varchar(50)) else right(cast(year(@Now) as varchar(50)),2) end
                 + case @MonthFormat 
                            when 'mm' then right('0'+ cast(month(@Now) as varchar(50)),2) else cast(month(@Now) as varchar(50)) end
                 + case @DayFormat 
                            when 'dd' then right('0'+ cast(day(@Now) as varchar(50)),2) else cast(day(@Now) as varchar(50)) end
  
 end
 
 if convert(varchar(8), @Now, 112) = convert(varchar(8), @CurrentDate, 112)   
  set @CurrentIden = @CurrentIden + 1; 
 else
 begin
  set @CurrentIden = 1; --归1
  set @CurrentIdenFirstback = 0;
 END
 

SET @BillNo= @prefix 
        + @separator
        + @DynamicContent 
        + case @DynamicContent when '' then '' else @separator end
        + @datestr
        + case @datestr when '' then '' else @separator end
        + @midfix 
        + case @midfix when '' then '' else @separator end
        + right( replicate('0',@IdenLength)
                    +cast(@CurrentIdenFirstback+1 as varchar(50)),@IdenLength)
        + case @suffix when '' then '' else @separator end
        + @suffix
  
       
 update sysBillNo 
 set CurrentDate  = @CurrentDate 
     ,CurrentIden=@CurrentIden
 where BillNoType=@BillNoType;
    
 commit tran

 IF @Return<>0
 --获取流水号
 SELECT BillNo= @BillNo

end