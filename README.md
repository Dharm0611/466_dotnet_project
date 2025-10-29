# 🎯 Online BGMI Quiz Platform

A modern, full-stack web application for taking online quizzes with real-time scoring and leaderboard functionality.

## ✨ Features

- 🎮 Interactive quiz interface with timer
- 📊 Real-time progress tracking
- 🏆 Dynamic leaderboard with rankings
- 📱 Responsive design for all devices
- 🎨 Modern, beautiful UI with animations
- 🔄 RESTful API architecture
- 💾 SQLite database with Entity Framework Core

## 🛠 Tech Stack

- **Backend**: ASP.NET Core 9.0 Web API
- **Frontend**: HTML5, CSS3, Vanilla JavaScript
- **Database**: SQLite with Entity Framework Core
- **Styling**: Modern CSS with gradients and animations

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- A modern web browser

### Running the Application

1. **Clone or download the project**

2. **Navigate to the backend directory:**
   ```bash
   cd backend
   ```

3. **Restore dependencies and build:**
   ```bash
   dotnet restore
   dotnet build
   ```

4. **Run the application:**
   ```bash
   dotnet run
   ```
   or you can use 
   ```
   dotnet run --urls "http://localhost:5001"
   ```
5. **Open your browser and navigate to:**
   ```
   http://localhost:5000/index.html
   ```

## 📡 API Endpoints

- `GET /api/questions` - Get all questions
- `GET /api/quiz/take?limit=10` - Get quiz questions (limit optional)
- `POST /api/quiz/submit` - Submit quiz answers
- `GET /api/leaderboard` - Get top scores leaderboard
- `GET /swagger` - API documentation (Swagger UI)

## 🗄 Database

The application uses SQLite with Entity Framework Core. The database file `quiz.db` will be created automatically when you run the application for the first time.


## 🎮 How to Use

1. **Enter your name** in the input field
2. **Click "Start Quiz"** to begin
3. **Answer each question** within the time limit (15 seconds)
4. **View your score** and see where you rank on the leaderboard
5. **Challenge others** to beat your score!

## 🏗 Project Structure

```
online_quiz_platform/
├── backend/
│   ├── Controllers/          # API controllers
│   ├── Models/              # Data models
│   ├── wwwroot/             # Static frontend files
│   ├── QuizDbContext.cs     # Database context
│   └── Program.cs           # Application entry point
├── frontend/                # Frontend source files
└── README.md               # This file
```

## 🎨 Features in Detail

### Quiz Interface
- Clean, intuitive design
- Progress bar showing quiz completion
- Timer for each question with automatic submission
- Multiple choice questions with clear options

### Scoring System
- Real-time score calculation
- Percentage-based scoring
- Encouraging messages based on performance
- Persistent score storage

### Leaderboard
- Top 10 scores displayed
- Medal system (🥇🥈🥉) for top performers
- Date tracking for quiz attempts
- Real-time updates

## 🔧 Development

### Adding New Questions

You can add questions directly to the database or through the API:

```bash
curl -X POST "http://localhost:5000/api/questions" \
  -H "Content-Type: application/json" \
  -d '{
    "text": "Your question here?",
    "optionA": "Option A",
    "optionB": "Option B", 
    "optionC": "Option C",
    "optionD": "Option D",
    "correctOption": "A",
    "marks": 1
  }'
```

### Customization

- Modify the timer duration in `script.js`
- Adjust the number of questions in the quiz
- Customize the styling in `styles.css`
- Add new question categories

## 🐛 Troubleshooting

**Backend won't start?**
- Ensure .NET 9.0 SDK is installed
- Check if port 5000 is available
- Run `dotnet restore` to restore packages

**Frontend not loading?**
- Make sure the backend is running
- Check browser console for errors
- Verify the static files are in `backend/wwwroot/`

**Database issues?**
- Delete `quiz.db` and restart the application
- Run `dotnet ef database update` to recreate the database

## 📄 License

This project is open source and available under the MIT License.

## 🤝 Contributing

Feel free to submit issues, feature requests, and pull requests!

---

**Happy Quizzing! 🎉**