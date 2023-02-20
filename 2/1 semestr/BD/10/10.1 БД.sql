

CREATE DATABASE Laba_10
GO


USE Laba_10
GO




CREATE TABLE Student
(
	StudID INT NOT NULL,
	Groupid INT NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	DateOfBirth DATE NOT NULL,

	PRIMARY KEY (StudID)
);
GO

CREATE TABLE Learn
(
	PredmetID INT NOT NULL,
	TeacherName NVARCHAR(50) NOT NULL,
	HoursCount INT NOT NULL,

	PRIMARY KEY (PredmetID)
);
GO

CREATE TABLE SubjectSuccess
(
	StudID INT NOT NULL,
	PredmetID INT NOT NULL,
	Rating NVARCHAR(15) NULL,

	PRIMARY KEY (StudID, PredmetID)
);
GO


/* =============================================== */


ALTER TABLE SubjectSuccess
	ADD CONSTRAINT [CK_SubjectSuccess_Rating] CHECK (Rating='1'OR Rating='2'OR Rating='3'OR Rating='4'OR Rating='5'OR Rating='���������')
GO


/* =============================================== */


INSERT INTO Learn
	VALUES	(1001, '������ ��������� ��������',	180),
			(1002, '����� ���� �������������',	220),
			(1003, '������ ������ ���������',		340),
			(1004, '�������� ����� ���������', 230),
			(1005, '������ ³����� �������',	210),
			(1006, '�������� ������ ����������',		230),
			(1007, '�������� ������ ���������',	190),
			(1008, '��������� ����� �������������',	400),
			(1009, '������ ����� ��������',		90),
			(1010, '��������� �������� �������������',	80);
GO


SELECT * FROM Learn
GO


INSERT INTO Student
	VALUES	(10001, 140, '��������',		'��������',		'2003/12/22'),
			(10002, 114, '����',		'���������',		'2004/09/25'),
			(10003, 148, '���������',		'�����',		'2004/03/29'),
			(10004, 125, '������',		'���������',	'2002/05/06'),
			(10005, 121, '������',		'���������',	'2003/08/12'),
			(10006, 149, '������',		'������',		'2002/04/10'),
			(10007, 152, '�����',	'������',		'2001/02/28'),
			(10008, 178, '�������',		'��������',		'2003/09/22'),
			(10009, 144, '�����',	'������',		'2004/09/08'),
			(10010, 112, '³����',		'������',		'2003/01/12'),
			(10011, 144, '������',		'�����������',		'2004/12/25');
GO


SELECT * FROM Student
GO



INSERT INTO SubjectSuccess
	VALUES	(10001, 1007, '1'),
			(10003, 1009, NULL),
			(10010, 1010, '2'),
			(10008, 1003, '5'),
			(10011, 1008, '3'),
			(10008, 1001, '5'),
			(10009, 1007, '4'),
			(10004, 1002, NULL),
			(10005, 1005, '3'),
			(10007, 1001, '5');
GO


SELECT * FROM SubjectSuccess
GO



/* =============================================== */



DROP TABLE SubjectSuccess
DROP TABLE Student
DROP TABLE Learn
GO

