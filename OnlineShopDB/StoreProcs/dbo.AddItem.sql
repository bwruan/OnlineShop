-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Add Item
-- =============================================
CREATE PROCEDURE dbo.AddItem
(
	@name varchar(50),
	@price smallmoney,
	@quantity int,
	@picutre varbinary(max),
	@itemTypeId int,
	@sellerId bigint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Item
	(
		Name,
		Price,
		Quantity,
		Picture,
		ItemType,
		SellerId
	)
	VALUES
	(
		@name, 
		@price, 
		@quantity, 
		@picutre,
		@itemTypeId,
		@sellerId
	)
END
GO
