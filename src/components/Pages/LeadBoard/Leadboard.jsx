import React from "react";
import { Link } from "react-router-dom";

const Leadboard = () => {
    return (
        <div>
            <h1>This is the LeadBoard</h1>
            <Link to="/Quiz-Management-system-GUI-/">
                <button>Back</button>
            </Link>
        </div>

    )
};

export default Leadboard;