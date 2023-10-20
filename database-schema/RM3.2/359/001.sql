USE [PaaSystem]

-- Add column Action Status for Invoice
GO
ALTER TABLE [dbo].[application]
ADD client_applied_name nvarchar(255);
