-- ============================================
-- SPORTOLOK ADATBÁZIS – MEGOLDÁSOK
-- ============================================

-- ============================================
-- TÁBLÁK
-- ============================================

-- sports
-- id          : Sportág azonosítója
-- nev         : Sportág neve
-- kategoria   : Sportág kategóriája

-- countries
-- id          : Ország azonosítója
-- nev         : Ország neve
-- kontinens   : Kontinens neve

-- clubs
-- id              : Klub azonosítója
-- nev             : Klub neve
-- country_id      : Ország azonosítója
-- varos           : Klub városa
-- alapitas_eve    : Alapítás éve

-- athletes
-- id                  : Sportoló azonosítója
-- vezeteknev          : Vezetéknév
-- keresztnev          : Keresztnév
-- szuletesi_ev        : Születési év
-- nem                 : Nem
-- country_id          : Ország azonosítója
-- club_id             : Klub azonosítója
-- sport_id            : Sportág azonosítója
-- magassag_cm         : Magasság cm-ben
-- testsuly_kg         : Testsúly kg-ban
-- aktiv               : Aktív sportoló-e
-- vilagranglista      : Világranglista helyezés
-- havi_ber            : Havi bér

-- ============================================
-- SAFE UPDATE MODE KIKAPCSOLÁSA
-- ============================================

SET SQL_SAFE_UPDATES = 0;

-- ============================================
-- 1. feladat
-- Aktív sportolók teljes neve, születési éve és neme
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       szuletesi_ev,
       nem
FROM athletes
WHERE aktiv = TRUE
ORDER BY vezeteknev ASC;

-- ============================================
-- 2. feladat
-- 2000 után született aktív sportolók
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       szuletesi_ev,
       sport_id
FROM athletes
WHERE szuletesi_ev > 2000
  AND aktiv = TRUE
ORDER BY szuletesi_ev DESC;

-- ============================================
-- 3. feladat
-- Top 10-es aktív sportolók
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       vilagranglista
FROM athletes
WHERE aktiv = TRUE
  AND vilagranglista <= 10
ORDER BY vilagranglista ASC;

-- ============================================
-- 4. feladat
-- 195 cm-nél magasabb vagy 100 kg-nál nehezebb sportolók
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       magassag_cm,
       testsuly_kg
FROM athletes
WHERE magassag_cm > 195
   OR testsuly_kg > 100;

-- ============================================
-- 5. feladat
-- Klub nélküli sportolók
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       sport_id
FROM athletes
WHERE club_id IS NULL;

-- ============================================
-- 6. feladat
-- Top 5 legjobban fizetett sportoló
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       havi_ber
FROM athletes
ORDER BY havi_ber DESC
LIMIT 5;

-- ============================================
-- 7. feladat
-- Aktív sportolók és sportáguk
-- ============================================

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       s.nev AS sportag
FROM athletes a
INNER JOIN sports s ON a.sport_id = s.id
WHERE a.aktiv = TRUE
ORDER BY s.nev ASC, teljes_nev ASC;

-- ============================================
-- 8. feladat
-- Sportolók klubja és városa
-- ============================================

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       c.nev AS klub_nev,
       c.varos AS klub_varos
FROM athletes a
INNER JOIN clubs c ON a.club_id = c.id
ORDER BY c.nev ASC;

-- ============================================
-- 9. feladat
-- Klubok és országuk
-- ============================================

SELECT c.nev,
       c.varos,
       co.nev AS orszag
FROM clubs c
INNER JOIN countries co ON c.country_id = co.id
ORDER BY co.nev ASC, c.nev ASC;

-- ============================================
-- 10. feladat
-- Aktív sportolók sportággal és országgal
-- ============================================

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       s.nev AS sportag,
       co.nev AS orszag
FROM athletes a
INNER JOIN sports s ON a.sport_id = s.id
INNER JOIN countries co ON a.country_id = co.id
WHERE a.aktiv = TRUE
ORDER BY co.nev ASC, teljes_nev ASC;

-- ============================================
-- 11. feladat
-- Európai aktív sportolók
-- ============================================

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       s.nev AS sportag,
       co.nev AS orszag
FROM athletes a
INNER JOIN sports s ON a.sport_id = s.id
INNER JOIN countries co ON a.country_id = co.id
WHERE co.kontinens = 'Európa'
  AND a.aktiv = TRUE
ORDER BY co.nev ASC;

-- ============================================
-- 12. feladat
-- Klubok és sportolóik száma
-- ============================================

SELECT c.nev,
       COUNT(a.id) AS sportolok_szama
FROM clubs c
LEFT JOIN athletes a ON c.id = a.club_id
GROUP BY c.id, c.nev
ORDER BY sportolok_szama DESC;

-- ============================================
-- 13. feladat
-- Országok és sportolóik száma
-- ============================================

SELECT co.nev,
       COUNT(a.id) AS sportolok_szama
