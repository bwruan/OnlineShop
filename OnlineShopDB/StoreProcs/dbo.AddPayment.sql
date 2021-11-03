-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/16/2021
-- Description:	Add payment info
-- =============================================
CREATE PROCEDURE dbo.AddPayment 
(
	@name varchar(25),
	@cardNum varchar(16),
	@securityCode varchar(3),
	@expDate varchar(25),
	@cardTypeId int,
	@accountId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (SELECT 1 FROM dbo.Account where AccountId = @accountId)
	BEGIN
		INSERT INTO dbo.PaymentInfo
		(
			NameOnCard,
			CardNumber,
			SecurityCode,
			ExpDate,
			CardTypeId,
			AccountId
		)
		VALUES
		(
			@name,
			@cardNum,
			@securityCode,
			@expDate,
			@cardTypeId,
			@accountId
		)
	END
END
GO
