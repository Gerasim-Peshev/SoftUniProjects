--1
CREATE DATABASE Minions

--2
USE Minions

CREATE TABLE Minions
(
Id INT PRIMARY KEY,
[Name] NVARCHAR(150),
Age INT
);

CREATE TABLE Towns
(
Id INT PRIMARY KEY,
[Name] NVARCHAR(150)
);

--3
ALTER TABLE Minions
ADD [TownId] INT FOREIGN KEY REFERENCES Towns(Id);

--4
INSERT INTO Towns
	(Id, [Name])
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO Minions
	([Id], [Name], Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2);

--5
TRUNCATE TABLE Minions
TRUNCATE TABLE Towns

--6
DROP TABLE Minions
DROP TABLE Towns

--7
CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(38, 2),
[Weight] DECIMAL(38, 2),
Gender CHAR(1) CHECK(Gender = 'm' OR Gender = 'f'),
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX)
);

INSERT INTO People
([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Misho', 44, 1.75, 54.45, 'm', '12-21-2005', 'Napred nazad'),
('Tosho', 44, 1.83, 100.45, 'm', '12-21-1975', 'Napred nazad'),
('Gosho', 44, 1.65, 54.45, 'm', '12-21-2006', 'Napred nazad'),
('Pesho', 44, 1.80, 102.45, 'm', '12-21-2004', 'Napred nazad'),
('Liuso', 44, 2.20, 89.45, 'm', '12-21-1994', 'Napred nazad');

--8
CREATE TABLE Users
(
Id INT IDENTITY PRIMARY KEY,
Username NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT
);

INSERT INTO Users
VALUES
('Mitio', 'Us be', null, '1-15-2023', 0),
('Mario', 'Us', null, '1-2-2023', 1),
('Marto', 'be', null, '2-1-2023', 0),
('Musito', 'Sus', null, '4-4-2023', 0),
('Tolio', 'Voda', null, '1-11-2024', 0);

--9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07D887A7C6;

ALTER TABLE Users
ADD constraint PK_IdUsers PRIMARY KEY(Id, Username);

--10
ALTER TABLE [Users]ADD CONSTRAINT CHK_PassLen CHECK(LEN([Password]) >= 5);

--11
ALTER TABLE Users ADD CONSTRAINT DF_LastLogTime DEFAULT GETDATE() FOR [LastLoginTime];

--13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(150) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
VALUES
('Pesho'),
('Misho'),
('Tosho'),
('Sho'),
('Shop');

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(150) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName)
VALUES
('Horror'),
('Animation'),
('Action'),
('Sopa'),
('Rakia');

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(150) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName)
VALUES
('Takava'),
('Onakava'),
('Treta'),
('Chetvurta'),
('Peta');

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATE,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId, [Length], GenreId, CategoryId)
VALUES
('Zheleznata tenekia', 1, 1, 1, 1),
('Zheleznata lopata', 2, 2, 2, 2),
('Zheleznata kosa', 3, 3, 3, 3),
('Zheleznata sopa', 4, 4, 4, 4),
('Zheleznata Raq', 5, 5, 5, 5);

DROP TABLE Directors;
DROP TABLE Genres;
DROP TABLE Categories;
DROP TABLE Movies;

SELECT * FROM Directors;
SELECT * FROM Genres;
SELECT * FROM Categories;
SELECT * FROM Movies;

--14
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(MAX) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES('Edno',1,1,1,1),('Dve',2,2,2,2),('Tri',3,3,3,3)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(20) NOT NULL,
	Manufacturer NVARCHAR(MAX) NOT NULL,
	Model NVARCHAR(MAX) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(MAX) NOT NULL,
	Available BIT NOT NULL
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES('T 5520 BT', 'Honda', 'Civic', '2003', 2, 3, 'Sehr gut', 0),('CB 4790 MB', 'Honda', 'Civic', '2007', 1, 5, 'Sehr gut', 0), ('BT 7421 PA', 'Honda', 'Acord', '2004', 3, 5, 'Sehr gut', 0)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	Title NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES('1','1','1'), ('2','2','2'), ('3','3','3')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(MAX) NOT NULL,
	FullName NVARCHAR(MAX) NOT NULL,
	[Address] NVARCHAR(MAX) NOT NULL,
	City NVARCHAR(MAX) NOT NULL,
	ZIPCode NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES('1','1','1','1','1'),('2','2','2','2','2'),('3','3','3','3','3')

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays DATE NOT NULL,
	RetaApplied INT,
	TaxRate INT NOT NULL,
	OrderStatus NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, TaxRate, OrderStatus)
VALUES(1,1,1,1,1,1,1,'1111','1111','1111',1,'1'), (2,2,2,2,2,2,2,'2222','2222','2222',2,'2'), (3,3,3,3,3,3,3,'3333','3333','3333',3,'3')

SELECT * FROM Categories
SELECT * FROM Cars
SELECT * FROM Employees
SELECT * FROM Customers
SELECT * FROM RentalOrders

--15
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	Title NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES('1','1','1'),('2','2','2'),('3','3','3')

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	PhoneNumber NVARCHAR(MAX) NOT NULL,
	EmergencyName NVARCHAR(MAX) NOT NULL,
	EmergencyNumber NVARCHAR(MAX) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES('1','1','1','1','1'),('2','2','2','2','2'),('3','3','3','3','3')

CREATE TABLE RoomStatus(
	RoomStatus INT PRIMARY KEY IDENTITY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(Notes)
VALUES('1'),('2'),('3')

CREATE TABLE RoomTypes(
	RoomType INT PRIMARY KEY IDENTITY,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(Notes)
VALUES('1'),('2'),('3')

CREATE TABLE BedTypes(
	BedType INT PRIMARY KEY IDENTITY,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(Notes)
VALUES('1'),('2'),('3')

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate NVARCHAR(MAX),
	RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomType, BedType, RoomStatus)
VALUES(1,1,1),(2,2,2),(3,3,3)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays DATE NOT NULL,
	AmountCharged INT NOT NULL,
	TaxRate DECIMAL NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES(1,'1111', 1, '1111', '1111', '1111', 1, 1, 1, 1), (2,'2222', 2, '2222', '2222', '2222', 2, 2, 2, 2), (3,'3333', 3, '3333', '3333', '3333', 3, 3, 3, 3)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied INT,
	PhoneCharge INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, PhoneCharge)
VALUES(1,'1111', 1, 1, 1), (2, '2222', 2, 2, 2), (3, '3333', 3, 3, 3)

SELECT * FROM Employees
SELECT * FROM Customers
SELECT * FROM RoomStatus
SELECT * FROM RoomTypes
SELECT * FROM BedTypes
SELECT * FROM Rooms
SELECT * FROM Payments
SELECT * FROM Occupancies

--16
CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(MAX) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(MAX) NOT NULL,
	MiddleName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	JobTitle NVARCHAR(MAX) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--18
INSERT INTO Towns([Name])
VALUES('Sofia'),('Plovdiv'),('Varna'),('Burgas')

INSERT INTO Departments([Name])
VALUES('Engineering'),('Sales'),('Marketing'),('Software Development'),('Quality Assurance')

INSERT INTO Employees([FirstName], [MiddleName], [LastName], JobTitle, DepartmentId, HireDate, Salary)
VALUES('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2-1-2013', 3500),
	  ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '3-2-2004', 4000),
	  ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '8-28-2016', 525.25),
	  ('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '12-9-2007', 3000),
	  ('Peter', 'Pan', 'Pan', 'Intern', 3, '8-28-2016', 599.88)

--19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20
SELECT * FROM Towns ORDER BY [Name] ASC
SELECT * FROM Departments ORDER BY [Name] ASC
SELECT * FROM Employees ORDER BY [Salary] DESC

--21
SELECT [Name] FROM Towns ORDER BY [Name] ASC
SELECT [Name] FROM Departments ORDER BY [Name] ASC
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY [Salary] DESC

--22
UPDATE Employees
SET
Salary = Salary * 1.1

SELECT Salary FROM Employees

--23
UPDATE Payments
SET
[TaxRate] = [TaxRate] * 0.97

SELECT [TaxRate] FROM Payments

--24
USE Hotel

SELECT * FROM Occupancies