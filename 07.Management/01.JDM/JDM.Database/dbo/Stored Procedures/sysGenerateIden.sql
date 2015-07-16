
CREATE PROCEDURE [dbo].[sysGenerateIden]
(
	@GroupName nvarchar(500),
	@Count int = 1,
	@Iden int =0 OUTPUT,
	@Save bit = 1,
	@Return bit=1,
	@StartIden int =0
)
AS
BEGIN TRY
    SET NOCOUNT ON;
	DECLARE @Insert bit
	DECLARE @Error NVARCHAR(100)
	
	IF @Count IS NULL or @Count<=0
	SET @Count=1
	
	IF @StartIden IS NULL OR @StartIden<=0
	SET @StartIden=0
	
	BEGIN TRAN ;
	SET @Iden=0
	SELECT @Iden=ISNULL(MaxIden,0) 
	FROM dbo.sysIden WITH (UPDLOCK)
	WHERE GroupName=@GroupName

	SET @Insert=0
	IF @Iden IS NULL or @Iden=0
	BEGIN
		SET @Iden=0
		SET @Insert=1
	END
	IF @Iden<@StartIden
		SET @Iden=@StartIden
	
	IF @Save=1 
	BEGIN
		IF @Insert=1
			INSERT INTO dbo.sysIden([GroupName],[MaxIden]) 
			VALUES(@GroupName,@Iden+@Count) 
		ELSE
			UPDATE dbo.sysIden 
			SET MaxIden=@Iden+@Count
			WHERE GroupName=@GroupName
	END
	COMMIT TRAN ;
	SET @Iden=@Iden+1
	if @Return=1 
		SELECT Iden=@Iden

END TRY
BEGIN CATCH
    DECLARE @sErrorMessage NVARCHAR(MAX)
    SET @sErrorMessage=ERROR_MESSAGE()+CHAR(10)+LTRIM(STR(ERROR_NUMBER()))+'='+ISNULL(ERROR_PROCEDURE(),'')+'.'+LTRIM(STR(ERROR_LINE()))
    RAISERROR(@sErrorMessage,16,1)
END CATCH
