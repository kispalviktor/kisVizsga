-- Lekérdezés segítségével írassa ki a nem „pop&quot; stílusban alkotó előadók művésznevét! Az
-- eredményt névsor szerinti növekvő sorrendbe rendezze!
SELECT muvesznev FROM eloadok WHERE stilus != 'pop' ORDER BY muvesznev ASC;

-- Készítsen lekérdezést, amely listázza a 2010 után kiadott, 5 000 forintnál drágább albumokat!
-- Az album címe, kiadási éve, a kiadó neve és az ára jelenjen meg, kiadási év szerint növekvő,
-- azonos évnél ár szerint csökkenő sorrendben!
SELECT cim, kiadas_eve, kiadonev, ar FROM albumok WHERE kiadas_eve > 2010 AND ar > 5000 ORDER BY kiadas_eve ASC, ar DESC;

-- Listázza ki az 1980 előtt született (illetve alakult) "rock" vagy "metal" stílusú előadókat! A
-- művésznév, a valódi név, a születési/megalakulási év és a stílus jelenjen meg, születési év
-- szerint növekvő sorrendben! Az eredményben legfeljebb 5 sor szerepeljen!
SELECT muvesznev, igazi_nev, szuletesi_ev, stilus FROM eloadok WHERE szuletesi_ev < 1980 AND (stilus = 'rock' OR stilus = 'metal') ORDER BY szuletesi_ev ASC LIMIT 5;
SELECT muvesznev, igazi_nev, szuletesi_ev, stilus FROM eloadok WHERE szuletesi_ev < 1980 AND stilus IN ('rock', 'metal') ORDER BY szuletesi_ev ASC LIMIT 5;

-- Lekérdezés segítségével határozza meg, hogy az egyes előadóknak hány albumuk szerepel
-- az adatbázisban! Az eredmény a művésznevet és az albumok számát tartalmazza,
-- albumszám szerint csökkenő sorrendben! Csak a top 5 előadó jelenjen meg!
SELECT muvesznev, COUNT(a.id) AS albumok_szama FROM eloadok e LEFT JOIN albumok a ON a.eloadoid = e.id GROUP BY e.id ORDER BY albumok_szama DESC LIMIT 5;

-- Listázza ki lekérdezéssel azokat az előadókat, akiknek egyetlen albumuk sem szerepel az
-- adatbázisban! A művésznév, a stílus és a születési/megalakulási év jelenjen meg, névsor
-- szerinti sorrendben!
SELECT muvesznev, stilus, szuletesi_ev FROM eloadok e LEFT JOIN albumok a ON a.eloadoid = e.id WHERE a.id IS NULL ORDER BY muvesznev;

-- Lekérdezés segítségével listázza ki azokat az előadókat (művésznevüket, valódi nevüket és
-- születési évüket), akik ugyanabban a zenei stílusban alkotnak, mint a "Queen" együttes! A
-- "Queen" neve ne jelenjen meg a listában!
SELECT muvesznev, igazi_nev, szuletesi_ev FROM eloadok WHERE stilus = (SELECT stilus FROM eloadok WHERE muvesznev = 'Queen') AND muvesznev != 'Queen';

-- A Warner Bros. Records kiadó neve megváltozott. Frissítse az albumok tábla kiadonev
-- oszlopában az összes érintett sort: a "Warner Bros. Records" értéket cserélje le "Warner
-- Music Group"-ra!
SET SQL_SAFE_UPDATES = 0;
UPDATE albumok SET kiadonev = 'Warner Music Group' WHERE kiadonev = 'Warner Bros. Records';

-- Törölje a dalok táblából azokat a dalokat, amelyek hossza kevesebb mint 80 másodperc
-- (ezek hibás adatrögzítés következményei)!
DELETE FROM dalok WHERE hossz_mp < 80;

-- Listázza ki lekérdezéssel a "Daft Punk" együttes összes dalát, feltüntetve, hogy melyik
-- albumon szerepelnek! Az album neve, kiadási éve, a dal sorszáma és a dal neve jelenjen
-- meg, az albumok kiadási éve szerint, azon belül a sorszám szerint növekvő sorrendben!
SELECT a.cim, a.kiadas_eve, d.sorszam, d.cim FROM eloadok e
INNER JOIN albumok a ON e.id = a.eloadoid
INNER JOIN dalok d ON a.id = d.albumid
WHERE e.muvesznev = 'Daft Punk' ORDER BY a.kiadas_eve, d.sorszam ASC;

-- Az albumok dalgazdagságának áttekintéséhez készítse el a minta szerinti lekérdezést! Az
-- oszlopok a minta szerinti sorrendben jelenjenek meg! A sorok dalok száma szerint csökkenő
-- sorrendben legyenek rendezve! Csak azok az albumok jelenjenek meg, amelyeken legalább
-- 5 dal található!
SELECT e.muvesznev, a.cim AS album_cim, a.kiadas_eve, COUNT(sorszam) AS dalok_szama, ROUND(AVG(hossz_mp), 0) AS atlag_hossz_mp FROM eloadok e
INNER JOIN albumok a ON e.id = a.eloadoid
INNER JOIN dalok d ON a.id = d.albumid
GROUP BY e.muvesznev, album_cim, kiadas_eve HAVING dalok_szama >= 5 ORDER BY dalok_szama DESC;



-- eloadok (id, muvesznev, igazi_nev, szuletesi_ev, stilus)
-- Mező Leírás
-- id Az előadó azonosítója (szám), elsődleges kulcs
-- muvesznev Az előadó művészneve vagy együttese neve (szöveg)
-- igazi_nev Az előadó valódi neve (szöveg)
-- szuletesi_ev Az előadó (vagy az együttes megalakulásának) éve (szám)
-- stilus A zenei stílus: pop, rock, jazz, hiphop, elektronikus, metal, soul, indie

-- (szöveg)

-- albumok (id, eloadoid, cim, kiadas_eve, kiadonev, ar)
-- Mező Leírás
-- id Az album azonosítója (szám), elsődleges kulcs
-- eloadoid Az előadó azonosítója (szám)
-- cim Az album címe (szöveg)
-- kiadas_eve A kiadás éve (szám)
-- kiadonev A kiadó neve (szöveg)
-- ar Az album vételára forintban (szám)

-- dalok (id, albumid, cim, hossz_mp, sorszam)
-- Mező Leírás
-- id A dal azonosítója (szám), elsődleges kulcs
-- albumid Az album azonosítója (szám)
-- cim A dal címe (szöveg)
-- hossz_mp A dal hossza másodpercben (szám)
-- sorszam A dal sorszáma az albumon (szám)