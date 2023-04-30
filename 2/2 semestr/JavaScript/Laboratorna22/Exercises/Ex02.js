import React, { useState } from "react";

function Ex02(props) {
    const [emp, setEmployee] = useState([
        { id: 1, name: "Ivan", surname: "Ivanyuk", salary: 1280, sex: "male" },
        { id: 2, name: "Oksana", surname: "Petrenko", salary: 2930, sex: "female" },
        { id: 3, name: "Stepan", surname: "Aboba", salary: 1810, sex: "male" },
        { id: 4, name: "Kateryna", surname: "Borsch", salary: 1330, sex: "female" },
        { id: 5, name: "Kolia", surname: "Kastrylia", salary: 1290, sex: "male" },
    ]);


    const addNewEmployee = () => {
        setEmployee([...emp, {
            id: emp[emp.length - 1].id + 1,
            name: document.getElementById("inputNameId").value,
            surname: document.getElementById("inputSurnameId").value,
            salary: document.getElementById("inputSalaryId").value,
            sex: document.getElementById("selectSexId").value,
        }]);
    }


    const table = emp.map(employee =>
            <tr>
                <td>{ employee.name }</td>
                <td>{ employee.surname }</td>
                <td>{ employee.salary }</td>
                <td>{ employee.sex }</td>
            </tr>
        );

    return(
        <div>
            <table border="1" >
                <tr>
                    <th>Name</th>
                    <th>Surname</th>
                    <th>Salary</th>
                    <th>Sex</th>
                </tr>
                { table }
            </table>
            <div style={{
                width: "400px",
                display: "flex",
                flexDirection: "column",
                border: "1px solid black",
                padding: "12px 8px",
                margin: "10px 0px"
            }}>
                <h2>Form for add new employee</h2>
                <input id="inputNameId" type="text" placeholder="Name" /><br />
                <input id="inputSurnameId" type="text" placeholder="Surname" /><br />
                <input id="inputSalaryId" type="number" placeholder="Salary" /><br />
                <select id="selectSexId">
                    <option selected disabled>Sex</option>
                    <option value="male" >Male</option>
                    <option value="female" >Female</option>
                </select><br />
                <button onClick={ () => addNewEmployee() }>Add new employee</button>
            </div>
        </div>
    );
}

export default Ex02;