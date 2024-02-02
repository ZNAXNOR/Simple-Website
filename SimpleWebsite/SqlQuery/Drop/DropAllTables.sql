USE SimpleWebsiteLedgerDb;
GO

-- disable all constraints
--EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

-- enable all constraints
--exec sp_MSforeachtable @command1="print '?'", @command2="ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all"

EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

DROP TABLE Posts;
DROP TABLE Tags;
DROP TABLE PostTags;