import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../context/UserContext";

const Quiz = () => {
  const [questions, setQuestions] = useState([]);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [score, setScore] = useState(0);
  const [userAnswer, setUserAnswer] = useState(null);
  const [isQuizComplete, setIsQuizComplete] = useState(false);
  const navigate = useNavigate();
  const { loggedInUser, setLoggedInUser } = useContext(UserContext);

  useEffect(() => {
    const quizId = localStorage.getItem("selectedQuizId");

    if (!quizId) {
      alert("No Quiz Selected");
      navigate("/");
      return;
    }
    fetchQuestions(quizId);
  }, []);

  const fetchQuestions = async (quizId) => {
    try {
      const response = await fetch(`http://127.0.0.1:8000/api/q/?quiz_id=${quizId}`);
      const data = await response.json();
      setQuestions(data);
    } catch (err) {
      console.log(err);
    }
  };

  const updateUserMarks = async (userId) => {
    const userData = {
      username: loggedInUser.username,
      full_name: loggedInUser.full_name,
      password: loggedInUser.password,
      email: loggedInUser.email,
      marks: score,  // Use score to update marks
    };

    try {
      const response = await fetch(`http://127.0.0.1:8000/api/users/${userId}/`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
      });

      const data = await response.json();
      console.log("User updated:", data);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  const handleNextQuestion = () => {
    if (userAnswer) {
      if (userAnswer === questions[currentQuestionIndex].correct_answer) {
        setScore(score + 1);
      }

      if (currentQuestionIndex + 1 < questions.length) {
        setCurrentQuestionIndex(currentQuestionIndex + 1);
        setUserAnswer(null);
      } else {
        setIsQuizComplete(true);
      }
    } else {
      alert("Please select an answer!");
    }
  };

  useEffect(() => {
    if (isQuizComplete) {
      setLoggedInUser({ ...loggedInUser, marks: score }); // Set the new score in the context
      updateUserMarks(loggedInUser.id); // Update the marks in the database
    }
  }, [isQuizComplete]); // Run when isQuizComplete changes

  if (isQuizComplete) {
    return (
      <div style={{ textAlign: "center" }}>
        <h1>Quiz Completed</h1>
        <p>Your Total Marks: {score} / {questions.length}</p>
        <button onClick={() => navigate("/home")}>Back to Home</button>
      </div>
    );
  }

  const currentQuestion = questions[currentQuestionIndex];

  return (
    <div style={{ padding: "20px", textAlign: "center" }}>
      <h2>Quiz</h2>
      {questions.length > 0 ? (
        <div>
          <h3>{currentQuestion.question_text}</h3>
          <div>
            {["A", "B", "C", "D"].map((option) => (
              <div key={option} style={{ margin: "10px" }}>
                <label>
                  <input
                    type="radio"
                    name="option"
                    value={option}
                    checked={userAnswer === option}
                    onChange={(e) => setUserAnswer(e.target.value)}
                  />
                  {currentQuestion[`option_${option.toLowerCase()}`]}
                </label>
              </div>
            ))}
          </div>
          <button onClick={handleNextQuestion}>Next</button>
        </div>
      ) : (
        <p>Loading Questions...</p>
      )}
    </div>
  );
};

export default Quiz;
