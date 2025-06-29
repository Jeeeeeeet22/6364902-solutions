-- ============================================
-- Create Database (optional)
-- ============================================
CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO

-- ============================================
-- Create Departments Table
-- ============================================
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- ============================================
-- Create Employees Table
-- ============================================
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

-- ============================================
-- Insert Departments Sample Data
-- ============================================
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');
GO

-- ============================================
-- Insert Expanded Employees Sample Data
-- ============================================
INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05'),
('Robert', 'Brown', 1, 5200.00, '2022-02-10'),
('Linda', 'White', 2, 6300.00, '2020-06-18'),
('William', 'Black', 3, 7200.00, '2017-12-05'),
('Elizabeth', 'Green', 4, 5800.00, '2021-08-21'),
('David', 'King', 3, 7500.00, '2022-04-12'),
('Sarah', 'Taylor', 1, 5100.00, '2023-01-25');
GO

-- ============================================
-- ============================================
-- ✅ Exercise 1: Stored Procedure to Retrieve Employee Details by Department
-- ============================================
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- ============================================
-- ✅ Exercise 5: Stored Procedure to Return Total Number of Employees in a Department
-- ============================================
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- ============================================
-- ✅ Test Stored Procedure for Exercise 1
-- Example: Get all employees in IT department (DepartmentID = 3)
-- ============================================
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
GO

-- ============================================
-- ✅ Test Stored Procedure for Exercise 5
-- Example: Get total number of employees in HR department (DepartmentID = 1)
-- ============================================
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 1;
GO
