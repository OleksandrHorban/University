/* ================================= */

USE Laba_10
GO

/* ================================= */
/* =============== 1 =============== */

SELECT FirstName, LastName, Groupid
FROM Student

/* ================================= */
/* =============== 2 =============== */

SELECT *
FROM Learn
WHERE HoursCount > 130 AND HoursCount < 300

/* ================================= */
/* =============== 3 =============== */

SELECT *
FROM Student
WHERE MONTH(DateOfBirth) > 4 AND MONTH(DateOfBirth) < 9

/* ================================= */
/* =============== 4 =============== */

SELECT *
FROM Student
WHERE LastName LIKE '%ов'

/* ================================= */
/* =============== 5 =============== */

SELECT Groupid AS Група, COUNT(Groupid) AS [Кількість студентів]
FROM Student
GROUP BY Groupid


/* ================================= */
/* =============== 7 =============== */

SELECT S.FirstName, S.LastName, L.PredmetID, L.TeacherName, SS.Rating
FROM Student S, Learn L, SubjectSuccess SS
WHERE S.StudID = SS.StudID AND L.PredmetID = SS.PredmetID

/* ================================= */
/* =============== 8 =============== */

INSERT INTO Student
	VALUES	(10012, 190, 'Євгеній', 'Ткач', '2003/08/12');
GO

INSERT INTO SubjectSuccess
	VALUES	(10012, 1010, '3'),
			(10012, 1009, '4'),
			(10012, 1008, '5'),
			(10012, 1007, '2');
GO


/* ================================= */
/* =============== 10 ============== */

UPDATE SubjectSuccess
	SET Rating = 'перездача'
	WHERE	(
				SELECT COUNT(SS.Rating)
				FROM SubjectSuccess SS
				WHERE SubjectSuccess.StudID = SS.StudID AND
				SubjectSuccess.PredmetID = SS.PredmetID AND SS.Rating = '2'
			) BETWEEN 1 AND 2
GO