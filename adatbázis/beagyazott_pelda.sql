SELECT nev, szuletesi_ev
FROM szineszek
WHERE nemzetiseg = (
    SELECT nemzetiseg
    FROM szineszek
    WHERE nev = 'Cillian Murphy'
)
AND nev <> 'Cillian Murphy';