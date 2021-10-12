-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Add Address
-- =============================================
CREATE PROCEDURE dbo.AddAddress
(
	@customer varchar(50),
	@unitStreet varchar(50),
	@city varchar(50),
	@state varchar(25),
	@zipcode varchar(25),
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
			CustomerName,
			UnitStreet,
			City,
			State,
			Zipcode,
			AccountId
		)
		VALUES
		(
			@customer,
			@unitStreet,
			@city,
			@state,
			@zipcode,
			@accountId
		);
	END	
END
GO