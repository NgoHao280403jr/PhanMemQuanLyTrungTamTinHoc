use DB_QuanLyTrungTamTinHoc
GO
CREATE PROC LayDanhSachKhoaHoc
AS
BEGIN
SELECT * FROM Courses
END
GO

CREATE PROC LocDanhSachGiangVien
@name VARCHAR(100), 
@khoahoc VARCHAR(100), 
@datestart DATE, 
@dateend DATE
AS
BEGIN
	SELECT DISTINCT
		instructor_name AS [Họ tên],
		course_name AS [Khoá học],
		N'Giảng viên' AS [Chức vụ],
		start_date AS [Ngày bắt đầu],
		end_date AS [Ngày kết thúc]
	FROM 
		Instructors
		INNER JOIN Courses ON Instructors.instructor_id = Courses.instructor_id
	WHERE 
		course_name LIKE '%' + @khoahoc + '%' 
		AND instructor_name LIKE '%' + @name + '%' 
		AND start_date >= @datestart 
		AND end_date <= @dateend
END
GO

ALTER PROC LocDanhSachSinhVien
@name VARCHAR(100), 
@khoahoc VARCHAR(100), 
@datestart DATE, 
@dateend DATE
AS
BEGIN
	SELECT DISTINCT
		student_name AS [Họ tên],
		course_name AS [Khoá học],
		N'Sinh viên' AS [Chức vụ],
		start_date AS [Ngày bắt đầu],
		end_date AS [Ngày kết thúc]
	FROM 
		Courses
		INNER JOIN Enrollments ON Courses.course_id = Enrollments.course_id
		INNER JOIN Students ON Students.student_id = Enrollments.student_id
	WHERE 
		course_name LIKE '%' + @khoahoc + '%' 
		AND student_name LIKE '%' + @name + '%' 
		AND start_date >= @datestart 
		AND end_date <= @dateend
END
GO
EXEC LocDanhSachGiangVien @name = '', @khoahoc = '', @datestart = '2022-1-1', @dateend = '2024-12-1'
GO
EXEC LocDanhSachSinhVien @name = '', @khoahoc = '', @datestart = '2022-1-1', @dateend = '2024-12-1'
GO
