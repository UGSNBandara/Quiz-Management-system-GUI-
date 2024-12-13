import React from "react";
import { Link } from "react-router-dom";

const Login = () => {
    return (
      <div>
          <h1>Hello this is Login</h1>
          <Link to="/Quiz-Management-system-GUI-/">
            <button>Back</button>
          </Link>
      </div>
  
    );
  };
  
export default Login;