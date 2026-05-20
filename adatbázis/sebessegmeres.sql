-- 1. feladat 
SELECT varos, utca, sebesseg_hatar, helyszin_tipus FROM helyszinek 
WHERE (helyszin_tipus = 'autópálya' AND sebesseg_hatar >= 100) OR (helyszin_tipus = 'lakóövezet' AND sebesseg_hatar <= 30)
ORDER BY helyszin_tipus, varos;

-- 2. feladat
SELECT id, mert_sebesseg, meres_datuma, meres_oraja, birsag_osszeg FROM meresek
WHERE mert_sebesseg > 100 AND (meres_oraja > '20:00:00' AND meres_oraja < '06:00:00' OR birsag_osszeg <= 90000)
ORDER BY birsag_osszeg DESC, mert_sebesseg DESC;

-- 3. feladat
SELECT vezeteknev, keresztnev, lakcim_varos, pontszam FROM jarmuvezetok
WHERE (pontszam > 5 AND (lakcim_varos = 'Budapest' OR lakcim_varos = 'Miskolc')) OR pontszam >= 10
ORDER BY pontszam DESC, vezeteknev ASC;

-- 4. feladat
SELECT id, mert_sebesseg, tullepes_km, meres_datuma, birsag_osszeg FROM meresek
WHERE meres_datuma BETWEEN '2024-01-01' AND '2024-06-30' AND tullepes_km > 30 ORDER BY meres_datuma, tullepes_km DESC;

-- 5. feladat
SELECT rendszam, marka, tipus, gyartas_eve FROM jarmuvek
WHERE gyartas_eve > 2018 AND marka != 'Toyota' AND marka != 'BMW' ORDER BY gyartas_eve DESC, marka ASC LIMIT 4;

-- 6. feladat
SELECT m.id, h.varos, h.utca, h.sebesseg_hatar, m.mert_sebesseg, m.tullepes_km FROM helyszinek h
INNER JOIN meresek m ON m.helyszin_id = h.id WHERE h.helyszin_tipus = 'főút' AND m.tullepes_km >= 20 
ORDER BY m.tullepes_km DESC, h.varos ASC;

-- 7. feladat
SELECT CONCAT(j.vezeteknev, ' ', j.keresztnev) AS teljes_nev, m.mert_sebesseg, m.meres_datuma, m.birsag_osszeg, m.kifizetve FROM jarmuvezetok j
INNER JOIN meresek m ON m.vezeto_id = j.id WHERE m.birsag_osszeg >= 50000 AND m.kifizetve = FALSE
ORDER BY m.birsag_osszeg DESC, m.meres_datuma ASC;

-- 8. feladat
SELECT j.rendszam, j.marka, j.kategoria, m.mert_sebesseg, m.tullepes_km, m.meres_datuma FROM jarmuvek j
INNER JOIN meresek m ON j.id = m.jarmu_id WHERE (j.kategoria = 'motorkerékpár' OR j.kategoria = 'tehergépjármű')
AND m.mert_sebesseg > 100 ORDER BY meres_datuma, mert_sebesseg DESC;

-- 9. feladat
SELECT CONCAT(j.vezeteknev, ' ', j.keresztnev) AS teljes_nev, h.varos, h.utca, m.jarmu_id, m.mert_sebesseg, m.birsag_osszeg FROM meresek m
INNER JOIN helyszinek h ON m.helyszin_id = h.id
INNER JOIN jarmuvezetok j ON m.vezeto_id = j.id
WHERE meres_datuma BETWEEN '2024-07-01' AND '2024-12-31'
ORDER BY varos, teljes_nev, meres_datuma ASC;

-- 1. feladat (3 pont)
-- Listázd ki azokat a helyszíneket, ahol autópályai helyszínről van szó ÉS a sebességhatár legalább 100
-- km/h, VAGY ahol lakóövezeti helyszínről van szó ÉS a sebességhatár legfeljebb 30 km/h! Jelenítsd
-- meg a varos , utca , sebesseg_hatar és helyszin_tipus oszlopokat! Rendezd
-- helyszin_tipus, majd varos szerint növekvő sorrendbe!

