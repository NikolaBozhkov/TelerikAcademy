USE TelerikAcademy

CREATE TABLE Groups (
  Name nvarchar(50) NOT NULL UNIQUE,
  GroupID int IDENTITY,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)