-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema world
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema world
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `world` DEFAULT CHARACTER SET utf8 ;
USE `world` ;

-- -----------------------------------------------------
-- Table `world`.`country`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `world`.`country` (
  `Code` CHAR(3) NOT NULL DEFAULT '',
  `Name` CHAR(52) NOT NULL DEFAULT '',
  `Continent` ENUM('Asia', 'Europe', 'North America', 'Africa', 'Oceania', 'Antarctica', 'South America') NOT NULL DEFAULT 'Asia',
  `Region` CHAR(26) NOT NULL DEFAULT '',
  `SurfaceArea` FLOAT(10,2) NOT NULL DEFAULT '0.00',
  `IndepYear` SMALLINT(6) NULL DEFAULT NULL,
  `Population` INT(11) NOT NULL DEFAULT '0',
  `LifeExpectancy` FLOAT(3,1) NULL DEFAULT NULL,
  `GNP` FLOAT(10,2) NULL DEFAULT NULL,
  `GNPOld` FLOAT(10,2) NULL DEFAULT NULL,
  `LocalName` CHAR(45) NOT NULL DEFAULT '',
  `GovernmentForm` CHAR(45) NOT NULL DEFAULT '',
  `HeadOfState` CHAR(60) NULL DEFAULT NULL,
  `Capital` INT(11) NULL DEFAULT NULL,
  `Code2` CHAR(2) NOT NULL DEFAULT '',
  PRIMARY KEY (`Code`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `world`.`city`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `world`.`city` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` CHAR(35) NOT NULL DEFAULT '',
  `CountryCode` CHAR(3) NOT NULL DEFAULT '',
  `District` CHAR(20) NOT NULL DEFAULT '',
  `Population` INT(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  INDEX `CountryCode` (`CountryCode` ASC),
  CONSTRAINT `city_ibfk_1`
    FOREIGN KEY (`CountryCode`)
    REFERENCES `world`.`country` (`Code`))
ENGINE = InnoDB
AUTO_INCREMENT = 4080
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `world`.`countrylanguage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `world`.`countrylanguage` (
  `CountryCode` CHAR(3) NOT NULL DEFAULT '',
  `Language` CHAR(30) NOT NULL DEFAULT '',
  `IsOfficial` ENUM('T', 'F') NOT NULL DEFAULT 'F',
  `Percentage` FLOAT(4,1) NOT NULL DEFAULT '0.0',
  PRIMARY KEY (`CountryCode`, `Language`),
  INDEX `CountryCode` (`CountryCode` ASC),
  CONSTRAINT `countryLanguage_ibfk_1`
    FOREIGN KEY (`CountryCode`)
    REFERENCES `world`.`country` (`Code`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
