-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema diagrammaker
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema diagrammaker
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `diagrammaker` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `diagrammaker` ;

-- -----------------------------------------------------
-- Table `diagrammaker`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `diagrammaker`.`user` (
  `user_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `account` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`user_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `diagrammaker`.`class_canva`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `diagrammaker`.`class_canva` (
  `class_canva_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`class_canva_id`),
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_class_canva_user_id`
    FOREIGN KEY (`user_id`)
    REFERENCES `diagrammaker`.`user` (`user_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `diagrammaker`.`class`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `diagrammaker`.`class` (
  `class_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `class_canva_id` INT NOT NULL,
  PRIMARY KEY (`class_id`),
  INDEX `class_canva_id_idx` (`class_canva_id` ASC) VISIBLE,
  CONSTRAINT `fk_class_class_canva_id`
    FOREIGN KEY (`class_canva_id`)
    REFERENCES `diagrammaker`.`class_canva` (`class_canva_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `diagrammaker`.`class_attribute`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `diagrammaker`.`class_attribute` (
  `class_attribute_id` INT NOT NULL AUTO_INCREMENT,
  `modifiers` VARCHAR(45) NULL DEFAULT NULL,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `data_type` VARCHAR(45) NULL DEFAULT NULL,
  `class_id` INT NOT NULL,
  PRIMARY KEY (`class_attribute_id`),
  INDEX `fk_class_id_idx` (`class_id` ASC) VISIBLE,
  CONSTRAINT `fk_attribute_class_id`
    FOREIGN KEY (`class_id`)
    REFERENCES `diagrammaker`.`class` (`class_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `diagrammaker`.`class_method`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `diagrammaker`.`class_method` (
  `class_method_id` INT NOT NULL AUTO_INCREMENT,
  `modifiers` INT NULL DEFAULT NULL,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  `parameter` VARCHAR(45) NULL DEFAULT NULL,
  `return_type` VARCHAR(45) NULL DEFAULT NULL,
  `class_id` INT NOT NULL,
  PRIMARY KEY (`class_method_id`),
  INDEX `fk_class_id_idx` (`class_id` ASC) VISIBLE,
  CONSTRAINT `fk_method_class_id`
    FOREIGN KEY (`class_id`)
    REFERENCES `diagrammaker`.`class` (`class_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `diagrammaker`.`relationship`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `diagrammaker`.`relationship` (
  `classA_id` INT NOT NULL,
  `classB_id` INT NOT NULL,
  `relationship_type` INT NOT NULL,
  PRIMARY KEY (`classA_id`, `classB_id`),
  INDEX `fk_relationship_classB_id_idx` (`classB_id` ASC) VISIBLE,
  CONSTRAINT `fk_relationship_classA_id`
    FOREIGN KEY (`classA_id`)
    REFERENCES `diagrammaker`.`class` (`class_id`),
  CONSTRAINT `fk_relationship_classB_id`
    FOREIGN KEY (`classB_id`)
    REFERENCES `diagrammaker`.`class` (`class_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
