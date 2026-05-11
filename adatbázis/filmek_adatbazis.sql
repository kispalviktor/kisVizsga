CREATE DATABASE filmadatbazis;
CHARACTER SET utf8mb4;
COLLATE utf8mb4_hungarian_ci;
USE filmadatbazis;
CREATE TABLE filmek(
    azonosito INT AUTO_INCREMENT PRIMARY KEY,
    cim VARCHAR(150) NOT NULL UNIQUE,
    rendezo VARCHAR(100),
    megjelenesi_ev YEAR,
    hossz TIME CHECK(hossz BETWEEN 30 AND 300),
    korhatar TINYINT NOT NULL,
    ertekeles FLOAT DEFAULT 5.0,
);

CREATE TABLE szineszek(
    azonosito INT AUTO_INCREMENT NOT NULL,
    nev VARCHAR(100) NOT NULL,
    szuletesi_ido DATE,
    nemzetiseg VARCHAR(50) DEFAULT 'magyar',
    aktiv BOOLEAN DEFAULT TRUE,
    regisztracio_idopontja DEFAULT TIMESTAMP CURRENT_TIMESTAMP
);

SHOW TABLE filmek;
SHOW TABLE szineszek;