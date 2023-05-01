import React, { useState } from "react";
import Employee from "./Employee";

function Ex03(props) 
{
    const [employees] = useState(
    [
        { id: 1, name: "Name1", surname: "Surname1", age: 41 },
        { id: 2, name: "Name2", surname: "Surname2", age: 42 },
        { id: 3, name: "Name3", surname: "Surname3", age: 43 },
        { id: 4, name: "Name4", surname: "Surname4", age: 44 },
        { id: 5, name: "Name5", surname: "Surname5", age: 45 },
    ]);


    const showMessage = (line) => alert(line);

    const table = employees.map(employee =>
        <Employee
            name={employee.name}
            surname={employee.surname}
            age={employee.age}
            func={() => showMessage(employee.name)}
        />);

    return (
        <table border="1" >
            <tr>
                <th>Name</th>
                <th>Surname</th>
                <th>Age</th>
                <th>Link</th>
            </tr>
            { table }
        </table>
    );
}


export default Ex03;