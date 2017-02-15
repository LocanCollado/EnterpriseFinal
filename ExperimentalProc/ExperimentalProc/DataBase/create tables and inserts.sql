DROP TABLE Calender;
DROP Table Classes;
Drop Table Rooms;
CREATE TABLE Calender( year int,month int,week int,day int);
CREATE TABLE Classes( Class_ID int not null primary key,class varchar, Course varchar);
CREATE TABLE Rooms(Room_ID int not null Primary KEY,Room_Name varchar(20));
CREATE TABLE Schedule(List_ID int not null primary key, Class_ID int not null foreign key (class_ID) references Classes(Class_ID),
Room_ID int not null foreign key (Room_ID) references Rooms(Room_ID),year int,month int,week int,day int, Start_Time varchar(5), End_Time varchar(5));


INSERT INTO calender (year,month,week,day)
VALUES (2017,2,52,10);
INSERT INTO Classes (class_ID,class, Course)
VALUES (value1,value2,value3);
INSERT INTO Rooms (Room_ID,Room_Name)
VALUES (44,'Art Room');