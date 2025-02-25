import React from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../../context/UserContext";
import { useContext, useState } from 'react';
import "./Profile.css";

const Profile = () => {
  const { loggedInUser, setLoggedInUser } = useContext(UserContext);
  const [username, setUsername] = useState(loggedInUser?.username);
  const [email, setEmail] = useState(loggedInUser?.email);
  const [name, setName] = useState(loggedInUser?.full_name);
  const [password, setPassword] = useState(loggedInUser?.password);
  const [isVisible, setIsVisible] = useState(false);


  const closeUpdatePanel = async => {
    setIsVisible(false);
  }

  const openUpdatePanel = async => {
    setIsVisible(true);
  }

  const updateUser = async (pk) => {
    const userData = {
      username, //when having tha same name for both
      full_name: name,
      password,
      email,
      marks: loggedInUser?.marks,
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

      if (data) {
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
    <div className="body1">

      <div className="nav-bar">
        <div className="text-navbar">
          Hello {loggedInUser.username}
        </div>
        <div className="buttons">
          <Link to="/home">
            <button style={{ padding: '10px 20px', margin: '10px' }}>Home</button>
          </Link>
          <Link to="/leadboard">
            <button style={{ padding: '10px 20px', margin: '10px' }}>LeadBoard</button>
          </Link>
          <Link to="/">
            <button style={{ padding: '10px 20px', margin: '10px' }}>Logout</button>
          </Link>
        </div>
      </div>


      <div className="body2-profile">

        <div className="profile-container">
          <div className="updatetext">
            User Details
          </div>

          <div className="warningtextupdate">
            Hello {loggedInUser.username} lets have a Quiz
          </div>

          <div className="userdetails">
            <div className="onelinedetail">
              <div className="text1">
                User Name
              </div>
              <div className="text2">
                {loggedInUser?.username}
              </div>
            </div>

            <div className="onelinedetail">
              <div className="text1">
                Full Name
              </div>
              <div className="text2">
                {loggedInUser?.full_name}
              </div>
            </div>

            <div className="onelinedetail">
              <div className="text1">
                Email
              </div>
              <div className="text2">
                {loggedInUser?.email}
              </div>
            </div>

            <div className="onelinedetail">
              <div className="text1">
                Marks
              </div>
              <div className="text2">
                {loggedInUser?.marks}
              </div>
            </div>
          </div>

          <div className="buttonprofile">
              <button onClick={() => openUpdatePanel()}>Update</button>
          </div>

        </div>

        {isVisible && (
        <div className="update-container">
          <div className="updatetext">
            Update Box
          </div>

          <div className="warningtextupdate">
            Update only the relevent details
          </div>

          <div className="boxes">
            <input id="box5" type="text" placeholder='Username' onChange={(e) => setUsername(e.target.value)} />
            <input id="box6" type="text" placeholder='Email' onChange={(e) => setEmail(e.target.value)} />
            <input id="box7" type="text" placeholder='Name' onChange={(e) => setName(e.target.value)} />
            <input id="box8" type="text" placeholder='password' onChange={(e) => setPassword(e.target.value)} />
          </div>
          <div className="warningtextupdate">
            Enter the current password
          </div>
          <input id="box8" type="text" placeholder='current password' onChange={(e) => setPassword(e.target.value)} />

          <div className="updatebutton">
            <button onClick={() => updateUser(loggedInUser?.id)}>Update</button>
            <button onClick={() => closeUpdatePanel()}>Cancle</button>
          </div>
        </div>)}
      </div>
    </div>
  );
};

export default Profile;