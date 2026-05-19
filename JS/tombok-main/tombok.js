let t = [];

for (let i = 0; i < 100; i++) {
    t.push(Math.floor(Math.random() * 101) - 50);
}

let max = t[0];
let maxIndex = 0;

for (let i = 1; i < t.length; i++) {
    if (t[i] > max) {
        max = t[i];
        maxIndex = i;
    }
}
console.log("Max érték:", max, "Index:", maxIndex);

let sum = 0;
for (let x of t) sum += x;
console.log("Összeg:", sum);

let even = 0;
let odd = 0;

for (let x of t) {
    if (x % 2 === 0) even++;
    else odd++;
}

console.log("Páros:", even, "Páratlan:", odd);

let div7 = t.some(x => x % 7 === 0);
console.log("Van 7-tel osztható:", div7);

let neighNeg = false;
for (let i = 1; i < t.length - 1; i++) {
    if (t[i - 1] < 0 && t[i + 1] < 0) {
        neighNeg = true;
        break;
    }
}
console.log("Van két negatív szomszéd:", neighNeg);

let biggerThanNeighbours = false;
for (let i = 1; i < t.length - 1; i++) {
    if (t[i] > t[i - 1] + t[i + 1]) {
        biggerThanNeighbours = true;
        break;
    }
}
console.log("Van ilyen elem:", biggerThanNeighbours);

let index = -1;
for (let i = t.length - 1; i >= 0; i--) {
    if (t[i] % 3 === 0 && t[i] % 5 !== 0) {
        index = i;
        break;
    }
}
console.log("Utolsó ilyen index:", index);

let threeSame = false;

for (let i = 0; i < t.length; i++) {
    let count = 0;
    for (let j = 0; j < t.length; j++) {
        if (t[i] === t[j]) count++;
    }
    if (count >= 3) {
        threeSame = true;
        break;
    }
}
console.log("Van három egyforma szám:", threeSame);

let sameNeighbours = false;

for (let i = 0; i < t.length - 1; i++) {
    if (t[i] === t[i + 1]) {
        sameNeighbours = true;
        break;
    }
}
console.log("Van egymás melletti azonos:", sameNeighbours);

console.log("10 többszöröseinek indexei:");
for (let i = 0; i < t.length; i++) {
    if (t[i] % 10 === 0) {
        console.log(i);
    }
}

let avg = sum / t.length;
let belowAvg = 0;

for (let x of t) {
    if (x < avg) belowAvg++;
}

console.log("Átlag alatti számok:", belowAvg);