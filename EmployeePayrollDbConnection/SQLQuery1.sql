CREATE TABLE Employee_Payroll (EmpId int IDENTITY(1,1) PRIMARY KEY,EmpName VARCHAR(30),EmpPhNo VARCHAR(255),EmpAddress VARCHAR(255) NOT NULL DEFAULT 'chennai',EmpDept VARCHAR(30) NOT NULL DEFAULT 'Engineering'
,StartDate DATE,BasicPay FLOAT,Deductions FLOAT,TaxablePay FLOAT,IncomeTax FLOAT,NetPay FLOAT);

SELECT * FROM Employee_Payroll;

USE EmployeePayrollDatabase;

ALTER TABLE Employee_Payroll ADD Gender VARCHAR(10);

ALTER TABLE Employee_Payroll DROP COLUMN TaxablePay;

INSERT INTO Employee_Payroll VALUES ('Hemanth','8899767865','no-2,ab enclave','Development','01-05-2021',40000,4000,2000,36000,'M'),
('Suraj','8899777865','no-2,ab st','Development','01-08-2021',40000,4000,2000,36000,'M'),
('Harish','8899767111','no-1,ab nagar','Marketing','01-05-2020',35000,4000,1000,30000,'M'),
('Asha','8898767111','no-1,ab flats','Sales','01-01-2020',35000,4000,1000,30000,'F');

-- UC - 2 Using Procedure to Insert Data 
GO
CREATE PROCEDURE dbo.spEmployee_Payroll_AddData
(
@EmpName VARCHAR(30),@EmpPhNo VARCHAR(255),@EmpAddress VARCHAR(255),@EmpDept VARCHAR(30),
@StartDate DATE,@BasicPay FLOAT,@Deductions FLOAT,@IncomeTax FLOAT,@NetPay FLOAT,@Gender VARCHAR(10))
AS
BEGIN
	INSERT INTO Employee_Payroll VALUES (@EmpName,@EmpPhNo,@EmpAddress,@EmpDept,@StartDate,@BasicPay,@Deductions,@IncomeTax,@NetPay,@Gender)
END

-- UC -> 4 Stored Procedure for Update query

GO
CREATE or ALTER PROCEDURE dbo.spEmployee_Payroll_UpdateData
(@EmpName VARCHAR(30),@EmpPhNo VARCHAR(30))
AS
BEGIN
	UPDATE Employee_Payroll SET EmpPhNo = @EmpPhNo WHERE EmpName = @EmpName
END

select * from Employee_Payroll;