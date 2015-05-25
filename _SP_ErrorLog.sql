use [RentApartments]
Go
Create PROCEDURE [sp_HandleSPErrors]
	 @IO_ErrCode	INT				OUTPUT
	,@IO_ErrMsg		VARCHAR(8000)	OUTPUT
AS
SET NOCOUNT ON
BEGIN
 
	DECLARE @iErrCode INT
    SET 	@iErrCode	= 0

	IF @IO_ErrCode IS NULL OR @IO_ErrCode = 0  SET @IO_ErrCode = ERROR_NUMBER()
	IF @IO_ErrMsg  IS NULL OR @IO_ErrMsg  = '' SET @IO_ErrMsg  = ISNULL(ERROR_MESSAGE(),'')

	BEGIN TRY

		INSERT INTO DB_Errors_Log (
				DBERRL_DateTime,
				DBERRL_ErrCode,
				DBERRL_ErrMsg,
				DBERRL_Severity,
				DBERRL_APP,
				DBERRL_Server,
				DBERRL_DB,
				DBERRL_SP,
				DBERRL_USER,
				DBERRL_HOST,
				DBERRL_LineNumber,
				DBERRL_NativeErrCode,
				DBERR_InstanceName
		)
		VALUES(
				GETUTCDATE(),
				@IO_ErrCode,
				@IO_ErrMsg,
				ISNULL(ERROR_SEVERITY(),0),
				ISNULL(APP_NAME(),''),
				ISNULL(@@servername,''),
				ISNULL(DB_NAME(),''),
				ISNULL(ERROR_PROCEDURE(),''),
				ORIGINAL_LOGIN(),
				HOST_NAME(),
				ERROR_LINE(),
				ERROR_NUMBER(),
				'SPID '+CONVERT(VARCHAR,@@SPID)
		)	
	
	END TRY
	BEGIN CATCH
	
		SELECT	 @iErrCode  = 1
				,@IO_ErrMsg = @IO_ErrMsg + ' Logging error: ' + ISNULL(ERROR_MESSAGE(),'')
	
	END CATCH
	
	RETURN @iErrCode
END
