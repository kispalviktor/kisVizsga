function szamol(){

    let szelesseg = document.getElementById("szelesseg").value
    let magassag = document.getElementById("magassag").value

    let magassagErtek = document.getElementById("magassag_ertek")
    let teruletListaelem = document.getElementById("terulet")

    const teruletEredmeny = szelesseg * magassag
    magassagErtek.innerText = `A magasság értéke: ${magassag}`
    teruletListaelem.innerText = `A területe értéke: ${teruletEredmeny}`
    
}