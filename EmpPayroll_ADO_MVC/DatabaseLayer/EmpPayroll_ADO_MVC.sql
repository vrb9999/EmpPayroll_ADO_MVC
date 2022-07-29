create database EmpPayroll_ADO_MVC
use EmpPayroll_ADO_MVC
------------------------------------------------Tables------------------------------------------------
Create Table Employee(
EmpId int identity(1,1) primary key,
EmpName varchar(100),
ProfileImage varchar(max),
Gender varchar(7),
Department varchar(50),
Salary int,
StartDate datetime,
Notes varchar(max)
);

select * from Employee
------------------------------------------------StoredProcedures------------------------------------------------
--Add Employee stored procedure
create procedure spAddEmp(
@EmpName varchar(100),
@ProfileImage varchar(max),
@Gender varchar(7),
@Department varchar(50),
@Salary int,
@StartDate datetime,
@Notes varchar(max))
As
Begin try
insert into Employee(EmpName,ProfileImage,Gender,Department,Salary,StartDate,Notes) values(@EmpName,@ProfileImage,@Gender,@Department,@Salary,@StartDate,@Notes)
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spAddEmp 'Vinay','vinay.jpg','Male','CSE','100000','1900-01-01 12:10:05.123','Note'


--GetAllEmployees stored procedure
create procedure spGetAllEmployees
As
Begin try
select * from Employee
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spGetAllEmployees


--UpdateEmployees stored procedure
create procedure spUpdateEmployee(
@EmpId int,
@EmpName varchar(100),
@ProfileImage varchar(max),
@Gender varchar(7),
@Department varchar(50),
@Salary int,
@StartDate datetime,
@Notes varchar(max)
)
As
Begin try
Update Employee set EmpName=@EmpName, ProfileImage=@ProfileImage,Gender=@Gender,Department=@Department,Salary=@Salary,StartDate=@StartDate,Notes=@Notes where EmpId=@EmpId
Select * from Employee where EmpId = @EmpId
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH


--spDeleteEmployee stored procedure
create procedure spDeleteEmployee(@EmpId int)
As
Begin try
DELETE FROM Employee WHERE EmpId=@EmpId;
end try
Begin catch
SELECT 
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH