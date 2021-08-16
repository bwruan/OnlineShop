-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Get Account By Id
-- =============================================
CREATE PROCEDURE dbo.GetAccountById
(
	@accountId bigint
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Account
	Where AccountId = @accountId
END
GO
