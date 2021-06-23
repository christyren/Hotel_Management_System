use Final


insert into Roomtype values('Deluxe',100);
insert into Roomtype values('Medium Deluxe',200);
insert into Roomtype values('Super Deluxe',300); 
select * from roomtype;

insert into Room values(1,1);
insert into Room values(2,1);
insert into Room values(2,0);
insert into Room values(3,1);
insert into Room values(3,0);
select * from Room;

insert into Roomservice values(1,'clean',10,'2021-06-21');
insert into Roomservice values(2,'super clean',20,'2021-06-21');
insert into Roomservice values(2,'food',10,'2021-06-21');
insert into Roomservice values(3,'super food',20,'2021-06-21');
insert into Roomservice values(4,'luggage',10,'2021-06-21');
insert into Roomservice values(5,'morning call',10,'2021-06-21');
insert into Roomservice values(5,'delivery',10,'2021-06-21');

INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(1,'Christy','Pershing1 Avenue','123456789','christy1@antra','2021-06-21','1','2','100');
INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(2,'Saige','Pershing2 Avenue','123456789','saige@antra','2021-06-22','1','2','100');
INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(2,'Amy','Pershing3 Avenue','123456789','amy@antra','2021-06-23','1','2','100');
INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(3,'Alex','Pershing4 Avenue','123456789','alex@antra','2021-06-24','1','2','100');
INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(4,'Charles','Pershing5 Avenue','123456789','charles@antra','2021-06-25','1','2','100');
INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(5,'Nancy','Pershing6 Avenue','123456789','nancy@antra','2021-06-26','1','2','100');
INSERT INTO [dbo].[Customer] ([RoomNo],[CName],[Address],[Phone],[Email],[Checkin],[TotalPersons],[BookingDays],[Advance]) values(5,'Tom','Pershing7 Avenue','123456789','tom@antra','2021-06-27','1','2','100');

use Final;
select * from [Roomservice];

select * from Room;
select * from Roomservice;
