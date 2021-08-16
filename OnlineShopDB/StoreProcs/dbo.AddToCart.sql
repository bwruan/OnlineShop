-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Add to Cart
-- =============================================
CREATE PROCEDURE dbo.AddToCart
(
	@itemId bigint,
	@accountId bigint,
	@amount int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (select 1 from dbo.Account where AccountId = @accountId)
	BEGIN
		IF EXISTS (select 1 from dbo.Item where ItemId = @itemId)
		BEGIN
			INSERT INTO dbo.Cart
			(
				ItemId,
				AccountId,
				Amount
			)
			VALUES
			(
				@itemId,
				@accountId,
				@amount
			);
		END
	END	
END
GO