
CREATE SCHEMA `Ecommerce` ;


CREATE TABLE `ProductCategory` 
(
   `Id` int NOT NULL AUTO_INCREMENT,
   `Name` varchar(45) DEFAULT NULL,
   `Description` varchar(100) DEFAULT NULL,
   `IsDeleted` tinyint(1) DEFAULT '0',
   `CreatedBy` varchar(45) DEFAULT NULL,
   `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
   `UpdatedBy` varchar(45) DEFAULT NULL,
   `UpdatedDate` datetime DEFAULT NULL,
   PRIMARY KEY (`Id`)
) ENGINE=InnoDB ;

CREATE TABLE `Ecommerce`.`Product`
(
   `Id` INT NOT NULL AUTO_INCREMENT,
   `Name` VARCHAR(45) NULL,
   `Description` VARCHAR(100) NULL,
   `ProductCategoryId` INT NOT NULL,
   `IsDeleted` TINYINT(0) NULL DEFAULT 0,
   `CreatedBy` VARCHAR(45) NULL,
   `CreatedDate` DATETIME NULL,
   `UpdatedBy` VARCHAR(45) NULL,
   `UpdatedDate` DATETIME NULL,
   PRIMARY KEY (`Id`),
   INDEX `idx_product_productcategoryid` (`ProductCategoryId` ASC) VISIBLE,
   CONSTRAINT `fk_product_productcategoryid`
       FOREIGN KEY (`ProductCategoryId`)
           REFERENCES `Ecommerce`.`ProductCategory` (`Id`)
           ON DELETE RESTRICT
           ON UPDATE RESTRICT
) Engine= InnoDb;

CREATE TABLE `Customer` 
(
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(45) DEFAULT NULL,
    `Description` varchar(100) DEFAULT NULL,
    `IsDeleted` tinyint DEFAULT '0',
    `CreatedBy` varchar(45) DEFAULT NULL,
    `CreatedDate` datetime DEFAULT NULL,
    `UpdatedBy` varchar(45) DEFAULT NULL,
    `UpdatedDate` datetime DEFAULT NULL,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB ;
