-- sqlite seed script for Math (easy) quiz
INSERT INTO Questions (Text, OptionA, OptionB, OptionC, OptionD, CorrectOption, Marks) VALUES
('What is 2 + 2?', '3', '4', '5', '6', 'B', 1),
('What is 9 - 3?', '5', '6', '7', '8', 'B', 1),
('What is 3 × 4?', '7', '10', '12', '14', 'C', 1),
('What is 12 ÷ 3?', '2', '3', '4', '5', 'C', 1),
('What is 5²?', '10', '20', '25', '30', 'C', 1),
('What is the square root of 81?', '7', '8', '9', '10', 'C', 1),
('What is 15% of 200?', '20', '25', '30', '35', 'C', 1),
('Solve: 2x = 14, x = ?', '5', '6', '7', '8', 'C', 1),
('What is 7 + 8?', '14', '15', '16', '17', 'B', 1),
('What is 1000 ÷ 10?', '10', '50', '100', '200', 'C', 1);
