import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useEffect, useState, useContext } from 'react';
import { UserContext } from "../../context/UserContext";
import './Login.css';

const Login = () => {
  const [users , setUsers] = useState([]);
  const [password, setPassword] = useState("");
  const [username, setUsername] = useState("");
  const navigate = useNavigate();
  const [message, setMessage] = useState("");
  const { setLoggedInUser } = useContext(UserContext);

    useEffect(() => {
      fetchUsers();
    }, []);
  
    const fetchUsers = async () => {
      try {
        const response = await fetch("http://127.0.0.1:8000/api/users/");
        const data = await response.json();
        console.log("Done");
        setUsers(data);
      }
      catch (err) {
        console.log(err);
      }
    }

    const handleLogin = () => {
      const User = users.find(
        (user) => user.username === username && user.password === password
      );

      if(User){
        navigate('/home');
        setLoggedInUser(User);
        console.log("Successfully loged");
      }
      else{
        setMessage("Username or Password incorrect");

      }
    }

  return (
    <div className="main-container">
      <h1 className="heading">Login Quizify</h1>

      <div className="container">
      <input id="box1" type="text" placeholder='Username' onChange={(e) => setUsername(e.target.value)} />
      <input id="box2" type="text" placeholder='password' onChange={(e) => setPassword(e.target.value)} />

      <button className="loginbutton" onClick={handleLogin}>
        Login
      </button>
      {message && <p className="error-massage" >{message}</p>}

      </div>
    </div>
  );
};

export default Login;