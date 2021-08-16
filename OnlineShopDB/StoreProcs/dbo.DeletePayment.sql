-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/16/2021
-- Description:	Remove payment info
-- =============================================
CREATE PROCEDURE dbo.DeletePayment 
(
	@paymentId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT 1 FROM dbo.PaymentInfo where PaymentId = @paymentId)
	BEGIN
		DELETE FROM dbo.PaymentInfo
		WHERE PaymentId = @paymentId
	END
END
GO
