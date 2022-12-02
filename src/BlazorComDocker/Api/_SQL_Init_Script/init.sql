
DROP DATABASE IF EXISTS PlanetsDB;

CREATE DATABASE PlanetsDB;

USE PlanetsDB;

CREATE TABLE Planets (
  Id smallint unsigned NOT NULL AUTO_INCREMENT,
  Name varchar(100) NOT NULL,
  Position smallint NOT NULL,
  constraint pk_planets  PRIMARY KEY(Id)) ENGINE=InnoDB CHARSET=utf8;

INSERT INTO Planets(Name,Position) VALUES('Mercúrio',1);
INSERT INTO Planets(Name,Position) VALUES('Vênus',2);
INSERT INTO Planets(Name,Position) VALUES('Terra',3);
 