Create database DB_QuanLyTrungTamTinHoc
use DB_QuanLyTrungTamTinHoc
go
-- Tạo bảng "Nhóm quyền" (Roles)
CREATE TABLE Roles (
    role_id INT PRIMARY KEY,
    role_name VARCHAR(50)
);
-- Tạo bảng "Người dùng" (Users)
CREATE TABLE Users (
    user_id INT PRIMARY KEY,
    username VARCHAR(50),
    password VARCHAR(50),
    full_name VARCHAR(100),
    email VARCHAR(100),
    phone VARCHAR(20),
    address VARCHAR(200),
    role_id INT,
    FOREIGN KEY (role_id) REFERENCES Roles(role_id)
);

CREATE TABLE Permissions (
    permission_id INT PRIMARY KEY,
    permission_name VARCHAR(50),
    role_id INT,
    FOREIGN KEY (role_id) REFERENCES Roles(role_id)
);
-- Other
-- Tạo bảng "Giảng viên" (Instructors)
CREATE TABLE Instructors (
    instructor_id INT PRIMARY KEY,
    instructor_name VARCHAR(100),
    specialization VARCHAR(100),
    email VARCHAR(100),
    phone VARCHAR(20)
);
-- Tạo bảng "Học viên" (Students)
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(100),
    date_of_birth DATE,
    email VARCHAR(100),
    phone VARCHAR(20),
    address VARCHAR(200)
);
-- Tạo bảng "Khóa học" (Courses)
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(100),
    description VARCHAR(200),
    start_date DATE,
    end_date DATE,
    instructor_id INT,
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id)
);
-- Tạo bảng "Học phí" (Fees)
CREATE TABLE Fees (
    fee_id INT PRIMARY KEY,
    course_id INT,
    fee_amount DECIMAL(10, 2),
    currency VARCHAR(10),
    fee_date DATE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);
-- Tạo bảng "Ghi danh" (Enrollments)
CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY,
    course_id INT,
    student_id INT,
    enrollment_date DATE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id),
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);

ALTER TABLE Users
ADD CONSTRAINT unique_email UNIQUE (email);
ALTER TABLE Users
ADD CONSTRAINT check_password_length CHECK (LEN(password) >= 8);
ALTER TABLE Permissions
ADD CONSTRAINT unique_permission_within_role UNIQUE (permission_name, role_id);
ALTER TABLE Courses
ADD CONSTRAINT check_date_order CHECK (start_date < end_date);
ALTER TABLE Instructors
ADD CONSTRAINT unique_instructor_email UNIQUE (email);
ALTER TABLE Students
ADD CONSTRAINT unique_student_email UNIQUE (email);
ALTER TABLE Enrollments
ADD CONSTRAINT unique_enrollment UNIQUE (course_id, student_id);
ALTER TABLE Fees
ADD CONSTRAINT check_positive_fee CHECK (fee_amount >= 0);
