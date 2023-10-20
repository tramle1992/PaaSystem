-- Remove reference key of other tables to User table before executing User Migration function

delete from timecard;
delete from timecard_date;

-- Add new permission 

INSERT [dbo].[feature_permission] ([feature_id], [feature_name], [parent_feature_id]) VALUES (N'E2D9A8E7-7319-428F-BA62-4194A4C9DCA3', N'Block/Unblock Activity', '383d4ae6-70e2-4973-8371-8dbc0f3351aa')

--1. Run above command
--2. Execute User Migration in PAA system 
--3. Then, execute script 002.sql

