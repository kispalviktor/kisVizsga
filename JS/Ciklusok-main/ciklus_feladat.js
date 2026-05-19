//  Tetszőleges betűvel tetszőleges (1-10) sort töltsünk fel a képernyőn!

let sorokSzama = 6
let betu = "*"
for (let i = 0; i < sorokSzama; i++) {
    console.log(betu.repeat(i));
}

// 3. Írassuk ki 99-től csökkenő sorrendben az összes pozitív, 3-mal osztható egész számot!
// for (let i = 99; i > 0; i--) {
//     if (i % 3 == 0) {
//         console.log(i);
//     }
// }


// 4.HF

// 5. Határozzuk meg az első N természetes szám összegét!
// let N = 10
// let osszeg = 0

// for (let i = 1; i <= N; i++) {
//     osszeg += 1
// }

// console.log(`Az első ${N} természetes szám összege ${osszeg}`)


// 6. Írjuk ki az első N négyzetszám átlagát!

// 8. Készítsünk N-es szorzótáblát (1xN, 2xN,...)!
// let N2 = 6

// for (let i = 1; i <= 10; i++) {
//     console.log(`${i} x ${N2} = ${i * N2}`)
// }

// 11. Szimuláljunk egy N-szeres kockadobást: dobjunk fel N-szer egy kockát a gép segítségével. Írjuk ki 
// az egyes dobások eredményét, majd a sorozat végén a dobások átlagát is!

// let dobasszam = 0
// let dobasokOsszege = 0

// while (true) {
//     let dobas = Math.floor(Math.random() * 6) + 1
//     console.log(dobas);

//     dobasszam++;
//     dobasokOsszege += dobas

//     if(dobas === 6) {
//         break
//     }

// }

// let dobasokAtlaga = dobasokOsszege / dobasszam
// console.log(`A dobások átlaga ${dobasokAtlaga}`)

// 12. Szimuláljunk kockadobást: dobjuk fel addig a kockát, amíg 3 db hatost nem dobunk.
// Írjuk ki az egyes dobások eredményét, majd a sorozat végén a dobások átlagát is!

let dobasszam = 0
let dobasokOsszege = 0
let hatosDobasokSzama = 0

while (hatosDobasokSzama < 3) {
    let dobas = Math.floor(Math.random() * 6) + 1
    console.log(dobas);

    dobasszam++;
    dobasokOsszege += dobas

    if(dobas === 6) {
        hatosDobasokSzama++
    }
}

let dobasokAtlaga = dobasokOsszege / dobasszam
console.log(`A dobások átlaga ${dobasokAtlaga}`)

// 13. Szimuláljunk kockadobást: dobjuk fel addig a kockát, amíg a dobások összege kisebb,
// mint K. Írjuk ki az egyes dobások eredményét, majd a sorozat végén a dobások átlagát
// is!

// 14. Kérjen be a program számokat mindaddig, amíg 0-át nem írunk be! Ezután írja ki, hogy
// páros szám volt a beírt számok között!
let voltParos = false;
while(true){
    let szam = parseInt(prompt("Kérem adj meg egy számot (0-val kilépsz)!"));

    if(isNaN(szam)) {
        alert("Érvénytelen bevitel, kérlek adj meg egy számot");
        continue;
    }
        console.log(szam)

    if(szam === 0){
        break;
    }

    if(szam % 2 === 0){
        voltParos = true;
    }
}

if (voltParos) {
    console.log("Volt Páros")
}
else{
    console.log("NEM volt Páros")
}