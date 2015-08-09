CREATE FUNCTION [dbo].[Dual]
(
	@Count INT
)
RETURNS @returnTable TABLE
(
	Item INT
)
WITH ENCRYPTION
AS
BEGIN	
	IF @Count<0
	SET @Count=0

	DECLARE @index INT
	SET @index=1
	
	WHILE(@index<=@Count)
	BEGIN
		INSERT @returnTable(Item)
		VALUES( @index)

		SET @index=@index+1
	END

	RETURN
END
