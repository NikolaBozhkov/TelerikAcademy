USE TelerikAcademy

CREATE TABLE #TemporaryTable(
EmployeeID int NOT NULL,
ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
SELECT EmployeeID, ProjectID
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
EmployeeID int NOT NULL,
ProjectID int NOT NULL,
CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable
