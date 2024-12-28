import { Link } from "react-router-dom";
import React from "react";
import { useEffect, useState } from 'react';


const Signin = () => {
  const [users , setUsers] = useState([])
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [name, setName] = useState("");
  const [message, setMessage] = useState(""); 


  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
    try {
      const response = await fetch("http://127.0.0.1:8000/api/users/");
      const data = await response.json();
      console.log(data);
      setUsers(data);
    }
    catch (err) {
      console.log(err);
    }
  }

  const isUserEmailExists = () => {
    return users.some((user) => user.email === email);
  };

  const isUsernameExists = () => {
    return users.some((user) => user.username === username);
  };

  const addUser = async () => {

    if (isUserEmailExists()) {
      setMessage("Error: Email already exists!");
      return;
    }

    if (isUsernameExists()){
      setMessage("Error: Username already exists!")
      return;
    }

    const userData = {
      username, 
      email,
      full_name :name, 
      password,
      marks: 0,
    };

    try {
      const response = await fetch("http://127.0.0.1:8000/api/addusers/", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
      });

      const data = await response.json();
      console.log(data);
      setMessage("Successfully registered");
      document.getElementById("box1").value = "";
      document.getElementById("box2").value = "";
      document.getElementById("box3").value = "";
      document.getElementById("box4").value = "";
    }

    catch (err) {
      console.log(err);
      setMessage("Error: Something went wrong!")
    }

  }


  return (
    <div>
      <h1>Welcome to My Vite + React App</h1>

      <br />
      <br />
      <Link to="/home">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Home</button>
      </Link>
      <Link to="/">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Start</button>
      </Link>

      <br />
      <hr />

      <input id="box1" type="text" placeholder='Username' onChange={(e) => setUsername(e.target.value)} />
      <input id="box2" type="text" placeholder='Email' onChange={(e) => setEmail(e.target.value)} />
      <input id="box3" type="text" placeholder='Name' onChange={(e) => setName(e.target.value)} />
      <input id="box4" type="text" placeholder='password' onChange={(e) => setPassword(e.target.value)} />
      <button onClick={addUser}>Sign IN</button>

      <br /><hr />
      {message && <p>{message}</p>}
    </div>
  );
};

export default Signin;
