function evaluateQuiz() {
    let score = 0;
    let total = 10;
    const form = document.forms["quizForm"];

    function mark(id, correct) {
        const box = document.getElementById(id);
        box.classList.remove("correct","wrong");
        box.classList.add(correct ? "correct" : "wrong");
    }

    let q1 = document.querySelector('input[name="q1"]:checked');
    if (q1 && q1.value == "1") { 
        score++; mark("q1box", true); 
    }
    else mark("q1box", false);

    let q2 = form.querySelectorAll('input[name="q2"]:checked');
    let correct2 = [...q2].every(cb => cb.value=="1") && q2.length==2;
    if (correct2) score++;
    mark("q2box", correct2);

    if (form.q3.value=="1") { 
        score++; mark("q3box", true); 
    }
    else mark("q3box", false);

    if (form.q4.value=="6") { 
        score++; mark("q4box", true); 
    }
    else mark("q4box", false);

    let ans5 = form.q5.value.toLowerCase();
    if (ans5.includes("zongora") || ans5.includes("piano")) {
        score++; mark("q5box", true);
    } else mark("q5box", false);

    let q6 = document.querySelector('input[name="q6"]:checked');
    if (q6 && q6.value=="1") { 
        score++; mark("q6box", true); 
    }
    else mark("q6box", false);

    let q7 = form.querySelectorAll('input[name="q7"]:checked');
    let correct7 = [...q7].every(cb => cb.value=="1") && q7.length==2;
    if (correct7) score++;
    mark("q7box", correct7);

    if (form.q8.value=="1") { score++; mark("q8box", true); }
    else mark("q8box", false);

    if (form.q9.value=="7") { score++; mark("q9box", true); }
    else mark("q9box", false);

    let q10 = document.querySelector('input[name="q10"]:checked');
    if (q10 && q10.value=="1") { 
        score++; mark("q10box", true); 
    }
    else mark("q10box", false);

    document.getElementById("result").innerHTML = 
        "Pontszám: " + score + " / " + total;
}