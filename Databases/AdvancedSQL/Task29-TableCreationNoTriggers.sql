USE TelerikAcademy
 
CREATE TABLE WorkHours (
  WorkHoursID INT IDENTITY(1,1) PRIMARY KEY,
  EmployeeID INT FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) NOT NULL,
  [DATE] datetime NOT NULL,
  Task text NULL,
  [Hours] INT NULL,
  Comment nvarchar(250) NULL,
)
 
INSERT INTO WorkHours
        VALUES(5, '2013-07-12', 'some task', NULL, NULL)
 
CREATE TABLE WorkHoursLog (
  LogID INT IDENTITY(1,1) PRIMARY KEY,
  Command nvarchar(20) NULL,
  WorkHoursID INT NULL,
  OldEmployeeID INT FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID) NULL,
  [OldDate] datetime NULL,
  OldTask text NULL,
  [OldHours] INT NULL,
  OldComment nvarchar(250) NULL,
  NewEmployeeID INT FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
  [NewDate] datetime NULL,
  NewTask text NULL,
  [NewHours] INT NULL,
  NewComment nvarchar(250) NULL
)