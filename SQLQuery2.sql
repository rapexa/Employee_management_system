CREATE PROCEDURE ReportJobs

AS
BEGIN
	select * from Jobs
	order by idJob
END
GO
