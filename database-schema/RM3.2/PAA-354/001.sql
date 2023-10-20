USE [PaaSystem]

-- Add column Action Status for Invoice
GO
ALTER TABLE [dbo].[invoice]
ADD action_status tinyint;

-- Update value of Action Status column as None for all invoices
GO
update [dbo].[invoice] set action_status = 0;