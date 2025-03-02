import React from "react";
import { useState, useContext, useEffect } from "react";
import { UserContext } from "../../context/UserContext";
import "./Addquiz.css";

const Addquiz = () => {
    const [quizs, setQuizs] = useState([]);
    const [isAddQuiz, setIsAddQuiz] = useState(false);
    const [title, setTitle] = useState();
    const [marks, setMarks] = useState();
    const [message, setMessage] = useState();

    useEffect(() => {
        fetchquiz();
    }, [isAddQuiz]);

    const fetchquiz = async () => {
        try{
            const respone = await fetch("http://127.0.0.1:8000/api/quiz/");
            const data = await respone.json();
            console.log("Got the data");
            setQuizs(data);
        }
        catch (err){
            console.log(err);
        }
    }

    const navigateToQuiz = (quizID) => {
        console.log(quizID);
    }

    const addQuizToDB = async () => {
        if(!title.trim()){
            setMessage("Title Cannot Be Empty");
            return;
        }

        if(!marks.trim()){
            setMessage("Marks Cannot Be Empty");
            return;
        }

        const quizData = {
            name:title,
            total_marks:marks,
        }

        try{
            const responese = await fetch("http://127.0.0.1:8000/api/addquiz/", 
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(quizData),
                }
            );

            const data = await responese.json();
            setMessage("Successfully Added");
            setIsAddQuiz(false);

        }
        catch(err){
            console.log(err);
            setMessage("Something Went Wrong");
        }
    }

    const addquiz = (inb) => {
        setMessage("");
        setIsAddQuiz(true);
    } 

    if(isAddQuiz){
        return(
            <div className="main-container">
            <h1 className="heading">Add Question</h1>
      
            <dir className="container">
            <input id="box1" type="text" placeholder='Title' onChange={(e) => setTitle(e.target.value)} />
            <input id="box2" type="text" placeholder='Marks' onChange={(e) => setMarks(e.target.value)} />
            <button onClick={addQuizToDB} className="signinbutton">Add</button>
      
            <br /><hr />
            {message && <p className="error-massage">{message}</p>}
            </dir>
          </div>
        );
    }

    return (
        <div className="body2">
        <div className="quiz-grid">
          {quizs.map((quiz) => (
            <div
              className="quiz-box"
              key={quiz.id}
            >
              <div className="quiz-image">
              </div>
              <h3>{quiz.name}</h3>
              <p>Total Marks : {quiz.total_marks}</p>
              <button onClick={() => navigateToQuiz(quiz.id)}>
                Add Question
              </button>
            </div>
          ))}
          <div className="quiz-box-add">
            <button onClick={() => addquiz(10)} className="add-quiz-button">
            </button>
          </div>
        </div>
      </div>
    );

};

export default Addquiz;