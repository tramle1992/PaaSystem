GO
ALTER TABLE [dbo].[credit_report]
ALTER COLUMN type varchar(50) not null;

GO
ALTER TABLE [dbo].[credit_report]
ALTER COLUMN pulled_by varchar(50) null;

