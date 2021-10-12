-- =============================================
-- Author:		Becky Ruan
-- Create date: 10/11/2021
-- Description:	Get list of card type
-- =============================================
CREATE PROCEDURE dbo.GetCardTypes 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.CardType;
END
GO
