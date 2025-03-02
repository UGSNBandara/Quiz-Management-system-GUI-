import React from "react";
import { useState, useContext, useEffect } from "react";
import { UserContext } from "../../context/UserContext";
import "./Addquiz.css";

const Addquiz = () => {
    const [quizs, setQuizs] = useState([]);
    const [isAddQuiz, setIsAddQuiz] = useState(false);
    const [addquizID, setAddquizID] = useState();
    const [title, setTitle] = useState();
    const [marks, setMarks] = useState();
    const [message, setMessage] = useState();

    const [question, setQuestion] = useState("");
    const [answer1, setAnswer1] = useState("");
    const [answer2, setAnswer2] = useState("");
    const [answer3, setAnswer3] = useState("");
    const [answer4, setAnswer4] = useState("");
    const [correctAnswer, setCorrectAnswer] = useState("");


    useEffect(() => {
        fetchquiz();
    }, [isAddQuiz]);

    const fetchquiz = async () => {
        try {
            const respone = await fetch("http://127.0.0.1:8000/api/quiz/");
            const data = await respone.json();
            console.log("Got the data");
            setQuizs(data);
        }
        catch (err) {
            console.log(err);
        }
    }

    const navigateToQuiz = (quizID) => {
        console.log(quizID);
        setAddquizID(quizID);
    }

    const addQuizToDB = async () => {
        if (!title.trim()) {
            setMessage("Title Cannot Be Empty");
            return;
        }

        if (!marks.trim()) {
            setMessage("Marks Cannot Be Empty");
            return;
        }

        const quizData = {
            name: title,
            total_marks: marks,
        }

        try {
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
        catch (err) {
            console.log(err);
            setMessage("Something Went Wrong");
        }
    }

    const DeleteQuizById = async (id) => {
        try {
            const response = await fetch(`http://127.0.0.1:8000/api/quiz/${id}`, {
                method: "DELETE",
            });

            const updatedquiz = quizs.filter(items => items.id != id);
            setQuizs(updatedquiz);
            console.log(response);
        }
        catch (err) {
            console.log(err);
        }
    }

    const addquiz = (inb) => {
        setMessage("");
        setIsAddQuiz(true);
    }



    if (isAddQuiz) {
        return (
            <div className="main-container">
                <h1 className="heading">Add Question</h1>

                <div className="container">
                    <input id="box1" type="text" placeholder='Title' onChange={(e) => setTitle(e.target.value)} />
                    <input id="box2" type="text" placeholder='Marks' onChange={(e) => setMarks(e.target.value)} />
                    <button onClick={addQuizToDB} className="signinbutton">Add</button>

                    <br /><hr />
                    {message && <p className="error-massage">{message}</p>}
                </div>
            </div>
        );
    }

    const addQuestionToDB = async () => {
        const newq = {
            quiz : addquizID,
            question_text : question,
            option_a : answer1,
            option_b : answer2,
            option_c : answer3,
            option_d : answer4,
            correct_answer : correctAnswer
        }

        try {
            const respone = await fetch("http://127.0.0.1:8000/api/addq/",{
                method : "POST",
                headers: {
                    "Content-Type" : "application/json",
                },
                body: JSON.stringify(newq),
            });

            const data = await respone.json();
            console.log(data);
        }
        catch(err){
            console.log(err);
        }

        console.log("Adde (test)");
        makeInputBoxClear();
    }

    const closeQuestionAdd = () => {
        setAddquizID(0);
        console.log("Close the quiz");
    }

    const makeInputBoxClear = () => {
        setQuestion("");
        setAnswer1("");
        setAnswer2("");
        setAnswer3("");
        setAnswer4("");
        setCorrectAnswer("");
    }

    if (addquizID) {
        return (
            <div className="main-container">
                <div className="container-addq">
                    <input
                        id="question-box"
                        type="text"
                        placeholder="Question"
                        value={question}
                        onChange={(e) => setQuestion(e.target.value)}
                    />
                    <input
                        id="answer1-box"
                        type="text"
                        value={answer1}
                        placeholder="Answer 1"
                        onChange={(e) => setAnswer1(e.target.value)}
                    />
                    <input
                        id="answer2-box"
                        type="text"
                        value={answer2}
                        placeholder="Answer 2"
                        onChange={(e) => setAnswer2(e.target.value)}
                    />
                    <input
                        id="answer3-box"
                        type="text"
                        value={answer3}
                        placeholder="Answer 3"
                        onChange={(e) => setAnswer3(e.target.value)}
                    />
                    <input
                        id="answer4-box"
                        type="text"
                        value={answer4}
                        placeholder="Answer 4"
                        onChange={(e) => setAnswer4(e.target.value)}
                    />
                    <select value={correctAnswer} id="correct-answer-selector" onChange={(e) => setCorrectAnswer(e.target.value)}>
                        <option value="">Select Correct Answer</option>
                        <option value="A">Answer 1</option>
                        <option value="B">Answer 2</option>
                        <option value="C">Answer 3</option>
                        <option value="D">Answer 4</option>
                    </select>

                    <div className="button-group">
                        <button className="addQuizButton" onClick={addQuestionToDB}>Add</button>
                        <button  className="cancelAddingButton" onClick={closeQuestionAdd}>Cancel</button>
                    </div>
                </div>
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
                        <button onClick={() => DeleteQuizById(quiz.id)}>
                            Delete
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