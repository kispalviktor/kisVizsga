// let url = window.location.href
let urlSearch = window.location.search

if(urlSearch.includes("?")){
    console.log(urlSearch);
    let kerdes = urlSearch.split("?")[1]
    // console.log("kerdes: ", kerdes)

    let kerdesParok = kerdes.split("&")
    console.log(kerdesParok);
    let fovaros = ""
    let vizeses = ""
    for (let i = 0; i < kerdesParok.length; i++) {
        console.log(kerdesParok[i])
        if (kerdesParok[i].startsWith("fovaros")){
            fovaros = kerdesParok[i].split("=")[1]
            
        } else if(kerdesParok[i].startsWith("vizeses")){
            vizeses = kerdesParok[i].split("=")[1]
            console.log("VÍZESÉS", vizeses);
        }
    }

    let latnivalo = []
    for (let i = 0; i < kerdesParok.length; i++){
        if (kerdesParok[i].startsWith("latnivalo")){
            latnivalo.push(kerdesParok[i].split("=")[1])
        } 
    }

    let vizesesEredmenye = document.getElementById("vizeses_eredmenye")
    if (vizeses == "Gullfoss") {
        vizesesEredmenye.innerHTML = `<p style='color: green; '>A választott vízesés (${vizeses}) a helyes válasz</p>`
    } else {
        vizesesEredmenye.innerHTML = `<p style='color: red; '>A választott vízesés (${vizeses}) a helytelen válasz</p>`
    }

    // console.log(kerdes)
    // console.log(fovaros)
    let felhasznaloBevitelEredmenye = document.getElementById("felhasznaloi_input")
    felhasznaloBevitelEredmenye.innerHTML = `
        <h3>A felhasznaló válasza</h3>
        <p>1. ${fovaros}</p>
        <p>2. ${vizeses}</p>
        <p>3. ${latnivalo.join(", ")}</p>`
}
