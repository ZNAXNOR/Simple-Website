USE MASTER;
GO

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Title]
      ,[Description]
      ,[ledger_start_transaction_id]
      ,[ledger_end_transaction_id]
      ,[ledger_start_sequence_number]
      ,[ledger_end_sequence_number]
  FROM [SimpleWebsiteLedgerDb].[dbo].[MSSQL_LedgerHistoryFor_901578250]