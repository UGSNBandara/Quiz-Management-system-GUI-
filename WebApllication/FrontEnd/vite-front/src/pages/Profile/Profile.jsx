import React from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../../context/UserContext";
import { useContext, useState } from 'react';

const Profile = () => {
  const { loggedInUser, setLoggedInUser } = useContext(UserContext);
  const [ username , setUsername] = useState(loggedInUser?.username);
  const [ email, setEmail] = useState(loggedInUser?.email);
  const [ name, setName] = useState(loggedInUser?.full_name);
  const [ password, setPassword] = useState(loggedInUser?.password);


  

  const updateUser = async (pk) => {
    const userData = {
      username, //when having tha same name for both
      full_name : name,
      password,
      email,
      marks : loggedInUser?.marks,
    };

    try {
      const response = await fetch(`http://127.0.0.1:8000/api/users/${pk}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
      });

      const data = await response.json();
      console.log(data);

      if (data){
        setLoggedInUser({
          ...loggedInUser,
          username: data.username,
          email: data.email,
          full_name: data.full_name,
          password: data.password,
        });

        console.log("Changed the local data");

        localStorage.setItem("user", JSON.stringify(data));
      }
    }
    catch (err) {
      console.log(err);
    }

  };

  return (
    <div>
      <h1>Welcome to My Vite + React App</h1>
      <p>This is the Profile page of a simple React application.</p>

      <br />
      <p>User name : {loggedInUser?.username}</p>
      <p>full name : {loggedInUser?.full_name} </p>
      <p>Email : {loggedInUser?.email}</p>
      <p>Marks : {loggedInUser?.marks}</p>
      <br />
      <Link to="/home">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Home</button>
      </Link>
      <Link to="/">
        <button style={{ padding: '10px 20px', margin: '10px' }}>Go to Start</button>
      </Link>

      <br /><hr />
      <input id="box1" type="text" placeholder='Username' onChange={(e) => setUsername(e.target.value)} />
      <input id="box2" type="text" placeholder='Email' onChange={(e) => setEmail(e.target.value)} />
      <input id="box3" type="text" placeholder='Name' onChange={(e) => setName(e.target.value)} />
      <input id="box4" type="text" placeholder='password' onChange={(e) => setPassword(e.target.value)} />
      <button onClick={() => updateUser(loggedInUser?.id)}>Update</button>
    </div>
  );
};

export default Profile;