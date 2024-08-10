RESTORE DATABASE [SimpleAdmin] FROM  
DISK = N'/tmp/DamaRozePos.bak' WITH  FILE = 1,
MOVE N'DamaRozePos' to '/var/opt/mssql/data/DamaRozePos.mdf',
MOVE N'DamaRozePos_log' to '/var/opt/mssql/data/DamaRozePos_log.ldf',
NOUNLOAD, REPLACE, STATS=5 
GO

