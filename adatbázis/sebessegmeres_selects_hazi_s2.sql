-- Gyakorló feladatok - SELECT utasítások
-- Speed Measurements Database - Query Exercises
-- speed_measurements adatbázishoz

-- ========================================
-- EGYSZERŰ LEKÉRDEZÉSEK (FROM)
-- ========================================

-- 1. Listázd ki az összes tulajdonost!

SELECT * FROM tulajdonosok;


-- 2. Listázd ki az összes járművet!

SELECT * FROM jarmuvek;

-- 3. Listázd ki az összes mérési helyszínt!

SELECT * FROM helyszinek;

-- 4. Listázd ki az összes mérőeszközt!

SELECT * FROM meroeszkozok;

-- 5. Listázd ki az összes mérést!

SELECT * FROM meresek;

-- ========================================
-- ALIAS HASZNÁLATA
-- ========================================

-- 6. Listázd ki a tulajdonosok nevét és email címét magyar oszlopnevekkel!

SELECT nev AS "Név", email AS "Email cím"
FROM tulajdonosok;

-- 7. Listázd ki a járművek rendszámát és márkáját magyar oszlopnevekkel!

SELECT rendszam AS "Rendszám", marka AS "Márka"
FROM jarmuvek;

-- 8. Listázd ki a mérések sebességét "Mért sebesség" néven!

SELECT sebesseg AS "Mért sebesség"
FROM meresek;

-- ========================================
-- WHERE FELTÉTELEK
-- ========================================

-- 9. Melyik helyszínek sebességkorlátja 50 km/h?

SELECT *
FROM helyszinek
WHERE sebessegkorlat = 50;

-- 10. Listázd ki azokat a járműveket, amelyek 2021-ban vagy később készültek!

SELECT *
FROM jarmuvek
WHERE gyartasi_ev >= 2021;

-- 11. Melyik mérések esetén haladta meg a mért sebesség a 80 km/h-t?

SELECT *
FROM meresek
WHERE sebesseg > 80;

-- 12. Listázd ki a budapesti helyszíneket!

SELECT *
FROM helyszinek
WHERE varos = 'Budapest';

-- 13. Melyik tulajdonosok születtek 1995 előtt?

SELECT *
FROM tulajdonosok
WHERE szuletesi_datum < '1995-01-01';

-- 14. Listázd ki a fekete színű járműveket!

SELECT *
FROM jarmuvek
WHERE szin = 'fekete';

-- 15. Melyik bírságok vannak még kifizetetlenül?

SELECT *
FROM birsagok
WHERE kifizetve = 0;

-- 16. Listázd ki azokat a méréseket, amelyek 2024 februárjában történtek!

SELECT * FROM meresek WHERE datum >= '2024-02-01' AND datum < '2024-03-01';

-- 17. Melyik mérőeszközök típusa "radar"?

SELECT * FROM meroeszkozok WHERE tipus = 'radar';

-- 18. Listázd ki azokat a helyszíneket, ahol a sebességkorlát 60 km/h vagy annál nagyobb!

SELECT *
FROM helyszinek
WHERE sebessegkorlat >= 60;

-- ========================================
-- WHERE ÉS TÖBB FELTÉTEL (AND, OR)
-- ========================================

-- 19. Listázd ki a budapesti helyszíneket, ahol a sebességkorlát 50 km/h!

SELECT *
FROM helyszinek
WHERE varos = 'Budapest'
  AND sebessegkorlat = 50;

-- 20. Melyik járművek BMW vagy Audi márkájúak?

SELECT *
FROM jarmuvek
WHERE marka = 'BMW' OR marka = 'Audi';

-- 21. Listázd ki azokat a méréseket, ahol a sebesség 70 és 90 km/h között volt!

SELECT *
FROM meresek
WHERE sebesseg BETWEEN 70 AND 90;

-- 22. Melyik bírságok összege nagyobb mint 40000 Ft ÉS még nincsenek kifizetve?

SELECT *
FROM birsagok
WHERE osszeg > 40000
  AND kifizetve = 0;

-- 23. Listázd ki a fehér vagy fekete járműveket!

SELECT *
FROM jarmuvek
WHERE szin IN ('fehér', 'fekete');

-- ========================================
-- ORDER BY (RENDEZÉS)
-- ========================================

-- 24. Listázd ki a tulajdonosokat név szerint ABC sorrendben!

SELECT *
FROM tulajdonosok
ORDER BY nev ASC;

-- 25. Listázd ki a járműveket gyártási év szerint csökkenő sorrendben!

SELECT *
FROM jarmuvek
ORDER BY gyartasi_ev DESC;

-- 26. Melyik mérések történtek, rendezve a mért sebesség szerint csökkenő sorrendben?

SELECT *
FROM meresek
ORDER BY sebesseg DESC;

-- 27. Listázd ki a bírságokat összeg szerint növekvő sorrendben!

SELECT *
FROM birsagok
ORDER BY osszeg ASC;

-- 28. Rendezd a helyszíneket város, majd utca szerint ABC sorrendben!

SELECT *
FROM helyszinek
ORDER BY varos ASC, utca ASC;

-- 29. Listázd ki a méréseket dátum szerint csökkenő, majd időpont szerint növekvő sorrendben!

SELECT *
FROM meresek
ORDER BY datum DESC, idopont ASC;