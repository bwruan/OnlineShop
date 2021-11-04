-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Add Item
-- =============================================
CREATE PROCEDURE dbo.AddItem
(
	@name varchar(50),
	@price smallmoney,
	@picutre varbinary(max),
	@itemTypeId int
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
		Picture,
		ItemTypeId
	)
	VALUES
	(
		@name, 
		@price,  
		@picutre,
		@itemTypeId
	)
END
GO
