DROP TABLE Calander;
DROP Table Classes;
Drop Table Rooms;
CREATE TABLE Calender( year varchar,month varchar,week nvarchar,day varchar);
CREATE TABLE Classes( Class_ID int not null primary key,class varchar, Course varchar);
CREATE TABLE Rooms(Room_ID int not null Primary KEY,Room_Name nvarchar);

INSERT INTO calender (year,month,week,day)
VALUES (value1,value2,value3, value4);

INSERT INTO Classes (class_ID,class, Course)
VALUES (value1,value2,value3);
INSERT INTO Rooms (Room_ID,Room_Name)
VALUES (value1,value2);