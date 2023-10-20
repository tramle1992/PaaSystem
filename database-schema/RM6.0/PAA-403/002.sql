-- Add column Status Code for Credit Report
GO
ALTER TABLE [dbo].[credit_report]
ADD status_code varchar(50),
pulled_by nvarchar(max);