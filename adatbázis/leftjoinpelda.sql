SELECT f.cim,
       f.megjelenes_eve,
       f.mufaj,
       f.rendezo
FROM filmek f
LEFT JOIN szerepek szp ON f.id = szp.filmid
WHERE szp.id IS NULL
ORDER BY f.megjelenes_eve ASC;