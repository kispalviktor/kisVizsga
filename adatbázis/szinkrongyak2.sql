-- 2. Lekérdezés segítségével írassa ki a nem „amerikai” nemzetiségű színészek nevét!
-- Az eredményt névsor szerinti növekvő sorrendbe rendezze!

SELECT nev
FROM szineszek
WHERE nemzetiseg != 'amerikai'
ORDER BY nev ASC;

-- 3. Készítsen lekérdezést, amely listázza a „vígjáték” műfajú filmeket!
-- A film címe, megjelenési éve és a rendező neve jelenjen meg,
-- megjelenési év szerint növekvő sorrendben!

SELECT cim, megjelenes_eve, rendezo
FROM filmek
WHERE mufaj = 'vígjáték'
ORDER BY megjelenes_eve ASC;

-- 4. Listázza ki azt az 5 filmet, amelyeknél a mozijegy ára meghaladja a 2500 forintot
-- és 2019 után jelentek meg!
-- A film címe, műfaja, megjelenési éve és jegyára jelenjen meg,
-- jegyár szerint csökkenő, azonos jegyárnál megjelenési év szerint
-- szintén csökkenő sorrendben!

SELECT cim, mufaj, megjelenes_eve, jegy_ar
FROM filmek
WHERE jegy_ar > 2500
  AND megjelenes_eve > 2019
ORDER BY jegy_ar DESC, megjelenes_eve DESC
LIMIT 5;

-- 5. Lekérdezés segítségével határozza meg, hogy műfajonként hány film szerepel
-- az adatbázisban!
-- Az eredmény a műfaj nevét és a filmek számát tartalmazza,
-- filmszám szerint csökkenő sorrendben!

SELECT mufaj, COUNT(*) AS filmszam
FROM filmek
GROUP BY mufaj
ORDER BY filmszam DESC;

-- 6. Listázza ki Christopher Nolan összes filmjének szereplőit!
-- A lekérdezés jelenítse meg a színész nevét, állampolgárságát,
-- a film címét, a játszott szerep nevét és azt,
-- hogy főszerepben volt-e!
-- Az eredményt film cím szerint növekvő sorrendben,
-- a főszereplő szerint csökkenőben,
-- majd névsor szerint rendezze!

SELECT sz.nev,
       sz.nemzetiseg,
       f.cim,
       szp.szerepnev,
       szp.foszerep
FROM filmek f
JOIN szerepek szp ON f.id = szp.filmid
JOIN szineszek sz ON sz.id = szp.szineszid
WHERE f.rendezo = 'Christopher Nolan'
ORDER BY f.cim ASC,
         szp.foszerep DESC,
         sz.nev ASC;

-- 7. Listázza ki azokat a filmeket, amelyekhez még egyetlen szereplőt sem
-- rögzítettek az adatbázisban!
-- A film címe, megjelenési éve, műfaja és a rendező neve jelenjen meg,
-- megjelenési év szerint növekvő sorrendben!

SELECT f.cim,
       f.megjelenes_eve,
       f.mufaj,
       f.rendezo
FROM filmek f
LEFT JOIN szerepek szp ON f.id = szp.filmid
WHERE szp.id IS NULL
ORDER BY f.megjelenes_eve ASC;

-- 8. Listázza ki azoknak a színészeknek a nevét és születési évét,
-- akik „Cillian Murphy”-vel azonos állampolgárságúak!
-- Cillian Murphy neve ne jelenjen meg a listában!

SELECT nev, szuletesi_ev
FROM szineszek
WHERE nemzetiseg = (
    SELECT nemzetiseg
    FROM szineszek
    WHERE nev = 'Cillian Murphy'
)
AND nev != 'Cillian Murphy';

-- 9. Denis Villeneuve rendező neve tévesen szerepel az adatbázisban.
-- Frissítse a filmek tábla rendezo oszlopában az összes érintett sort:
-- a „Denis Villeneuve” értéket cserélje le
-- „Denis Villeneuve-Tremblay”-re!

UPDATE filmek
SET rendezo = 'Denis Villeneuve-Tremblay'
WHERE rendezo = 'Denis Villeneuve';

-- 10. Törölje a szerepek táblából az összes mellékszerepet
-- (ahol a foszerep értéke 0)!

DELETE FROM szerepek
WHERE foszerep = 0;

-- 11. A legtöbb filmben szereplő színészek áttekintéséhez
-- készítse el a lekérdezést!
-- A sorok filmszám szerint csökkenő sorrendben jelenjenek meg!
-- Csak azok a színészek szerepeljenek,
-- akik egynél több különböző filmben játszottak!

SELECT sz.nev,
       COUNT(DISTINCT szp.filmid) AS filmszam
FROM szineszek sz
JOIN szerepek szp ON sz.id = szp.szineszid
GROUP BY sz.id, sz.nev
HAVING COUNT(DISTINCT szp.filmid) > 1
ORDER BY filmszam DESC;

-- ============================================
-- TÁBLÁK
-- ============================================

-- szineszek
-- id              : A színész azonosítója (elsődleges kulcs)
-- nev             : A színész neve
-- szuletesi_ev    : A születési év
-- nemzetiseg      : A színész állampolgársága
-- nem             : A színész neme

-- filmek
-- id              : A film azonosítója (elsődleges kulcs)
-- cim             : A film címe
-- megjelenes_eve  : A film megjelenési éve
-- mufaj           : A film műfaja
-- rendezo         : A rendező neve
-- jegy_ar         : A mozijegy ára forintban

-- szerepek
-- id              : A szereplés azonosítója (elsődleges kulcs)
-- filmid          : A film azonosítója
-- szineszid       : A színész azonosítója
-- szerepnev       : A játszott szereplő neve
-- foszerep        : 1 = főszerep, 0 = mellékszerep