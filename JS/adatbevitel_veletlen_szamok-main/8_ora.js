// Írj programot, ami bekéri a dátumot (nap) és az órát, 
// amiből kiszámolja, hogy a hónap 
// hányadik órájában vagyunk!

// let honap = Number(prompt("Írja be a hónapot: "))
let nap = Number(prompt("Írja be a napot: "))
let ora = Number(prompt("Írja be a órát: "))

let napp = (((nap-1) * 24) + ora)

console.log(napp)