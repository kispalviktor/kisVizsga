// Egy 3x3-as mátrixot tölts fel 0 és 9 közötti véletlenszámokkal, majd írasd ki!
// a. Számold ki a számok összegét soronként!
// b. Számold ki a számok összegét oszloponként!
// c. Sámold ki az átlók elemeinek összegét!

let matrix = []
let sor = 3
let oszlop = 3
let min = 0
let max = 9

for (let i = 0; i < sor; i++) {
    let matrixSor = []
    for (let j = 0; j < oszlop; j++) {
        let randomNumber = Math.floor(Math.random() * (max - min + 1) + min)
        matrixSor.push(randomNumber)
        // console.log(randomNumber)
    }
    matrix.push(matrixSor)
}

console.log(matrix);
// tömb bejárása elemei alapján
let matrixKiiratas = ''
for (const sor of matrix){
    for (const element of sor) {
        matrixKiiratas += element + " "
    }
    matrixKiiratas += "\n"
}

console.log(matrixKiiratas)

// tömb bejárása indexek alapján
let matrixKiiratasFor = ''
for (let i = 0; i < matrix.length; i++) {
    for (let j = 0; j < matrix[i].length; j++) {
        matrixKiiratasFor += matrix[i][j] + " "
    }
    matrixKiiratasFor += "\n"
}

console.log(matrixKiiratasFor);


// A
let sorOsszegek = []
for (const sor of matrix){
    let sorOsszeg = 0
    for (const element of sor) {
        sorOsszeg += element
    }
    sorOsszegek.push(sorOsszeg)
}

console.log(sorOsszegek)
for (const element of sorOsszegek) {
    console.log(element)
}

// B
let oszlopOsszegek = []
for (let i = 0; i < matrix.length; i++) {
    let oszlopOsszeg = 0
    for (let j = 0; j < matrix[i].length; j++) {
        oszlopOsszeg += matrix[j][i]
    }
    // console.log(oszlopOsszeg)
    oszlopOsszegek.push(oszlopOsszeg)
}

console.log(oszlopOsszegek)
for (const element of oszlopOsszegek) {
    console.log(element)
}

// C
let foAtloOsszeg = 0
let mellekAtloOsszeg = 0
for (let i = 0; i < matrix.length; i++) {
    foAtloOsszeg += matrix[i][i]
    mellekAtloOsszeg += matrix[i][(matrix.length-1)-i]
}

console.log("Átló")
console.log(foAtloOsszeg)
console.log(mellekAtloOsszeg)