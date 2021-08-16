-- =============================================
-- Author:		Becky Ruan
-- Create date: 08/15/2021
-- Description:	Create Account
-- =============================================
CREATE PROCEDURE dbo.CreateAccount (
	@name varchar(25),
	@email varchar(50),
	@password varchar(32),
	@status bit,
	@createdDate datetime2(7),
	@updatedDate datetime2(7)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (select 1 from dbo.Account Where Email = @email)
	BEGIN
		INSERT INTO dbo.Account
		(
			Name,
			Email,
			Password,
			Status,
			CreatedDate,
			UpdatedDate
		)
		VALUES
		(
			@name,
			@email,
			@password,
			@status,
			@createdDate,
			@updatedDate
		);
	END
END
GO
