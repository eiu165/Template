 
use Template




IF EXISTS ( SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLog]') AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE [dbo].[InsertLog] 
GO  
 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Schema]')		AND type IN ( N'U' ) )  drop table [Schema] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[PackPart]')	AND type IN ( N'U' ) )  drop table [PackPart]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Pack]')		AND type IN ( N'U' ) )  drop table [Pack]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Part]')		AND type IN ( N'U' ) )  drop table [Part]
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Accessory]')  AND type IN ( N'U' ) )  drop table [Accessory]


 

IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[webpages_UsersInRoles]')		AND type IN ( N'U' ) )  drop table [webpages_UsersInRoles] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[webpages_Roles]')		AND type IN ( N'U' ) )  drop table [webpages_Roles] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[webpages_OAuthMembership]')		AND type IN ( N'U' ) )  drop table [webpages_OAuthMembership] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[webpages_Membership]')		AND type IN ( N'U' ) )  drop table [webpages_Membership] 
IF EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[UserProfile]')		AND type IN ( N'U' ) )  drop table [UserProfile] 
 
GO  

print ' ' 
print 'finished dropping all tables'
print ' '
GO  

