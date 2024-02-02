USE SimpleWebsiteLedgerDb;
GO

/****** Script for Ledger View in MS document ******/
SELECT
 t.[commit_time] AS [CommitTime] 
 , t.[principal_name] AS [UserName]
 , l.[Id]
 , l.[Title]
 , l.[Description]
 , l.[ledger_operation_type_desc] AS Operation
 FROM [dbo].[Tags_Ledger] l
 JOIN sys.database_ledger_transactions t
 ON t.transaction_id = l.ledger_transaction_id
 ORDER BY t.commit_time DESC;