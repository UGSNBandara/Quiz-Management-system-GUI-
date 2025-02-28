import { useState } from 'react'
import {Routes, Route} from 'react-router-dom'
import Home from './pages/Home/Home.jsx'
import Profile from './pages/Profile/Profile.jsx'
import Start from './pages/Start/Start.jsx'
import Login from './pages/Login/Login.jsx'
import Signin from './pages/Signin/Signin.jsx'
import Quiz from './pages/Quiz/Quiz.jsx'
import Leadboard from './pages/Leadboard/Leadboard.jsx'
import Addquiz from './pages/AddQuiz/Addquiz.jsx'

function App() {

  return (
      <div>
          <Routes>
            <Route index element={<Start/>}/>
            <Route path='/home' element={<Home/>}/>
            <Route path='/profile' element={<Profile/>}/>
            <Route path='/login' element={<Login/>}/>
            <Route path='/signin' element={<Signin/>}/>
            <Route path='/quiz' element={<Quiz/>}/>
            <Route path='/leadboard' element={<Leadboard/>}/>
            <Route path='/addquiz' element={<Addquiz/>}/>
            
          </Routes>
      </div>
  )
}

export default App
