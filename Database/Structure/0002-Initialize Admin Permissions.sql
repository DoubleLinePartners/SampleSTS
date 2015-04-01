USE [SampleSTSAuthentication]
GO

-- Enables admin services to retrieve data
--  before executing please change the password below

-- Create the login if necessary
IF NOT EXISTS (SELECT loginname FROM master.dbo.syslogins WHERE name = 'stsAdmin')
BEGIN
  CREATE LOGIN [stsAdmin] WITH PASSWORD=N'stsAdmin', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END
GO

IF EXISTS (SELECT 1 from master.dbo.syslogins where loginname='stsAdmin' union select 1 from sysusers where name='stsAdmin')
BEGIN
  IF NOT EXISTS
    (SELECT name
     FROM sys.database_principals
     WHERE name = 'stsAdmin')
  BEGIN
     CREATE USER [stsAdmin] FOR LOGIN [stsAdmin] WITH DEFAULT_SCHEMA=[dbo]
  END
  ALTER ROLE [db_datareader] ADD MEMBER [stsAdmin]
  ALTER ROLE [db_datawriter] ADD MEMBER [stsAdmin]
  EXEC sp_addrolemember N'db_owner', N'stsAdmin'
END
GO
