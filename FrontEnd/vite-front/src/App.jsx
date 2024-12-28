import { useState } from 'react'
import {Routes, Route} from 'react-router-dom'
import Home from './pages/Home/Home.jsx'
import Profile from './pages/Profile/Profile.jsx'
import Start from './pages/Start/Start.jsx'
import Login from './pages/Login/Login.jsx'
import Signin from './pages/Signin/Signin.jsx'


function App() {

  return (
      <div>
          <Routes>
            <Route index element={<Start/>}/>
            <Route path='/home' element={<Home/>}/>
            <Route path='/profile' element={<Profile/>}/>
            <Route path='/login' element={<Login/>}/>
            <Route path='/signin' element={<Signin/>}/>
          </Routes>
      </div>
  )
}

export default App
