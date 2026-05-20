-- MySQL Adatbázis Feladatsor: Iskola
-- Cél: Alapvető adatbázis és táblák létrehozása különböző adattípusokkal

-- ============================================
-- 1. FELADAT: Adatbázis létrehozása
-- ============================================

-- Hozd létre az 'iskola' nevű adatbázist
CREATE DATABASE iskola;

-- Válaszd ki az iskola adatbázist munkához
USE iskola;

-- ============================================
-- 2. FELADAT: Diák (student) tábla létrehozása
-- ============================================

CREATE TABLE student (
    -- Azonosító szám (egész szám, automatikus növekedés)
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    
    -- Teljes név (változó hosszúságú szöveg, max 100 karakter, kötelező)
    full_name VARCHAR(100) NOT NULL,
    
    -- Becenév (változó hosszúságú szöveg, max 50 karakter, opcionális)
    nickname VARCHAR(50),
    
    -- Születési dátum (dátum típus, kötelező)
    birth_date DATE NOT NULL,
    
    -- Regisztráció időpontja (dátum és idő, automatikus beállítás)
    registration_datetime DATETIME DEFAULT CURRENT_TIMESTAMP,
    
    -- Aktív státusz (logikai érték, alapértelmezett: igaz)
    is_active BOOLEAN DEFAULT TRUE,
    
    -- Magasság centiméterben (kicsi egész szám, 0-300 között)
    height_cm TINYINT UNSIGNED CHECK (height_cm BETWEEN 0 AND 300),
    
    -- Testsúly kilogrammban (lebegőpontos szám, 2 tizedesjegy pontossággal)
    weight_kg DECIMAL(5,2),
    
    -- Átlag (lebegőpontos szám, egyszerű pontosság)
    grade_average FLOAT,
    
    -- Ösztöndíj összege (lebegőpontos szám, dupla pontosság)
    scholarship_amount DOUBLE,
    
    -- Nem (enum típus: férfi, nő, egyéb)
    gender ENUM('male', 'female', 'other') NOT NULL,
    
    -- Évfolyam (kicsi egész szám, 1-12 között)
    grade_level TINYINT CHECK (grade_level BETWEEN 1 AND 12),
    
    -- Megjegyzések (hosszú szöveg)
    notes TEXT,
    
    -- Utolsó bejelentkezés időpontja (időbélyeg)
    last_login TIMESTAMP NULL
);