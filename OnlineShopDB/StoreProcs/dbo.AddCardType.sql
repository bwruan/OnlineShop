-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Add Card Type
-- =============================================
CREATE PROCEDURE dbo.AddCardType
(
	@name varchar(25)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (select 1 from dbo.CardType where Name = @name)
	BEGIN
		INSERT INTO dbo.CardType
		(
			Name
		)
		VALUES
		(
			@name
		);
	END	
END
GO
