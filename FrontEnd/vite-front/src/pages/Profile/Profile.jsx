import React from "react";
import { Link } from "react-router-dom";

const Profile = () => {
  return (
    <div>
      <h1>Welcome to My Vite + React App</h1>
      <p>This is the Profile page of a simple React application.</p>
      <Link to="/home">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Home</button>
      </Link>
      <Link to="/">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Start</button>
      </Link>
    </div>
  );
};

export default Profile;