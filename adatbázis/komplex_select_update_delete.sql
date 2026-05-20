-- ============================================
-- TÁBLÁK
-- ============================================

-- jatekosok
-- id          : A játékos azonosítója (elsődleges kulcs)
-- nev         : A játékos neve
-- csapat      : A csapat neve
-- poszt       : A játékos posztja
-- mezszam     : A játékos mezszáma
-- kor         : A játékos életkora

-- merkozesek
-- id              : A mérkőzés azonosítója (elsődleges kulcs)
-- datum           : A mérkőzés dátuma
-- hazai_csapat    : A hazai csapat neve
-- vendeg_csapat   : A vendég csapat neve
-- helyszin        : A mérkőzés helyszíne
-- nezoszam        : A nézőszám

-- golelozmenyek
-- id          : Az esemény azonosítója (elsődleges kulcs)
-- merkozesid  : A mérkőzés azonosítója
-- jatekosid   : A játékos azonosítója
-- perc        : A gólesemény perce
-- tipus       : Az esemény típusa

-- 2. Lekérdezés segítségével írassa ki a nem „Ferencváros TC”
-- csapatban játszó játékosok nevét!
-- Az eredményt névsor szerinti növekvő sorrendbe rendezze!

SELECT nev
FROM jatekosok
WHERE csapat <> 'Ferencváros TC'
ORDER BY nev ASC;

-- 3. Készítsen lekérdezést, amely listázza a „Groupama Aréna”
-- helyszínen, legalább 20 000 főnyi néző előtt lejátszott mérkőzéseket!
-- A mérkőzés dátuma, a hazai csapat neve, a vendég csapat neve
-- és a nézőszám jelenjen meg,
-- nézőszám szerint csökkenő sorrendben!

SELECT datum,
       hazai_csapat,
       vendeg_csapat,
       nezoszam
FROM merkozesek
WHERE helyszin = 'Groupama Aréna'
  AND nezoszam >= 20000
ORDER BY nezoszam DESC;

-- 4. A legalább 28 éves, „csatár” vagy „középpályás”
-- poszton játszó játékosokat írassa ki!
-- A játékos neve, csapata, posztja és kora jelenjen meg,
-- kor szerint csökkenő sorrendben!
-- Az eredményben legfeljebb 10 sor szerepeljen!

SELECT nev,
       csapat,
       poszt,
       kor
FROM jatekosok
WHERE kor >= 28
  AND (poszt = 'csatár' OR poszt = 'középpályás')
ORDER BY kor DESC
LIMIT 10;

-- 5. Lekérdezés segítségével határozza meg,
-- hogy melyik csapatnak hány játékosa van az adatbázisban!
-- Az eredmény a csapat nevét és a játékosok számát tartalmazza,
-- a játékosok száma szerint csökkenő sorrendben!
-- Csak a három legtöbb játékossal rendelkező csapat jelenjen meg!

SELECT csapat,
       COUNT(*) AS jatekosok_szama
FROM jatekosok
GROUP BY csapat
ORDER BY jatekosok_szama DESC
LIMIT 3;

-- 6. Készítsen lekérdezést, amely megmutatja,
-- ki a top 5 gólszerző a bajnokságban!
-- A lista tartalmazza a játékos nevét, csapatát
-- és a szerzett góljai számát!
-- Csak azok a játékosok jelenjenek meg,
-- akik legalább 2 gólt szereztek!
-- Az eredmény gólok száma szerint csökkenő sorrendben legyen rendezve!

SELECT j.nev,
       j.csapat,
       COUNT(*) AS golok_szama
FROM jatekosok j
JOIN golelozmenyek g ON j.id = g.jatekosid
WHERE g.tipus IN ('gól', 'tizenegyes')
GROUP BY j.id, j.nev, j.csapat
HAVING COUNT(*) >= 2
ORDER BY golok_szama DESC
LIMIT 5;

-- 7. Listázza ki azokat a játékosokat,
-- akik egyszer sem szerepelnek a gólesemények között!
-- A játékos neve, csapata és posztja jelenjen meg,
-- csapat szerinti ábécérendben!

SELECT j.nev,
       j.csapat,
       j.poszt
FROM jatekosok j
LEFT JOIN golelozmenyek g ON j.id = g.jatekosid
WHERE g.id IS NULL
ORDER BY j.csapat ASC;

-- 8. Listázza ki azoknak a játékosoknak a nevét,
-- akik „Dzsudzsák Balázs”-sal azonos csapatban szerepelnek!
-- Dzsudzsák Balázs neve ne jelenjen meg a listában!
-- (Beágyazott lekérdezés)

SELECT nev
FROM jatekosok
WHERE csapat = (
    SELECT csapat
    FROM jatekosok
    WHERE nev = 'Dzsudzsák Balázs'
)
AND nev <> 'Dzsudzsák Balázs';

-- 9. A „Győri ETO FC” csapat neve tévesen szerepel az adatbázisban.
-- Frissítse a jatekosok tábla csapat oszlopában az összes érintett sort:
-- a „Győri ETO FC” értéket cserélje le „ETO FC Győr”-re!

UPDATE jatekosok
SET csapat = 'ETO FC Győr'
WHERE csapat = 'Győri ETO FC';

-- 10. Törölje a golelozmenyek táblából
-- az összes öngólnak minősített eseményt!

DELETE FROM golelozmenyek
WHERE tipus = 'öngól';

-- 11. Listázza ki a 2029. április 12-i
-- „Ferencváros TC” hazai mérkőzésen bekövetkező összes góleseményt!
-- Jelenjen meg a gólszerző játékos neve, csapata,
-- az esemény perce és típusa!
-- Az eredményt a gólszerzés perce szerint növekvő sorrendben rendezze!
-- (Háromtáblás INNER JOIN)

SELECT j.nev,
       j.csapat,
       g.perc,
       g.tipus
FROM golelozmenyek g
INNER JOIN jatekosok j ON g.jatekosid = j.id
INNER JOIN merkozesek m ON g.merkozesid = m.id
WHERE m.datum = '2029-04-12'
  AND m.hazai_csapat = 'Ferencváros TC'
ORDER BY g.perc ASC;

