-- ============================================
-- MUSICSTORE ADATBÁZIS – MEGOLDÁSOK
-- ============================================

-- ============================================
-- TÁBLÁK
-- ============================================

-- genres
-- id      : Műfaj azonosítója
-- name    : Műfaj neve

-- labels
-- id              : Kiadó azonosítója
-- name            : Kiadó neve
-- city            : Székhely városa
-- founded_year    : Alapítás éve
-- website         : Weboldal címe

-- artists
-- id              : Előadó azonosítója
-- first_name      : Keresztnév
-- last_name       : Vezetéknév
-- birth_year      : Születési év
-- death_year      : Halálozási év
-- nationality     : Nemzetiség
-- is_alive        : Él-e még

-- albums
-- id              : Album azonosítója
-- title           : Album címe
-- artist_id       : Előadó azonosítója
-- label_id        : Kiadó azonosítója
-- genre_id        : Műfaj azonosítója
-- release_year    : Kiadás éve
-- tracks          : Számok száma
-- price           : Ár
-- stock           : Raktárkészlet
-- rating          : Értékelés
-- is_platinum     : Platinalemez-e

-- ============================================
-- SAFE UPDATE MODE KIKAPCSOLÁSA
-- ============================================

SET SQL_SAFE_UPDATES = 0;

-- ============================================
-- 1. feladat
-- Új műfajok beszúrása
-- ============================================

INSERT INTO genres (name)
VALUES
('country'),
('latin'),
('gospel');

-- ============================================
-- 2. feladat
-- Új albumok beszúrása
-- ============================================

INSERT INTO albums
(title, artist_id, label_id, genre_id, release_year,
 tracks, price, stock, rating, is_platinum)
VALUES
('Budapesti búcsúkoncert', 1, 4, 1, 1999,
 16, 3290, 45, 4.80, TRUE),

('Curtain Call', 10, 1, 3, 2005,
 17, 3890, 95, 4.76, TRUE);

-- ============================================
-- 3. feladat
-- Platinalemezek listázása
-- ============================================

SELECT title,
       price,
       rating
FROM albums
WHERE is_platinum = TRUE
  AND price > 3000
  AND rating >= 4.80
ORDER BY rating DESC
LIMIT 5;

-- ============================================
-- 4. feladat
-- Műfajonkénti statisztika
-- ============================================

SELECT g.name,
       COUNT(a.id) AS albumok_szama,
       ROUND(AVG(a.rating), 2) AS atlag_ertekeles,
       SUM(a.stock) AS osszes_keszlet
FROM genres g
INNER JOIN albums a ON g.id = a.genre_id
GROUP BY g.id, g.name
HAVING COUNT(a.id) >= 3
ORDER BY albumok_szama DESC;

-- ============================================
-- 5. feladat
-- Albumok részletes listája
-- ============================================

SELECT a.title,
       CONCAT(ar.last_name, ' ', ar.first_name) AS eloado_nev,
       l.name AS kiado,
       g.name AS mufaj,
       a.release_year
FROM albums a
INNER JOIN artists ar ON a.artist_id = ar.id
INNER JOIN labels l ON a.label_id = l.id
INNER JOIN genres g ON a.genre_id = g.id
WHERE a.release_year > 2000
   OR a.rating > 4.90
ORDER BY ar.last_name ASC,
         a.release_year ASC;

-- ============================================
-- 6. feladat
-- Platinalemezek áremelése
-- ============================================

UPDATE albums
SET price = ROUND(price * 1.25, 0)
WHERE rating >= 4.85
  AND is_platinum = TRUE;

-- ============================================
-- 7. feladat
-- Készletfeltöltés
-- ============================================

UPDATE albums
SET stock = stock + 50
WHERE stock < 20
  AND release_year > 1990;

-- ============================================
-- 8. feladat
-- Táblaszerkezet módosítása
-- ============================================

ALTER TABLE albums
ADD COLUMN catalog_number VARCHAR(20)
UNIQUE COMMENT 'Katalógusszám',
MODIFY rating DECIMAL(4,2);

-- ============================================
-- 9. feladat
-- Régi, alacsony készletű albumok törlése
-- ============================================

DELETE FROM albums
WHERE release_year < 1970
  AND stock < 30;

-- ============================================
-- 10. feladat
-- Album nélküli előadók törlése
-- ============================================

DELETE a
FROM artists a
LEFT JOIN albums al ON a.id = al.artist_id
WHERE al.id IS NULL;