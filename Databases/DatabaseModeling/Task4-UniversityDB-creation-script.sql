-- MySQL Script generated by MySQL Workbench
-- 08/22/14 13:01:15
-- Model: New Model    Version: 1.0
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema universitydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `universitydb` DEFAULT CHARACTER SET utf8 ;
USE `universitydb` ;

-- -----------------------------------------------------
-- Table `universitydb`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Professors` (
  `Name` VARCHAR(45) NOT NULL,
  `CourseID` INT NOT NULL,
  `ProfessorID` INT NOT NULL,
  PRIMARY KEY (`ProfessorID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Faculties` (
  `FacultyID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`FacultyID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Departments` (
  `Name` VARCHAR(45) NOT NULL,
  `ProfessorID` INT NOT NULL,
  `FacultyID` INT NOT NULL,
  `DepartmentID` INT NOT NULL,
  PRIMARY KEY (`DepartmentID`),
  INDEX `fk_Departments_Professors1_idx` (`ProfessorID` ASC),
  INDEX `fk_Departments_Faculties1_idx` (`FacultyID` ASC),
  CONSTRAINT `fk_Departments_Professors1`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `universitydb`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Departments_Faculties1`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `universitydb`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Titles` (
  `TitleID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`TitleID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Professors_Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Professors_Titles` (
  `ProfessorID` INT NOT NULL,
  `TitleID` INT NOT NULL,
  INDEX `fk_Professors_Titles_Titles1_idx` (`TitleID` ASC),
  INDEX `fk_Professors_Titles_Professors1_idx` (`ProfessorID` ASC),
  CONSTRAINT `fk_Professors_Titles_Titles1`
    FOREIGN KEY (`TitleID`)
    REFERENCES `universitydb`.`Titles` (`TitleID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Professors_Titles_Professors1`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `universitydb`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Students` (
  `StudentID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`StudentID`),
  INDEX `fk_Students_Faculties1_idx` (`FacultyID` ASC),
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `universitydb`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Courses` (
  `CourseID` INT NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `ProfessorID` INT NOT NULL,
  PRIMARY KEY (`CourseID`),
  INDEX `fk_Courses_Professors1_idx` (`ProfessorID` ASC),
  CONSTRAINT `fk_Courses_Professors1`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `universitydb`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `universitydb`.`Courses_Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `universitydb`.`Courses_Students` (
  `CourseID` INT NOT NULL,
  `StudentID` INT NOT NULL,
  INDEX `fk_Courses_Students_Courses1_idx` (`CourseID` ASC),
  INDEX `fk_Courses_Students_Students1_idx` (`StudentID` ASC),
  CONSTRAINT `fk_Courses_Students_Courses1`
    FOREIGN KEY (`CourseID`)
    REFERENCES `universitydb`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Courses_Students_Students1`
    FOREIGN KEY (`StudentID`)
    REFERENCES `universitydb`.`Students` (`StudentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;