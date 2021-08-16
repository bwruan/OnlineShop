-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Get Shipping Addresses By Address Id
-- =============================================
CREATE PROCEDURE dbo.GetShippingAddressByAddressId
(
	@addressId bigint
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Address
	Where AddressId = @addressId
END
GO