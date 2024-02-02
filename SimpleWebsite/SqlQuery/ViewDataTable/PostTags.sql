USE SimpleWebsiteLedgerDb;
GO

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *
      ,[ledger_start_transaction_id]
      ,[ledger_end_transaction_id]
      ,[ledger_start_sequence_number]
      ,[ledger_end_sequence_number]
FROM [SimpleWebsiteLedgerDb].[dbo].[PostTags]