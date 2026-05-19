// 1. feladat:

let nev = prompt("Add meg a neved:");
console.log("Szia " + nev + "!");

//2. feladat:

let a = Number(prompt("Add meg a téglalap egyik oldalát:"));
let b = Number(prompt("Add meg a téglalap másik oldalát:"));

let teglalap_kerulet = 2 * (a + b);
let teglalap_terulet = a * b;

console.log("Kerület: " + teglalap_kerulet);
console.log("Terület: " + teglalap_terulet);

// 3. feladat:

let r = Number(prompt("Add meg a kör sugarát:"));
const PI = Math.PI;

let kor_terulet = PI * r * r;
let kor_kerulet = 2 * r * PI;

console.log("Terület: " + kor_terulet.toFixed(2));
console.log("Kerület: " + kor_kerulet.toFixed(2));

// 4. feladat:

let dobas = Math.floor(Math.random() * 6) + 1;
console.log("A dobókocka értéke: " + dobas);

// 5. feladat:

let lottoSzam = Math.floor(Math.random() * 90) + 1;
console.log("A kihúzott lottószám: " + lottoSzam);

// 6. feladat:

let inch = Number(prompt("Add meg az értéket inch-ben:"));
let cm = inch * 2.71;

console.log(inch + " inch = " + cm.toFixed(2) + " cm");

// 7. feladat:

let ora = Number(prompt("Óra:"));
let perc = Number(prompt("Perc:"));
let masodperc = Number(prompt("Másodperc:"));

let osszesMasodperc = ora * 3600 + perc * 60 + masodperc;

console.log("A nap " + osszesMasodperc + ". másodpercében vagyunk.");

// 9. feladat

let egy = Number(prompt("Írja be az első számot:"))
let ketto = Number(prompt("Írja be a második számot:"))
let harom = Number(prompt("Írja be az harmadik számot:"))

let szamtaniKozep = (egy + ketto + harom) / 3

console.log(szamtaniKozep)