import React, { useState } from "react";


function Ex06_07(props) {

    const [test] = useState([
        {
            id: 1,
            question: "Question 1",
            answers: [
                "Answer 1",
                "Answer 2",
                "Answer 3",
                "Answer 4",
                "Answer 5",
            ],
            right: 4,
        },
        {
            id: 2,
            question: "Question 2",
            answers: [
                "Answer 1",
                "Answer 2",
                "Answer 3",
                "Answer 4",
                "Answer 5",
            ],
            right: 3,
        },
        {
            id: 3,
            question: "Question 3",
            answers: [
                "Answer 1",
                "Answer 2",
                "Answer 3",
                "Answer 4",
                "Answer 5",
            ],
            right: 1,
        },
    ]);

    const checkAnswer = (target, right, idQuestion, answerId) => {
        let obj = document.getElementById(idQuestion);

        if (answerId === right)
            obj.style.background = "green";
        else
            obj.style.background = "red";
    }

    const temp = test.map(task =>
            <div style={{ border: "2px solid gray", margin: "12px", padding: "12px" }} >
                <h2 id={ task.id }>{ task.question }</h2>
                <ul style={{ listStyle: "none" }}>
                    {
                        task.answers.map(answer =>
                            <li key={ task.id + answer }>
                                <label style={{ cursor: "pointer" }}>
                                    <input type="radio" name={task.question} value={ answer }
                                        onClick={ (event) => checkAnswer(
                                                event.target,
                                                task.right,
                                                task.id,
                                                task.answers.indexOf(answer)
                                            ) }
                                    />
                                    <span>{ answer }</span>
                                </label>
                            </li>
                        )
                    }
                </ul>
            </div>
        );

    return (
        <div>
            { temp }
        </div>
    );
}


export default Ex06_07;