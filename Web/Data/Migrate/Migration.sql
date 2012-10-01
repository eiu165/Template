


use Template



IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_Roles]') AND type in (N'U'))  
begin 
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
Insert into webpages_Roles (  RoleName) values ( 'Dev'),( 'Admin'),( 'User')
end
GO



IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_OAuthMembership]') AND type in (N'U'))  
begin 
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
end
GO




IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))  
begin 
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](200) NULL 
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO [UserProfile] ([UserName]) VALUES ('a'), ('b'), ('c')
end
GO
  
 if not Exists(select * from sys.columns where Name = N'City' and Object_ID = Object_ID(N'UserProfile'))
 begin    
	alter table [UserProfile] Add   [City] [nvarchar](200) NULL 
 end




IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_Membership]') AND type in (N'U'))  
begin 
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL  DEFAULT ((0)) ,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL  DEFAULT ((0)) ,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO [webpages_Membership] ( [UserId]  ,[IsConfirmed]  ,[Password],[PasswordSalt]  ) VALUES
 ( 1,1, 'AB+Sytkyrv8MSXetbMqr9OM7PPU52Ooz/l6zpftGNt3kCavZnF7IOyIeZXtEdAh+Sw==', '') 
,( 2,1, 'AB+Sytkyrv8MSXetbMqr9OM7PPU52Ooz/l6zpftGNt3kCavZnF7IOyIeZXtEdAh+Sw==', '')
,( 3,1, 'AB+Sytkyrv8MSXetbMqr9OM7PPU52Ooz/l6zpftGNt3kCavZnF7IOyIeZXtEdAh+Sw==', '')
end 
GO










IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[webpages_UsersInRoles]') AND type in (N'U'))  
begin 
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 
/****** Object:  ForeignKey [fk_RoleId]    Script Date: 09/23/2012 09:56:47 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId]) 
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId] 
/****** Object:  ForeignKey [fk_UserId]    Script Date: 09/23/2012 09:56:47 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId]) 
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
INSERT INTO [webpages_UsersInRoles] ([UserId] ,[RoleId])  VALUES (1, 1), (2, 2), (3, 3) 
end 
GO
 











 
if not exists (select * from webpages_Roles where RoleName = 'Admin')
begin
	insert into webpages_Roles ([RoleName]) values ('Admin')
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



