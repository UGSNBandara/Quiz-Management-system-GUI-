import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useContext, useEffect, useState } from 'react';
import { UserContext } from "../../context/UserContext";
import "./Home.css"


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
    <div className="body1">
      <div className="nav-bar">
        <div className="text-navbar">
          Hello {loggedInUser.username}
        </div>

        <div className="buttons">
          <Link to="/profile">
            <button style={{ padding: '10px 20px', margin: '10px' }}>Profile</button>
          </Link>
          <Link to="/leadboard">
            <button style={{ padding: '10px 20px', margin: '10px' }}>LeadBoard</button>
          </Link>
          <Link to="/">
            <button style={{ padding: '10px 20px', margin: '10px' }}>Logout</button>
          </Link>
        </div>
      </div>


      <div className="body2">
        <div className="addsection1">
          Eat Like You Mean it!!
        </div>
        <div className="quiz-grid">
          {quizzes.map((quiz) => (
            <div
              className="quiz-box"
              key={quiz.id}
            >
              <div className="quiz-image">
              </div>
              <h3>{quiz.name}</h3>
              <p>Total Marks : {quiz.total_marks}</p>
              <button onClick={() => navigateToQuiz(quiz.id)}>
                Start Quiz
              </button>
            </div>
          ))}
        </div>
        <div className="addsection2">
          Eat Like You Mean it!!
        </div>
      </div>
    </div>
  );
};

export default Home;
