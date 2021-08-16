-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Get all Shipping Addresses By AccountId
-- =============================================
CREATE PROCEDURE dbo.GetShippingAddressesByAccountId
(
	@accountId bigint
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Address
	Where AccountId = @accountId
END
GO