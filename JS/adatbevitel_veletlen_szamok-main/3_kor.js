//  Írj programot, ami beolvassa egy kör sugarát, 
//  majd kiírja a területét és a kerületét!

let sugar = Number(prompt("Kérlek add a mega  kör sugarát!", 0));
const pi = Math.PI;

let kerulet = 2 * sugar * pi
let terulet = sugar * sugar * pi

console.log(`A kör kerülete: ${kerulet}`)
console.log(`A kör területe: ${terulet}`)