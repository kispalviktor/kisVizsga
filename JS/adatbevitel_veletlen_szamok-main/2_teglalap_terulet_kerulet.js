// 2. Olvasd be egy téglalap két oldalának hosszát, 
//  majd írasd ki a kerületét és a területét!

let teglalap_a = Number(prompt("Kérlek add meg az 'a' oldalát a téglalapnak", 0))
let teglalap_b = Number(prompt("Kérlek add meg az 'b' oldalát a téglalapnak", 0))

let kerulet = 2*(teglalap_a+teglalap_b)
console.log(`A téglalap kerülete: ${kerulet}`)

let terulet = teglalap_a * teglalap_b
console.log(`A téglalap területe: ${terulet}`)