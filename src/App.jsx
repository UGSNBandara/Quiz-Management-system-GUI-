import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Pages/Home/Home";
import Leadboard from "./components/Pages/LeadBoard/Leadboard";
import Login from "./components/Pages/Login/Login";


const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/Quiz-Management-system-GUI-/" element={<Home />} />
        <Route path="/Quiz-Management-system-GUI-/leadboard" element={<Leadboard />} />
        <Route path="/Quiz-Management-system-GUI-/login" element={<Login/>} />
        {/* 
        <Route path="/My-Portfolio/experiences" element={<ExperiencesPage />} /> */}
      </Routes>
    </BrowserRouter>
  );
};

export default App;
