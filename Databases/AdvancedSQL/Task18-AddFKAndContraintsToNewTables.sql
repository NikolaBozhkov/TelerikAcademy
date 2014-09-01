USE TelerikAcademy

ALTER TABLE Users
ADD GroupID int,
  CONSTRAINT FK_Users_Groups
    FOREIGN KEY (GroupID)
    REFERENCES Groups(GroupID)