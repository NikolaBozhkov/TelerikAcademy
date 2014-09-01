USE TelerikAcademy

CREATE TABLE Users (
  UserID int IDENTITY,
  Username varchar(50) NOT NULL UNIQUE,
  Password varchar(50) NOT NULL CHECK(LEN(Password) >= 5),
  FullName varchar(50) NOT NULL,
  LastLoginTime datetime,
  CONSTRAINT PK_USERS PRIMARY KEY(UserID)
)