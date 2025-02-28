import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../context/UserContext";
import "./Quiz.css";

const Quiz = () => {
  const [questions, setQuestions] = useState([]);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [userAnswer, setUserAnswer] = useState(null);
  const [isQuizComplete, setIsQuizComplete] = useState(false);
  const navigate = useNavigate();
  const { loggedInUser, setLoggedInUser } = useContext(UserContext);
  const [score, setScore] = useState(0);
  const [marks] = useState(Number(localStorage.getItem("selectedQuizMarks")));
  const [qmarks, setqmarks] = useState(0);
  const [buttonText, setbuttonText] = useState("Next");

  useEffect(() => {
    const quizId = localStorage.getItem("selectedQuizId");

    if (!quizId) {
      alert("No Quiz Selected");
      navigate("/home");
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
      marks: score + Number(loggedInUser.marks),
    };

    try {
      const response = await fetch(`http://127.0.0.1:8000/api/users/${userId}`, {
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
        setScore(score + qmarks);
        console.log(score);
      }

      if (currentQuestionIndex + 1 < questions.length) {
        if(currentQuestionIndex == questions.length-2){
          setbuttonText("Finish Attempt");
        }
        setCurrentQuestionIndex(currentQuestionIndex + 1);
        setUserAnswer(null);
      } 
      else {
        setIsQuizComplete(true);
      }
    } else {
      alert("Please select an answer!");
    }
  };

  useEffect(() => {
    const qunmber = questions.length;
    setqmarks(marks/qunmber);
    console.log(qunmber);
    console.log(qmarks);
  }, [questions]);

  useEffect(() => {
    if (isQuizComplete) {
      setLoggedInUser({ ...loggedInUser, marks: score + Number(loggedInUser.marks)});
      updateUserMarks(loggedInUser.id);
    }
  }, [isQuizComplete]);

  if (isQuizComplete) {
    return (
      <div className="complete-box">
        <h1>Quiz Completed</h1>
        <p>Your Total Marks: {(score)} / {marks}</p>
        <button onClick={() => navigate("/home")}>Back to Home</button>
      </div>
    );
  }

  const currentQuestion = questions[currentQuestionIndex];

  return (
    <div className="q-container">
      <div className="q-container2">
        <p>Quiz marks : {marks}</p>
        <p>Quetion count : {questions.length}</p>
      </div>
      {questions.length > 0 ? (
        <div className="q-box-quiz">
          <h3 className="q-quiz-text">{currentQuestion.question_text}</h3>
          <div className="q-quiz-answers">
            {["A", "B", "C", "D"].map((option) => (
              <div key={option} style={{ margin: "10px" }} className="q-quiz-answer2">
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
        </div>

        
      ) : (
        <p>Loading Questions...</p>
      )}
      <button className="nextquiz-button" onClick={handleNextQuestion}>{buttonText}</button>
    </div>
  );
};

export default Quiz;
