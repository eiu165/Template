
use Template


 
if not exists (select * from webpages_Roles where RoleName = 'SecurityGuard')
begin
	insert into webpages_Roles ([RoleName]) values ('SecurityGuard')
end 
else  
begin
	print 'already there'
end


if not exists (select * from webpages_UsersInRoles where [UserId] = 1 and [RoleId] = 1)
begin
	insert into webpages_UsersInRoles ([UserId], [RoleId]) values (1,1)
end 
else  
begin
	print 'already there'
end 

 
 
IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Schema]') AND type in (N'U'))  
begin 
print 'creating Schema '  
CREATE TABLE [dbo].[Schema](
	[Id] [int] IDENTITY(1, 1) NOT NULL , 
	[Version] [bigint] NOT NULL,
	[UtcDate]  [datetime] DEFAULT (GETUTCDATE()),
	[BuildNumber] [nvarchar](100)  , 
	[Status] [nvarchar](50) NULL ,
	[CreatedAt] [datetime] not null default(GETUTCDATE()) ,
	[UpdatedAt] [datetime]  not null default(GETUTCDATE())  
) ;
end
INSERT [Schema] ([Version] ) Values(1 )
GO
 

-------------------------------------
print 'Domain Specific Tables'  
-------------------------------------


IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Accessory]')  AND type IN ( N'U' ) )  
begin
print 'creating Accessory '  
CREATE TABLE [dbo].[Accessory](
	[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],
	[Name] [nvarchar](50) NULL,  
	[UpdatedAt] [datetime]  not null default(GETUTCDATE()) 
	) ON [PRIMARY]
INSERT INTO  [Accessory] ( [Name]  ) VALUES  
('Headlights'  ) ,('Side Mirror'   ) ,('Wheel Cover'  ) ,('Seat Cover'  ) ,('Head Rest' )  ,('Cup Holder'  ) 
end
GO



IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Part]')  AND type IN ( N'U' ) )  
begin 
CREATE TABLE [dbo].[Part](
	[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY], 
	[AccessoryId] [int] , 
	[Name] [nvarchar](50) NULL,  
	[Number] [nvarchar](50) NULL,  
	[Color] [nvarchar](50) NULL, 
	[UpdatedAt] [datetime]  not null default(GETUTCDATE()) 
	) ON [PRIMARY] 
ALTER TABLE dbo.[Part] ADD CONSTRAINT FK_Part_Accessory FOREIGN KEY (AccessoryId) REFERENCES dbo.Accessory (Id) ON UPDATE CASCADE ON DELETE CASCADE 
INSERT INTO  [Part] ([AccessoryId], [Name], [Number], [Color]  ) VALUES  
(1 ,'Headlights 00sdf9324' , '0000001', 'Blue' )  
end
GO


IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[Pack]')  AND type IN ( N'U' ) )  
begin
print 'creating Pack '  
CREATE TABLE [dbo].[Pack](
	[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],  
	[Name] [nvarchar](50) NULL,    
	[Color] [nvarchar](50) NULL,  
	[Cost] [money]  NULL, 
	[UpdatedAt] [datetime]  not null default(GETUTCDATE()) 
	) ON [PRIMARY]  
INSERT INTO  [Pack] ( [Name],  [Color]  ,  [Cost]  ) VALUES  
( 'High roller pack' , 'Blue', 1000000 )  
end
GO





IF not  EXISTS ( SELECT  * FROM    sys.objects  WHERE   object_id = OBJECT_ID(N'[dbo].[PackPart]')  AND type IN ( N'U' ) )  
begin
print 'creating PackPart '  
CREATE TABLE [dbo].[PackPart](
	[Id] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY  CLUSTERED (	[ID] ASC) ON [PRIMARY],  
	[PackId] [int] , 
	[PartId] [int] , 
	[UpdatedAt] [datetime]  not null default(GETUTCDATE()) 
	) ON [PRIMARY]  
ALTER TABLE dbo.[PackPart] ADD CONSTRAINT FK_PackPart_Pack FOREIGN KEY (PackId) REFERENCES dbo.Pack (Id) ON UPDATE CASCADE ON DELETE CASCADE 
ALTER TABLE dbo.[PackPart] ADD CONSTRAINT FK_PackPart_Part FOREIGN KEY (PartId) REFERENCES dbo.Part (Id) ON UPDATE CASCADE ON DELETE CASCADE 
end
GO

