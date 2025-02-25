import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useEffect, useState, useContext } from 'react';
import { UserContext } from "../../context/UserContext";
import './Leadboard.css';

const Leadboard = () => {

    const [users, setUsers] = useState([]);
    const navigate = useNavigate();
    const { loggedInUser } = useContext(UserContext);
    const [selectedUser, setSelectedUser] = useState(loggedInUser);
    const [selectedID, setSelectedID] = useState(loggedInUser.id);

    useEffect(() => {
        fetchUsers();
    }, []);

    const fetchUsers = async () => {
        try {
            const response = await fetch("http://127.0.0.1:8000/api/users/");
            const data = await response.json();
            console.log("Done");
            const sortedUsers = data.sort((a, b) => b.marks - a.marks);
            setUsers(sortedUsers);
        }
        catch (err) {
            console.log(err);
        }
    }

    const updateLeadProfile = async (currentuser) =>{
        setSelectedUser(currentuser);
        setSelectedID(currentuser.id);
        console.log("Set the user");
    }
    /*
        const SortArray = async () => {
            const sortedUser = [...users].sort((a, b) => b.marks - a.marks);
            setUsers(sortedUser);
            console.log("Sorted users");
        }
    */
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
                    <Link to="/profile">
                        <button style={{ padding: '10px 20px', margin: '10px' }}>Profile</button>
                    </Link>
                    <Link to="/">
                        <button style={{ padding: '10px 20px', margin: '10px' }}>Logout</button>
                    </Link>
                </div>
            </div>
            <div className="leadboardbody">
                <div className="leadboard">
                    <div className="leadboardBox-head">
                        <p>Rank</p> <p>Username</p> <p>Score</p>
                    </div>
                    {users.map((user, index) => (
                        <div 
                        className= {`leadboardBox ${selectedID === user.id ? 'active' : '' }`}
                        key={user.id} 
                        onClick={() => updateLeadProfile(user)}
                        >
                            <p>{index + 1}</p> <p>{user.username}</p> <p>{user.marks}</p>

                        </div>
                    ))}
                </div>

                <div className="relevent-profile">
                    <div className="userdetails">
                        <div id="selectedtopic" className="onelinedetail">
                            <div className="text3">
                                Selected User
                            </div>
                        </div>
                        <div className="onelinedetail">
                            <div className="text1">
                                Userame
                            </div>
                            <div className="text2">
                                {selectedUser?.username}
                            </div>
                        </div>

                        <div className="onelinedetail">
                            <div className="text1">
                                Full Name
                            </div>
                            <div className="text2">
                                {selectedUser?.full_name}
                            </div>
                        </div>

                        <div className="onelinedetail">
                            <div className="text1">
                                Marks
                            </div>
                            <div className="text2">
                                {selectedUser?.marks}
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
};


export default Leadboard; 