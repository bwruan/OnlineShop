-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Update Shipping Address
-- =============================================
CREATE PROCEDURE dbo.UpdateShippingAddress
(
	@addressId bigint,
	@newShipping varchar(50),
	@accountId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (select 1 from dbo.Account where AccountId = @accountId)
	BEGIN
		IF EXISTS (select 1 from dbo.Address where AddressId = @addressId)
		BEGIN
			Update dbo.Address
			Set Shipping = @newShipping
			WHERE AddressId = @addressId
		END
	END
END
GO
