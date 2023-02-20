USE University
go
CREATE TABLE Table_Grupa(
ID_Grupa INT NOT NULL PRIMARY KEY,
ID_Kafedra INT NULL,
Name_Grupa nchar(10) NULL,
Max_count_students INT NULL,
Pball FLOAT NULL)

CREATE TABLE Table_Kafedra(
ID_Kafedra INT NOT NULL PRIMARY KEY,
ID_Teacher_Zav_Kaf INT NOT NULL,
Name_Kafedra nchar(255) NULL,
Phone_Kafedra nchar(13) NULL)

CREATE TABLE Table_Student(
ID_Student INT NOT NULL PRIMARY KEY,
ID_Grupa INT NULL,
Number INT NULL,
First_name_student nchar(50) NULL,
Last_name_student nchar(50) NULL,
Birth_date_student date NULL,
Adress_student nchar(255) NULL,
Pball_student float NULL)

