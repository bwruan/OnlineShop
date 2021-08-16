-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Get Account By Email
-- =============================================
CREATE PROCEDURE dbo.GetAccountByEmail
(
	@email varchar(50)
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Account
	Where Email = @email
END
GO