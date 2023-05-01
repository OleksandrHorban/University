import React from "react";

function Employee(props) 
{
    return (
        <tr>
            <td>{props.name}</td>
            <td>{props.surname}</td>
            <td>{props.age}</td>
            <td>
                <a href="#" onClick={props.func} >Click</a>
            </td>
        </tr>
    );
}

export default Employee;