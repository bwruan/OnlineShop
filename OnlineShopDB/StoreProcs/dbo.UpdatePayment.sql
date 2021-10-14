-- =============================================
-- Author:		Becky Ruan
-- Create date: 10/11/2021
-- Description:	UpdatePayment
-- =============================================
CREATE PROCEDURE dbo.UpdatePayment 
(
	@paymentId bigint,
	@newName varchar(25),
	@newCardNum varchar(16),
	@newSecCode varchar(3),
	@newExpDate datetime2(7),
	@newBillName varchar(50),
	@newBillUnit varchar(50),
	@newBillCity varchar(50),
	@newBillState varchar(50),
	@newBillZip varchar(50),
	@newTypeId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (select 1 from dbo.PaymentInfo where PaymentId = @paymentId)
	BEGIN
		Update dbo.PaymentInfo
		Set NameOnCard = @newName,
		CardNumber = @newCardNum,
		SecurityCode = @newSecCode,
		ExpDate = @newExpDate,
		BillingName = @newBillName,
		BillingUnit = @newBillUnit,
		BillingCity = @newBillCity,
		BillingState = @newBillState,
		BillingZipcode = @newBillZip,
		CardType = @newTypeId
		WHERE PaymentId = @paymentId
	END
END
GO
