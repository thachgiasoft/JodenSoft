CREATE FUNCTION dbo.sysGetOrganizationCode(@OrganizationId int)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @Code NVARCHAR(MAX)
	SELECT @Code= Code FROM [dbo].[sysOrganization] WITH(NOLOCK) WHERE Iden=@OrganizationId
	RETURN @Code
END