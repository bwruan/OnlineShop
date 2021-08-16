-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Add Address
-- =============================================
CREATE PROCEDURE dbo.AddAddress
(
	@shipping varchar(50),
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
		INSERT INTO dbo.Address
		(
			Shipping,
			AccountId
		)
		VALUES
		(
			@shipping,
			@accountId
		);
	END	
END
GO