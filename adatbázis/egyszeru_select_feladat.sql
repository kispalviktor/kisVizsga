-- ============================================
-- AUTÓK ADATBÁZIS – SELECT MEGOLDÁSOK
-- ============================================

-- a) feladat
-- SUV kategóriájú autók (minden oszlop)

SELECT *
FROM autok
WHERE kategoria = 'SUV';

-- ============================================

-- b) feladat
-- Hibrid autók, márka szerint ABC sorrendben

SELECT *
FROM autok
WHERE uzemanyag = 'hibrid'
ORDER BY marka ASC;

-- ============================================

-- c) feladat
-- 3 legdrágább autó

SELECT *
FROM autok
ORDER BY ar DESC
LIMIT 3;

-- ============================================

-- d) feladat
-- 2021 és 2023 között gyártott autók

SELECT *
FROM autok
WHERE gyartasi_ev BETWEEN 2021 AND 2023
ORDER BY gyartasi_ev ASC;

-- ============================================

-- e) feladat
-- Modellben "C" betűt tartalmazó autók

SELECT *
FROM autok
WHERE modell LIKE '%C%';

-- ============================================

-- f) feladat
-- Benzin autók legalább 9.0 értékeléssel

SELECT *
FROM autok
WHERE uzemanyag = 'benzin'
  AND ertekeles >= 9.0
ORDER BY ertekeles DESC;

-- ============================================

-- g) feladat
-- Elektromos vagy hibrid autók

SELECT *
FROM autok
WHERE uzemanyag IN ('elektromos', 'hibrid');

-- ============================================

-- h) feladat
-- 10–25 millió Ft közötti ár + min. 150 lóerő

SELECT *
FROM autok
WHERE ar BETWEEN 10 AND 25
  AND loero >= 150
ORDER BY ar ASC;

-- ============================================

-- i) feladat
-- Sedan autók, márkában "e" betű

SELECT *
FROM autok
WHERE kategoria = 'sedan'
  AND marka LIKE '%e%'
ORDER BY marka ASC;

-- ============================================

-- j) feladat
-- TOP 5: fogyasztás < 6 VAGY értékelés ≥ 9

SELECT *
FROM autok
WHERE fogyasztas < 6.0
   OR ertekeles >= 9.0
ORDER BY ertekeles DESC
LIMIT 5;