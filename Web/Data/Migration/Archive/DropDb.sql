

use Template




IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLog]') AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE [dbo].[InsertLog] 
GO  
 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Schema]')  AND type IN ( N'U' ) )  drop table [Schema] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[PackPart]')  AND type IN ( N'U' ) )  drop table [PackPart]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Pack]')  AND type IN ( N'U' ) )  drop table [Pack]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Part]')  AND type IN ( N'U' ) )  drop table [Part]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Accessory]')  AND type IN ( N'U' ) )  drop table [Accessory]


GO  

print ' ' 
print 'finished dropping all tables'
print ' '

