-- =============================================
-- Author:		Becky Ruan
-- Create date: 10/11/2021
-- Description:	Get Payment List By Account
-- =============================================
CREATE PROCEDURE dbo.GetPaymentsByAccountId
(
	@accountId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.PaymentInfo
	Where AccountId = @accountId;
END
GO
