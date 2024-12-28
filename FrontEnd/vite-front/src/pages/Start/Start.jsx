import React from "react";
import { Link } from "react-router-dom";


const Start = () => {
  return (
    <div>
      <h1>Welcome to My Vite + React App</h1>
      <p>This is the Start page of a simple React application.</p>

      <Link to="/home">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Home</button>
      </Link>
      <Link to="/profile">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Profile</button>
      </Link>
      <Link to="/login">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Login</button>
      </Link>
      <Link to="/signin">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Signin</button>
      </Link>
    </div>
  );
};

export default Start;