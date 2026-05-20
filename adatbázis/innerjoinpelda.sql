-- INNER JOIN példa
-- Aktív sportolók neve és sportáguk neve

SELECT CONCAT(a.vezeteknev, ' ', a.keresztnev) AS teljes_nev,
       s.nev AS sportag
FROM athletes a
INNER JOIN sports s ON a.sport_id = s.id
WHERE a.aktiv = TRUE
ORDER BY s.nev ASC, teljes_nev ASC;