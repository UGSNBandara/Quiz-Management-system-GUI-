import React from "react";
import { Link } from "react-router-dom";
import './Start.css';
import timer from "../../assets/timer.png";


const Start = () => {
  return (
    <div>
      <img src={timer} className="animated-image1" />
    <div className="main">
      <h1>Welcome to Quizify</h1>


      <div className="button-bar">
      <Link to="/login">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Login</button>
      </Link>
      <Link to="/signin">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Signin</button>
      </Link>
      </div>

      <p>@All Right Reserved by Sulitha Nulaksha</p>
    </div>
    </div>
  );
};

export default Start;