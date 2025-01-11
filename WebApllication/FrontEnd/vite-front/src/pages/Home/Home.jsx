import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useContext, useEffect, useState } from 'react';
import { UserContext } from "../../context/UserContext";


const Home = () => {
  const { loggedInUser } = useContext(UserContext);
  const [quizzes, setQuizzes] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchQuizzes();
  }, []);

  const fetchQuizzes = async () => {
    try {
      const response = await fetch("http://127.0.0.1:8000/api/quiz/");
      const data = await response.json();
      setQuizzes(data);
    }
    catch (err) {
      console.log(err);
    }
  }

  const navigateToQuiz = (quizId) => {
    localStorage.setItem("selectedQuizId", quizId);

    navigate('/quiz');
  };



  return (
    <div>
      <h1>Welcome {loggedInUser?.username}  to My Vite + React App</h1>
      <p>This is the home page of a simple React application.</p>
      <Link to="/profile">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Profile</button>
      </Link>
      <Link to="/">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Start</button>
      </Link>

      <div style={{ display: "grid", gridTemplateColumns: "repeat(2, 1fr)", gap: "10px" }}>
        {quizzes.map((quiz) => (
          <div
            key={quiz.id}
            style={{
              border: "1px solid #ccc",
              borderRadius: "8px",
              padding: "10px",
              textAlign: "center",
            }}
          >
            <h3>{quiz.name}</h3>
            <p>{quiz.total_marks}</p>
            <button onClick={() => navigateToQuiz(quiz.id)}>
              Start Quiz
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
