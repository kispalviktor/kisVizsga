console.log(String.fromCharCode(65, 108, 109, 97));
console.log("   Java Script    ".trim());


//  1. Írj programot, ami bekéri a felhasználó bevét, majd keresztnevén szólítva köszönti!
// let nev = prompt("Kérlek add meg a neved! ")

// if(nev){
//     let felhasznalo = nev.split(" ")[1];
//     console.log(felhasznalo);
// }


// 2. Írj programot, mely megszámolja, hogy az inputként érkező mondatban hány darab ”a”
// betű van!
// let mondat = prompt("Kérlek add meg egy mondatot! ");
let mondat = "Kérlek add meg egy mondatot a! ";

let aBetu = 0;
for (let index = 0; index < mondat.length; index++) {
    if (mondat[index] === 'a') {
        aBetu++
    }
}

console.log(`${aBetu}`)

// 3. Olvass be egy szöveget, és írd ki a betűit fordított sorrendben!
let szoveg = "Kérlek add meg egy mondatot! ";
let forditottSzoveg = ""

for (let i = szoveg.length-1; i >= 0; i--) {
    // console.log(szoveg[i]);
    forditottSzoveg += szoveg[i]
}

console.log(forditottSzoveg)

// 4. 5. HF
