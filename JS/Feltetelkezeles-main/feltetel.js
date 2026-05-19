//1. Egy beolvasott számról döntse el a program, hogy -30 és 40 között van-e
// let szam = parseFloat(prompt("Kérlek adj meg egy számot!"));
// if (szam > -30 && szam < 40){
//     console.log("A szám -30 és 40 között van")
// }
// else{
//     console.log("A szám nem -30 és 40 között van")
// }


// 2.Két beolvasott szám közül írassuk ki a nagyobbikat! Azt is írassuk ki, ha egyenlők!
// let szam1 = parseFloat(prompt("Kérlek add meg az első számot!"));
// let szam2 = parseFloat(prompt("Kérlek add meg a második számot!"));

// if(szam1 > szam2){
//     console.log(`A nagyobb szám a ${szam1}`)
// }
// else if(szam1 < szam2){
//     console.log(`A nagyobb szám a ${szam2}`)
// }
// else if(szam1 == szam2){
//     console.log(`A két szám eggyenlő: ${szam1}`)
// }

// 3. Egy beolvasott X számnak írjuk ki az előjelét (pozitív, negatív vagy nulla)!

let x = Number(prompt("Adj meg egy számot:"));

if (x > 0) {
  console.log("pozitív");
} else if (x < 0) {
  console.log("negatív");
} else {
  console.log("nulla");
}


// 4. Kérjünk be egy számot és döntsük el, hogy egész szám-e! Csak ebben az esetben írassuk 
// ki!

// let szam3 = parseFloat(prompt("Kérlek add meg az első számot!"));

// if(Number.isInteger(szam3)){
//     console.log("A szám egész: " + szam3)
// }

// 5. A program kérdezzen két számot, s utána írja ki a köztük lévő relációt. Például, ha a két
// szám 3 és -6.12, akkor az eredmény: 3 > -6.12.

let a = Number(prompt("Add meg az első számot:"));
let b = Number(prompt("Add meg a második számot:"));

if (a > b) {
  console.log(a + " > " + b);
} else if (a < b) {
  console.log(a + " < " + b);
} else {
  console.log(a + " = " + b);
}


// 6. Írj programot, ami egy életkor alapján eldönti, hogy gyerek (0-6 év), iskolás (7-18),
// dolgozó (19-60), illetve nyugdíjas-e az illető!

// let eletkor = parseInt(prompt("Kérlek add meg az első számot!"));

// if(eletkor >= 0 && eletkor <= 6){
//     console.log("Gyerek")
// }
// else if(eletkor >= 7 && eletkor <= 18){
//     console.log("Iskolás")
// }
// else if(eletkor >= 19 && eletkor <= 60){
//     console.log("Dolgozó")
// }
// else if(eletkor > 60 && eletkor <= 120){
//     console.log("Nyugdíjas")
// }
// else{
//     console.log("Érvénytelen")
// }

// 7. Fej vagy írás? A játék célja, hogy a játékos eltalálja, hogy a feldobott pénz fej vagy írás
// lesz. A játékos adjon tippet (fej, írás), majd a gép dobjon fel egy pénzérmét és írja ki,
// hogy a játékos nyert vagy vesztett.

// let tipp = prompt("Kérlek add meg a tipped (fej / írás)")
// let dobas = Math.random()
// let dobasErtek = ""

// if(dobas < 0.5){
//     dobasErtek = "fej"
// }
// else{
//     dobasErtek = "írás"
// }

// if (tipp.toLowerCase() === dobasErtek){
//     console.log("Eltaláltad")
// }
// else{
//     console.log("Nem találtad el")
// }

// 8. A gép dobjon dobókockával, majd két játékos tippelje meg a dobás eredményét. Az a
// játékos nyer, akinek a tippje közelebb van a kockadobás eredményéhez.

// 9. Adott egy pont, melynek bekérjük a koordinátáit. Határozzuk meg, melyik
// síknegyedben van!

// let x = parseFloat(prompt("Adja meg az X koordinátát"));
// let y = parseFloat(prompt("Adja meg az Y koordinátát"));

// if(x > 0 && y > 0){
//     console.log("Az első sík negyedben van")
// }
// else if(x < 0 && y > 0){
//     console.log("A második sík negyedben van")
// }
// else if(x < 0 && y < 0){
//     console.log("A harmadik sík negyedben van")
// }
// else if(x > 0 && y < 0){
//     console.log("A negyedik sík negyedben van")
// }
// else if(x == 0 && y == 0){
//     console.log("Az origón van")
// }
// else if(x == 0){
//     console.log("Az X tengelyen van")
// }
// else if(y == 0){
//     console.log("Az Y tengelyen van")
// }

// 13. Kérjünk be egy évszámot és döntsük el, hogy szökőév-e! Egy év akkor szökőév, ha az
// évszám maradék nélkül osztható 4-gyel, de nem osztható 100-zal, kivéve, ha az évszám
// osztható 400-zal.

let evszam = Number(prompt("Adja meg az évet"));
let szokoEv = false

if(evszam % 400 === 0){
    szokoEv = true
}
else if(evszam % 100 === 0){
    szokoEv = false
}
else if(evszam % 4 === 0){
    szokoEv = true
}

if(szokoEv == true){
    console.log(evszam + " szökőév")
}
else{
    console.log(evszam + " nem szökőév")
}

// 14. Kérjük be egy hónap sorszámát, majd írjuk ki a nevét!

let honap = Number(prompt("Add meg a hónap sorszámát (1–12):"));
let honapok = ["január", "február", "március", "április", "május", "június", "július", "augusztus", "szeptember", "október", "november", "december"];

if (honap >= 1 && honap <= 12) {
  console.log(honapok[honap - 1]);
} else {
  console.log("Érvénytelen hónapszám!");
}


// 15. Kérjük be egy dolgozat pontszámát 1 és 100 között és írjuk ki az érdemjegyet! 0-40:
// elégtelen, 41-55: elégséges, 56-70: közepes, 71-85: jó, 86-100: jeles.

let pont = Number(prompt("Add meg a dolgozat pontszámát (1–100):"));

if (pont >= 0 && pont <= 40) {
  console.log("elégtelen");
} else if (pont >= 41 && pont <= 55) {
  console.log("elégséges");
} else if (pont >= 56 && pont <= 70) {
  console.log("közepes");
} else if (pont >= 71 && pont <= 85) {
  console.log("jó");
} else if (pont >= 86 && pont <= 100) {
  console.log("jeles");
} else {
  console.log("Érvénytelen pontszám!");
}
