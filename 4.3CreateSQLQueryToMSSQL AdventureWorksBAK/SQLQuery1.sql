use AdventureWorks2019

--1) Retrieve all information from the Sales.Customer table
select * from Sales.Customer

--2) Retrieve all information from the Sales.Store table sorted by Name in alphabetical order
select * from Sales.Store as s order by s.Name asc

--3) Retrieve all information from the HumanResources.Employee table about ten employees who were born after 1989-09-28
select top 10* from HumanResources.Employee as h where h.BirthDate > '1989-09-28' 

--4) Retrieve employees from the HumanResources.Employee table whose last character of LoginID is 0. 
--   Output only NationalIDNumber, LoginID, JobTitle. Data must be sorted by JobTitle by kill
select h.NationalIDNumber, h.LoginID, h.JobTitle from HumanResources.Employee as h where h.LoginID like '%0' order by h.JobTitle

--5) Retrieve from the Person.Person table all information about records that have been updated in 2008 (ModifiedDate) 
--   and MiddleName contains value and Title does not contain a value
select * from Person.Person as p where p.ModifiedDate like '%2008%' and p.MiddleName is not null and p.Title is null


--6) Display department name (HumanResources.Department.Name) WITHOUT repetition in which there are employees. 
--   Use HumanResources.EmployeeDepartmentHistory and HumanResources.Department tables 
select distinct [Name] as DepartmentWhereThereIsAtLeastOneWorker from HumanResources.Department as hd inner join HumanResources.EmployeeDepartmentHistory as he 
on hd.DepartmentID = he.DepartmentID


--7) Group data from Sales.SalesPerson table by TerritoryID and print the amount of CommissionPct if it is greater than 0
select TerritoryID, COUNT(CommissionPct) as AmountOfCommissionPct from Sales.SalesPerson as s where s.CommissionPct > 0 group by s.TerritoryID

--8) Display all employee information (HumanResources.Employee) which have the largest number vacations (HumanResources.Employee.VacationHours)
select * from HumanResources.Employee as h where h.VacationHours = (select MAX(VacationHours) from HumanResources.Employee)

--9) Display all employee information (HumanResources.Employee) which have a position (HumanResources.Employee.JobTitle) 'Sales Representative' 
--   or 'Network Administrator' or 'Network Manager'
select * from HumanResources.Employee as h where h.JobTitle = 'Sales Representative' or h.JobTitle = 'Network Administrator' or h.JobTitle = 'Network Manager'

--10) Display all employee information (HumanResources.Employee) and their orders (Purchasing.PurchaseOrderHeader). 
--    IF THE EMPLOYEE DOES NOT HAVE ORDERS SHOULD BE DISPLAYED TOO!!!
select *  from HumanResources.Employee as hre full join Purchasing.PurchaseOrderHeader as ppoh 
on hre.BusinessEntityID = ppoh.EmployeeID
select * from Purchasing.PurchaseOrderHeader
