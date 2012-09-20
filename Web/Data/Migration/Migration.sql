
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

 