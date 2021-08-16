-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Update status - Log In/ Log Out
-- =============================================
CREATE PROCEDURE dbo.UpdateStatus
(
	@accountId bigint,
	@email varchar(50),
	@password varchar(32),
	@status bit
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS (select 1 from dbo.Account where AccountId = @accountId)
	BEGIN
		Update dbo.Account
		Set Status = @status
		Where AccountId = @accountId
		and Email = @email
		and Password = @password
	END	
END
GO