FROM countries co
LEFT JOIN athletes a ON co.id = a.country_id
GROUP BY co.id, co.nev
ORDER BY sportolok_szama DESC;

-- ============================================
-- 14. feladat
-- Sportolók és klubjuk
-- ============================================

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       c.nev AS klub_nev
FROM athletes a
LEFT JOIN clubs c ON a.club_id = c.id
ORDER BY teljes_nev ASC;

-- ============================================
-- 15. feladat
-- Aktív sportolók száma sportáganként
-- ============================================

SELECT s.nev,
       COUNT(a.id) AS aktiv_sportolok
FROM sports s
INNER JOIN athletes a ON s.id = a.sport_id
WHERE a.aktiv = TRUE
GROUP BY s.id, s.nev
HAVING COUNT(a.id) >= 1
ORDER BY aktiv_sportolok DESC;

-- ============================================
-- 16. feladat
-- Klubonként átlagbér és sportolók száma
-- ============================================

SELECT c.nev,
       ROUND(AVG(a.havi_ber), 0) AS atlag_ber,
       COUNT(a.id) AS sportolok_szama
FROM clubs c
INNER JOIN athletes a ON c.id = a.club_id
GROUP BY c.id, c.nev
HAVING COUNT(a.id) >= 2
ORDER BY atlag_ber DESC;

-- ============================================
-- 17. feladat
-- Átlagos magasság és testsúly nemenként
-- ============================================

SELECT nem,
       ROUND(AVG(magassag_cm), 1) AS atlag_magassag,
       ROUND(AVG(testsuly_kg), 1) AS atlag_testsuly
FROM athletes
GROUP BY nem;

-- ============================================
-- 18. feladat
-- Sportolók száma kontinensenként
-- ============================================

SELECT co.kontinens,
       COUNT(a.id) AS sportolok_szama
FROM athletes a
INNER JOIN countries co ON a.country_id = co.id
GROUP BY co.kontinens
ORDER BY sportolok_szama DESC;

-- ============================================
-- 19. feladat
-- Legjobb világranglista sportáganként
-- ============================================

SELECT s.nev,
       MIN(a.vilagranglista) AS legjobb_ranglista
FROM sports s
INNER JOIN athletes a ON s.id = a.sport_id
WHERE a.aktiv = TRUE
GROUP BY s.id, s.nev
ORDER BY legjobb_ranglista ASC;

-- ============================================
-- 20. feladat
-- Átlagbér felett kereső sportolók
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       havi_ber
FROM athletes
WHERE havi_ber > (
    SELECT AVG(havi_ber)
    FROM athletes
)
ORDER BY havi_ber DESC;

-- ============================================
-- 21. feladat
-- Legtöbb sportolóval rendelkező ország sportolói
-- ============================================

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       c.nev AS orszag
FROM athletes a
INNER JOIN countries c ON a.country_id = c.id
WHERE a.country_id = (
    SELECT country_id
    FROM athletes
    GROUP BY country_id
    ORDER BY COUNT(*) DESC
    LIMIT 1
);

-- ============================================
-- 22. feladat
-- Átlagmagasság feletti sportolók
-- ============================================

SELECT CONCAT(vezeteknev, ' ', keresztnev) AS teljes_nev,
       magassag_cm
FROM athletes
WHERE magassag_cm > (
    SELECT AVG(magassag_cm)
    FROM athletes
)
ORDER BY magassag_cm DESC;

-- ============================================
-- 23. feladat
-- Legjobb világranglistás aktív sportoló
-- ============================================

SELECT *
FROM athletes
WHERE aktiv = TRUE
  AND vilagranglista = (
      SELECT MIN(vilagranglista)
      FROM athletes
      WHERE aktiv = TRUE
  );

-- ============================================
-- 24. feladat
-- Top 10-es aktív sportolók fizetésemelése
-- ============================================

UPDATE athletes
SET havi_ber = ROUND(havi_ber * 1.20, 0)
WHERE vilagranglista BETWEEN 1 AND 10
  AND aktiv = TRUE;

-- ============================================
-- 25. feladat
-- Idős vagy rossz ranglistás sportolók inaktiválása
-- ============================================

UPDATE athletes
SET aktiv = FALSE
WHERE aktiv = TRUE
  AND (
      szuletesi_ev < 1992
      OR vilagranglista > 80
  );

-- ============================================
-- 26. feladat
-- Inaktív sportolók bércsökkentése
-- ============================================

UPDATE athletes
SET havi_ber = ROUND(havi_ber * 0.85, 0)
WHERE aktiv = FALSE;

-- ============================================
-- 27. feladat
-- Klub nélküli inaktív sportolók törlése
-- ============================================

DELETE FROM athletes
WHERE aktiv = FALSE
  AND club_id IS NULL;

-- ============================================
-- 28. feladat
-- 1992 előtt született inaktív sportolók törlése
-- ============================================

DELETE FROM athletes
WHERE aktiv = FALSE
  AND szuletesi_ev < 1992;