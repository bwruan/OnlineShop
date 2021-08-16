-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Delete Shipping Address
-- =============================================
CREATE PROCEDURE dbo.DeleteShippingAddress
(
	@addressId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE from dbo.Address
	WHERE AddressId = @addressId
END
GO
