USE DB_QuanLyTrungTamTinHoc
GO
CREATE FUNCTION GETCHUYENMON()
RETURNS TABLE
AS
	RETURN SELECT DISTINCT description AS [Chuyên Môn] FROM Courses
GO
SELECT * FROM DBO.GETCHUYENMON()
GO
CREATE FUNCTION GETKHOAHOC( @chuyenmon VARCHAR(200), @giangvien VARCHAR(100), @khoahoc VARCHAR(100), @ngaybatdau date, @sortstart NVARCHAR(10), @ngayketthuc date, @sortend NVARCHAR(10) )
RETURNS TABLE
AS
	RETURN SELECT course_name AS [Tên khoá học], description AS [Chuyên môn], start_date AS [Ngày bắt đầu], end_date AS [Ngày kết thúc], instructor_name AS [Giảng viên] FROM Courses, Instructors WHERE Courses.instructor_id = Instructors.instructor_id AND description LIKE '%'+@chuyenmon+'%' AND instructor_name LIKE '%'+@giangvien+'%' AND course_name LIKE '%'+@khoahoc+'%' AND (( @sortstart = N'Sau' AND start_date >= @ngaybatdau AND end_date >= @ngayketthuc AND @sortend = N'Sau' ) OR ( @sortstart = N'Trước' AND start_date <= @ngaybatdau AND end_date <= @ngayketthuc AND @sortend = N'Trước' ) OR ( @sortstart = N'Sau' AND start_date >= @ngaybatdau AND end_date <= @ngayketthuc AND @sortend = N'Trước' ) OR ( @sortstart = N'Trước' AND start_date <= @ngaybatdau AND end_date >= @ngayketthuc AND @sortend = N'Sau' ))
GO
SELECT DISTINCT instructor_name AS [Tên giảng viên], specialization AS [Skill] ,email AS [Email liên hệ] FROM Courses,Instructors WHERE Courses.instructor_id = Instructors.instructor_id
GO

CREATE PROC AddCourse @name VARCHAR(100), @chuyenmon VARCHAR(200), @start date, @end date, @giangvien INT
AS
	INSERT INTO Courses (course_id ,course_name, description, start_date, end_date, instructor_id) VALUES ( (SELECT MAX(course_id)+1 AS [max_course_id] FROM Courses), @name, @chuyenmon, @start, @end, @giangvien )
GO
CREATE PROC DeleteCourse @id INT
AS
BEGIN
	DELETE FROM Enrollments
	WHERE course_id = @id
	DELETE FROM Courses
	WHERE course_id = @id
END
GO
CREATE PROC EditCourse @id INT, @name VARCHAR(100), @chuyenmon VARCHAR(200), @start date, @end date, @giangvien INT
AS
	UPDATE Courses
	SET course_name = @name, description = @chuyenmon, start_date = @start, end_date = @end , instructor_id = @giangvien
	WHERE @id = course_id
GO
CREATE TRIGGER CheckCourseValidity
ON Courses
FOR INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Courses c
        INNER JOIN inserted i ON c.course_name = i.course_name
        WHERE c.course_id <> i.course_id -- Loại trừ khóa học cần được thêm vào
    )
    BEGIN
        RAISERROR('Khóa học đã tồn tại.', 16, 1)
        ROLLBACK TRANSACTION
    END
END
SELECT course_id FROM Courses WHERE course_name = 'Tin Hoc PowerPoint 1' AND description = 'PowerPoint' AND start_date = '2023-12-19' AND end_date = '2023-12-20' AND instructor_id = 2
go
EXEC DeleteCourse @id = 5
go
SELECT course_id AS [Id] FROM Courses,Instructors WHERE course_name = 'Tin Hoc PowerPoint 1' AND description = 'PowerPoint' AND start_date = '2023-12-19' AND end_date = '2023-12-20' AND Courses.instructor_id = Instructors.instructor_id AND instructor_name = 'GiangVien2'
SELECT DISTINCT description FROM Courses
SELECT DISTINCT * FROM Instructors WHERE specialization LIKE '%Word%'
SELECT * FROM dbo.GETKHOAHOC('', '', '', '1900-01-01', N'Sau', '2100-12-31', N'Trước')
EXEC DANHSACHSINHVIEN @name = '', @khoahoc = ''