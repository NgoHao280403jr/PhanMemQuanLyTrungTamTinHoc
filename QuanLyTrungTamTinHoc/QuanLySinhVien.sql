USE DB_QuanLyTrungTamTinHoc
GO
ALTER PROC DANHSACHSINHVIEN @name VARCHAR(100), @khoahoc VARCHAR(100)
AS
BEGIN
	IF @khoahoc != ''
	SELECT DISTINCT student_name AS [Họ tên], date_of_birth AS [Birthday], email AS [Email], phone AS [Sđt], address AS [Địa Chỉ] FROM Students, Enrollments, Courses WHERE student_name LIKE '%'+@name+'%' AND ( Courses.course_name LIKE '%'+@khoahoc+'%' AND Courses.course_id = Enrollments.course_id AND Enrollments.student_id = Students.student_id)
	ELSE
	SELECT DISTINCT student_name AS [Họ tên], date_of_birth AS [Birthday], email AS [Email], phone AS [Sđt], address AS [Địa Chỉ] FROM Students, Enrollments, Courses WHERE student_name LIKE '%'+@name+'%' 
END
GO
EXEC DANHSACHSINHVIEN @name = '', @khoahoc = ''
GO
SELECT MAX(student_id) AS max_student_id FROM Students;
GO

CREATE TRIGGER check_duplicate_student
ON Students
FOR INSERT
AS
IF EXISTS (SELECT 1 FROM inserted, Students WHERE Students.student_name = inserted.student_name)
	BEGIN
		RAISERROR ('Thông tin sinh viên đã tồn tại trong cơ sở dữ liệu.', 16, 1)
		ROLLBACK TRAN
	END
GO
--SELECT * FROM Students WHERE Students.student_name = 'FAKE_SAU_NGU_2' AND Students.address = 'fakesaungu2@gmail.com'
GO
--CREATE TRIGGER check_duplicate_student
--ON Students
--FOR INSERT
--AS
--IF EXISTS (
--        SELECT 1 FROM Students
--        WHERE EXISTS (
--            SELECT 1 FROM inserted
--            WHERE Students.student_name = inserted.student_name 
--                AND Students.date_of_birth = inserted.date_of_birth 
--                AND Students.email = inserted.email 
--                AND Students.phone = inserted.phone 
--                AND Students.address = inserted.address
--        )
--    )
--	BEGIN
--		RAISERROR ('Thông tin sinh viên đã tồn tại trong cơ sở dữ liệu.', 16, 1)
--		ROLLBACK TRAN
--	END
--GO

INSERT INTO Students (student_id, student_name, date_of_birth, email, phone, address) 
VALUES(9,'FAKE_', '2003-09-15', '', '1234567890', 'addressSauNgu')
GO

CREATE PROC THEMSINHVIEN @NAME VARCHAR(100), @BIRTHDAY DATE, @EMAIL VARCHAR(100), @PHONE VARCHAR(100), @ADDRESS VARCHAR(100)
AS
BEGIN
	INSERT INTO Students (student_id, student_name, date_of_birth, email, phone, address) VALUES ((SELECT MAX(student_id) + 1 AS max_student_id FROM Students),@NAME, @BIRTHDAY, @EMAIL, @PHONE, @ADDRESS) 	
END
GO

CREATE PROC DUOIHOC @NAME VARCHAR(100), @EMAIL VARCHAR(100)
AS
BEGIN
	DELETE FROM Enrollments 
	WHERE student_id = (SELECT Enrollments.student_id FROM Enrollments, Students WHERE Students.student_id = Enrollments.student_id AND Students.student_name = @NAME AND Students.email = @EMAIL)
	DELETE FROM Students
	WHERE student_id = (SELECT student_id FROM Students WHERE Students.student_name = @NAME AND Students.email = @EMAIL)
END
GO
CREATE FUNCTION GET_STUDENT_ID( @EMAIL VARCHAR(100) )
RETURNS INT
AS
BEGIN
	DECLARE @ID INT
	SET @ID = ( SELECT student_id FROM Students WHERE email = @EMAIL )
	RETURN @ID
END
GO
CREATE PROC SUATHONGTINSINHVIEN @emailGetId VARCHAR(100), @name VARCHAR(100),@birthday date, @email VARCHAR(100), @phone VARCHAR(100), @address VARCHAR(100)
AS
	UPDATE Students
	SET student_name = @name, date_of_birth = @birthday, email = @email, phone = @phone, address = @address
	WHERE dbo.GET_STUDENT_ID(@emailGetId) = Students.student_id
GO
DECLARE @getId INT
SET @getId = dbo.GET_STUDENT_ID('sinhvien1@gmail.com')
PRINT @getId
print dbo.GET_STUDENT_ID('sinhvien1@gmail.com')
GO
EXEC SUATHONGTINSINHVIEN @emailGetId = hoangthiquynhhuong@gmail.com, @name = 'My_Crush',@birthday = '9/15/2003 12:00:00 AM', @email ='hoangthiquynhhuong@gmail.com', @phone = '1234567890', @address ='addressSauNgu'
EXEC SUATHONGTINSINHVIEN @emailGetId = 'hoangthiquynhhuong@gmail.com', @name = 'Hoang Thi Quynh Huong',@birthday = '9/15/2003 12:00:00 AM', @email ='hoangthiquynhhuong@gmail.com', @phone = '1234567890', @address ='addressSauNgu'