-- 2. feladat (3 pont)
-- Listázd ki azokat a méréseket, ahol a mért sebesség meghaladja a 100 km/h-t, ÉS emellett vagy éjjel
-- történt (20:00 után VAGY 06:00 előtt), VAGY a bírság összege eléri a 90 000 Ft-ot! Jelenítsd meg az
-- id , mert_sebesseg , meres_datuma , meres_oraja és birsag_osszeg oszlopokat! Rendezd
-- birsag_osszeg csökkenő, majd mert_sebesseg csökkenő sorrendbe!

-- 3. feladat (4 pont)
-- Listázd ki azokat a járművezetőket, akiknek büntetőpontjuk meghaladja az 5-öt ÉS (Budapesten
-- VAGY Miskolcon laknak), VAGY akiknek büntetőpontja eléri vagy meghaladja a 10-et! Jelenítsd meg
-- a vezeteknev , keresztnev , lakcim_varos és pontszam oszlopokat! Rendezd pontszam
-- csökkenő, majd vezeteknev szerint növekvő sorrendbe!

-- 4. feladat (3 pont)
-- Listázd ki a 2024 első félévének ( 2024-01-01 – 2024-06-30 ) kifizetetlen méréseit, ahol a túllépés
-- meghaladja a 30 km/h-t! Jelenítsd meg az id , mert_sebesseg , tullepes_km , meres_datuma
-- és birsag_osszeg oszlopokat! Rendezd meres_datuma, majd tullepes_km csökkenő sorrendbe! A
-- dátum szűrésnél használd a BETWEEN operátort!

-- 5. feladat (3 pont)
-- Listázd ki a 2018 után gyártott személyautókat, amelyek nem Toyota és nem BMW márkájúak ( NOT
-- IN )! Jelenítsd meg a rendszam , marka , tipus és gyartas_eve oszlopokat! Rendezd
-- gyartas_eve csökkenő, majd marka szerint növekvő sorrendbe! Csak az első 4 találatot jelenítsd
-- meg!

-- SELECT – INNER JOIN
-- 6. feladat (4 pont)
-- Listázd ki a főúti helyszíneken rögzített méréseket, ahol a túllépés legalább 20 km/h! Jelenítsd meg:
-- m.id , varos , utca , sebesseg_hatar , mert_sebesseg , tullepes_km ! Rendezd tullepes_km
-- csökkenő, majd varos szerint növekvő sorrendbe!

-- sebessegmeres_feladatsor.md 2026-03-26

-- 7 / 11

-- 7. feladat (4 pont)
-- Listázd ki a kifizetetlen, legalább 50 000 Ft-os méréseket a járművezető teljes nevével ( CONCAT -tal,
-- teljes_nev álnéven) együtt! Jelenítsd meg: teljes_nev , mert_sebesseg , meres_datuma ,
-- birsag_osszeg , kifizetve ! Rendezd birsag_osszeg csökkenő, majd meres_datuma szerint
-- növekvő sorrendbe!

-- 8. feladat (4 pont)
-- Listázd ki azokat a méréseket, amelyeket motorkerékpárral VAGY tehergépjárművel követtek el, ÉS a
-- mért sebesség meghaladja a 100 km/h-t! Jelenítsd meg: rendszam , marka , kategoria ,
-- mert_sebesseg , tullepes_km , meres_datuma ! Rendezd meres_datuma, majd mert_sebesseg
-- csökkenő sorrendbe!

-- 9. feladat (5 pont)
-- Listázd ki a 2024 második félévének ( 2024-07-01 -től) méréseit a vezető teljes nevével és a
-- helyszín varos + utca adataival! Jelenítsd meg: teljes_nev , varos , utca , jarmu_id (a
-- mérések táblából), mert_sebesseg , birsag_osszeg ! Rendezd varos, majd teljes_nev, majd
-- meres_datuma szerint növekvő sorrendbe!