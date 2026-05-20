-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema nagyker
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema nagyker
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `nagyker` DEFAULT CHARACTER SET utf8mb4 ;
USE `nagyker` ;

-- -----------------------------------------------------
-- Table `nagyker`.`vevok`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `nagyker`.`vevok` (
  `vid` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'A tábla azonosítója',
  `vevo_neve` VARCHAR(255) NOT NULL COMMENT 'A vevő neve',
  `vevo_cime` VARCHAR(255) NOT NULL COMMENT 'A vevő címe',
  `email` VARCHAR(255) NULL COMMENT 'A vevő emailcíme',
  PRIMARY KEY (`vid`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `nagyker`.`termek`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `nagyker`.`termek` (
  `tid` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'A termék tábla azonosítója',
  `megnevezes` VARCHAR(255) NOT NULL COMMENT 'A termék megnevezése',
  `termek_ara` INT UNSIGNED NOT NULL DEFAULT 0 COMMENT 'A termék egységára',
  `elerheto_db` INT NOT NULL DEFAULT 0 COMMENT 'A termékből elérhető darabszám',
  PRIMARY KEY (`tid`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `nagyker`.`rendelesek`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `nagyker`.`rendelesek` (
  `rid` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'A rendelések tábla azonosítója',
  `datum` DATE NOT NULL COMMENT 'A rendelés dátuma',
  `vegosszeg` INT NOT NULL DEFAULT 0 COMMENT 'A rendelés végösszege',
  `vevok_vid` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`rid`),
  INDEX `fk_rendelesek_vevok1_idx` (`vevok_vid` ASC) VISIBLE,
  CONSTRAINT `fk_rendelesek_vevok1`
    FOREIGN KEY (`vevok_vid`)
    REFERENCES `nagyker`.`vevok` (`vid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `nagyker`.`megjegyzesek`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `nagyker`.`megjegyzesek` (
  `mid` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'A megjegyzések tábla azonosítója',
  `megjegyzes` TEXT NOT NULL COMMENT 'A megjegyzés szövege',
  `rendelesek_rid` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`mid`, `rendelesek_rid`),
  INDEX `fk_megjegyzesek_rendelesek1_idx` (`rendelesek_rid` ASC) VISIBLE,
  CONSTRAINT `fk_megjegyzesek_rendelesek1`
    FOREIGN KEY (`rendelesek_rid`)
    REFERENCES `nagyker`.`rendelesek` (`rid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `nagyker`.`vevo_telefonszamok`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `nagyker`.`vevo_telefonszamok` (
  `vtid` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'A vevő telefonszáma',
  `telefonszam` VARCHAR(45) NOT NULL COMMENT 'A vevő telefonszáma',
  `vevok_vid` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`vtid`, `vevok_vid`),
  INDEX `fk_vevo_telefonszamok_vevok_idx` (`vevok_vid` ASC) VISIBLE,
  CONSTRAINT `fk_vevo_telefonszamok_vevok`
    FOREIGN KEY (`vevok_vid`)
    REFERENCES `nagyker`.`vevok` (`vid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `nagyker`.`rendeles_tetelek`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `nagyker`.`rendeles_tetelek` (
  `termek_tid` INT UNSIGNED NOT NULL,
  `rendelesek_rid` INT UNSIGNED NOT NULL,
  `mennyiseg` INT NOT NULL COMMENT 'A tételből rendelt mennyiség',
  `aktualis_ar` INT NOT NULL COMMENT 'A rendeléskori aktuális ár',
  PRIMARY KEY (`termek_tid`, `rendelesek_rid`),
  INDEX `fk_termek_has_rendelesek_rendelesek1_idx` (`rendelesek_rid` ASC) VISIBLE,
  INDEX `fk_termek_has_rendelesek_termek1_idx` (`termek_tid` ASC) VISIBLE,
  CONSTRAINT `fk_termek_has_rendelesek_termek1`
    FOREIGN KEY (`termek_tid`)
    REFERENCES `nagyker`.`termek` (`tid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_termek_has_rendelesek_rendelesek1`
    FOREIGN KEY (`rendelesek_rid`)
    REFERENCES `nagyker`.`rendelesek` (`rid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Házi feladat megoldáas:
-- -----------------------------------------------------
INSERT INTO vevok (vevo_neve, vevo_cime, email) VALUES
('Kiss Péter', 'Budapest, Fő utca 12.', 'peter.kiss@gmail.com'),
('Nagy Anna', 'Debrecen, Kossuth tér 3.', 'anna.nagy@yahoo.com'),
('Szabó László', 'Szeged, Tisza Lajos krt. 45.', 'laszlo.szabo@outlook.com'),
('Molnár Eszter', 'Pécs, Hunyadi út 7.', 'eszter.molnar@freemail.hu'),
('Tóth Dávid', 'Győr, Baross út 21.', 'david.toth@gmail.com');

INSERT INTO termek (megnevezes, termek_ara, elerheto_db) VALUES
('Laptop Dell Vostro', 320000, 15),
('HP Laserjet Nyomtató', 75000, 30),
('Logitech Egér M185', 6500, 120),
('Samsung Monitor 24"', 52000, 25),
('Kingston SSD 512GB', 23000, 60);

INSERT INTO rendelesek (datum, vegosszeg, vevok_vid) VALUES
('2025-01-10', 640000, 1),
('2025-01-15', 75000, 2),
('2025-01-20', 13000, 3),
('2025-02-02', 104000, 4),
('2025-02-05', 46000, 5);

INSERT INTO megjegyzesek (megjegyzes, rendelesek_rid) VALUES
('Sürgős kiszállítás szükséges.', 1),
('A vevő kérte a számlamásolatot.', 2),
('Telefonos egyeztetés megtörtént.', 3),
('Törékeny áru, óvatos kezelést kérünk.', 4),
('A csomag átvétele munkaidő után.', 5);

INSERT INTO vevo_telefonszamok (telefonszam, vevok_vid) VALUES
('+36-30-111-2233', 1),
('+36-20-555-7788', 2),
('+36-70-999-1122', 3),
('+36-30-445-6677', 4),
('+36-20-334-5566', 5);

INSERT INTO rendeles_tetelek (termek_tid, rendelesek_rid, mennyiseg, aktualis_ar) VALUES
(1, 1, 2, 320000),
(2, 2, 1, 75000),
(3, 3, 2, 6500),
(4, 4, 2, 52000),
(5, 5, 2, 23000);


