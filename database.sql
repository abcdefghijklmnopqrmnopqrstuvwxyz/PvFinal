go
create procedure add_user @name varchar(255), @password varchar(255), @success int output
as
begin
	declare @countuser int = 0;
	set @countuser = (select count(id) from users where name = @name);
	if (@countuser = 0)
		begin
			insert into users(name, password)
				values
					(@name, @password);
				set @success = 1;
		end
	else
		begin
			set @success = 0;
		end
end;
go


go
create procedure login_user @name varchar(255), @password varchar(255), @success int output
as
begin
	declare @countuser int = 0;
	set @countuser = (select count(id) from users where name = @name and password = @password);
	if (@countuser = 1)
		begin
			set @success = 1;
		end
	else
		begin
			set @success = 0;
		end
end;
go