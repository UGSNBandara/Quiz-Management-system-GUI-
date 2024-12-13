import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
    return (
      <div>
          <h1>Hello this is Home</h1>
        <Link to="/Quiz-Management-system-GUI-/leadboard">
          <button>Lead Board</button>
        </Link>
        <Link to="/Quiz-Management-system-GUI-/login">
          <button>Login</button>
        </Link>
      </div>
  
    );
  };
  
export default Home;
  