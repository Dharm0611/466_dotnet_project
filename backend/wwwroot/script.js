const apiBase = "/api";

let questions = [];
let current = 0;
let timeLeft = 15;
let timerId;
let answers = [];
let username = "";

document.getElementById("startBtn").addEventListener("click", async () => {
  username = document.getElementById("username").value.trim() || "Anonymous";
  await loadQuestions();
  document.getElementById("login").classList.add("hidden");
  document.getElementById("quiz").classList.remove("hidden");
  showQuestion();
  startTimer();
});

async function loadQuestions() {
  try {
    const res = await fetch(apiBase + "/quiz/take?limit=10");
    if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
    questions = await res.json();
    if (!questions || questions.length === 0) {
      throw new Error('No questions available');
    }
  } catch (error) {
    console.error('Error loading questions:', error);
    alert('Failed to load questions. Please make sure the backend server is running.');
    throw error;
  }
}

function showQuestion() {
  const q = questions[current];
  const area = document.getElementById("questionArea");
  
  // Update progress
  const progress = ((current + 1) / questions.length) * 100;
  const progressBar = document.getElementById("progressBar");
  progressBar.style.setProperty('--progress', progress + '%');
  document.getElementById("progressText").textContent = `Question ${current + 1} of ${questions.length}`;
  
  area.innerHTML = `<div class="question"><strong>Q${current+1}.</strong> ${q.text}</div>
  <div class="options">
    <label><input type="radio" name="opt" value="A"> A) ${q.optionA}</label>
    <label><input type="radio" name="opt" value="B"> B) ${q.optionB}</label>
    <label><input type="radio" name="opt" value="C"> C) ${q.optionC}</label>
    <label><input type="radio" name="opt" value="D"> D) ${q.optionD}</label>
  </div>`;
}

document.getElementById("nextBtn").addEventListener("click", () => {
  submitAnswerAndNext();
});

function submitAnswerAndNext() {
  const selected = document.querySelector('input[name="opt"]:checked');
  const sel = selected ? selected.value : "";
  answers.push({ questionId: questions[current].id, selectedOption: sel, userName: username });
  current++;
  if (current >= questions.length) finishQuiz();
  else showQuestion();
  resetTimer();
}

function startTimer() {
  timeLeft = 15;
  document.getElementById("time").textContent = timeLeft;
  timerId = setInterval(() => {
    timeLeft--;
    document.getElementById("time").textContent = timeLeft;
    if (timeLeft <= 0) {
      submitAnswerAndNext();
    }
  }, 1000);
}

function resetTimer() {
  clearInterval(timerId);
  startTimer();
}

async function finishQuiz() {
  clearInterval(timerId);
  document.getElementById("quiz").classList.add("hidden");
  
  try {
    const res = await fetch(apiBase + "/quiz/submit", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(answers)
    });
    
    if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
    const r = await res.json();
    
    document.getElementById("result").classList.remove("hidden");
    const percentage = Math.round((r.score / questions.length) * 100);
    let message = `🎉 Congratulations, ${username}!<br>Your Score: ${r.score}/${questions.length} (${percentage}%)`;
    
    if (percentage >= 80) message += "<br>🏆 Excellent work!";
    else if (percentage >= 60) message += "<br>👍 Good job!";
    else message += "<br>📚 Keep studying!";
    
    document.getElementById("result").innerHTML = `<h3>${message}</h3>`;
    await loadLeaderboard();
  } catch (error) {
    console.error('Error submitting quiz:', error);
    document.getElementById("result").classList.remove("hidden");
    document.getElementById("result").innerHTML = `<h3>❌ Error submitting quiz. Please try again.</h3>`;
  }
}

async function loadLeaderboard() {
  try {
    const res = await fetch(apiBase + "/leaderboard");
    if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
    const list = await res.json();
    const ol = document.getElementById("leaderboard");
    ol.innerHTML = "";
    
    if (list.length === 0) {
      ol.innerHTML = "<li>No scores yet. Be the first to take the quiz!</li>";
      return;
    }
    
    list.forEach((item, index) => {
      const li = document.createElement("li");
      const medal = index === 0 ? "🥇" : index === 1 ? "🥈" : index === 2 ? "🥉" : "🏅";
      const date = new Date(item.takenAt).toLocaleDateString();
      li.textContent = `${medal} ${item.userName} — ${item.score} points (${date})`;
      ol.appendChild(li);
    });
  } catch (error) {
    console.error('Error loading leaderboard:', error);
    const ol = document.getElementById("leaderboard");
    ol.innerHTML = "<li>❌ Failed to load leaderboard</li>";
  }
}
