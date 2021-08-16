-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Update Account
-- =============================================
CREATE PROCEDURE dbo.UpdateAccount
(
	@accountId bigint,
	@newName varchar(25),
	@newEmail varchar(50),
	@newPassword varchar(32),
	@newUpdatedDate datetime2(7)
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
		Set Name = @newName,
		Email = @newEmail,
		Password = @newPassword,
		UpdatedDate = @newUpdatedDate
		WHERE AccountId = @accountId
	END
END
GO
