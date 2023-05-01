import React from "react";

function Employee(props) 
{
    return (
        <tr>
            <td>{props.name}</td>
            <td>{props.surname}</td>
            <td>{props.age}</td>
        </tr>
    );
}

export default Employee;