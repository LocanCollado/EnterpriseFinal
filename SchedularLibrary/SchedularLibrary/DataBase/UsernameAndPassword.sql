/*
This SQL query is to add a table to the database that has a user_ID that is auto incremented.
It also is able to Drop the table
It also adds an Email, Username, Password that are all string variables.
This query also includes in an insert statement that is able to insert a Row of data pertaining to the variable of Email, Username, and Password.
 Also this query includes a SELECT statement that is able to pull the values of all of the fields in the table.
*/
DROP TABLE user_login;
Create Table user_login ( User_ID int not null Identity(1,1) Primary Key,Email varchar(50) , Username Varchar(20) not null, [password] varchar(20));

insert into user_login( Email, Username, [password])
Values ('locancollado@gmail.com','locan', 'twistedlion15');

SELECT * 
  FROM [EnterpriseFinalBBB].[dbo].[user_login]

  Where User_ID= 1 OR Email='locancollado@gmail.com' And Username = 'locan' And [Password]='twistedlion15'