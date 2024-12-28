import React from "react";
import { Link } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from "../../context/UserContext";


const Home = () => {
  const { loggedInUser } = useContext(UserContext);

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
    </div>
  );
};

export default Home;
