import React, { useState } from "react";

function Ex09(props) {
    const [employees] = useState(
        [
            { id: 1, name: 'Іван',     surname: 'Іванюк',     salary: 820 },
            { id: 2, name: 'Петро',     surname: 'Петрюк',      salary: 840 },
            { id: 3, name: 'Степан',    surname: 'Степанюк',       salary: 610 },
            { id: 4, name: 'Олександр',     surname: 'Олександренко',     salary: 1230 },
            { id: 5, name: 'Дмитро',    surname: 'Дмитрюк',     salary: 990 }
        ]
    ); 


    const sortByName = () => {

        Table_set(employees
            .sort(( a, b ) => {
                if (a.name < b.name) return -1;
                else if (a.name > b.name) return 1;
                else return 0;
            })


            .map(employee =>
                <tr>
                    <td>{ employee.name }</td>
                    <td>{ employee.surname }</td>
                    <td>{ employee.salary }</td>
                </tr>
            )
        );
    }
    
    const sortBySurname = () => {
        
        Table_set(employees
            .sort(( a, b ) => {
                if (a.surname < b.surname) return -1;
                else if (a.surname > b.surname) return 1;
                else return 0;
            })


            .map(employee =>
                <tr>
                    <td>{ employee.name }</td>
                    <td>{ employee.surname }</td>
                    <td>{ employee.salary }</td>
                </tr>
            )
        );
    }
    
    const sortBySalary = () => {
        
        Table_set(employees
            .sort(( a, b ) => {
                if (a.salary < b.salary) return 1;
                else if (a.salary > b.salary) return -1;
                else return 0;
            })


            .map(employee =>
                <tr>
                    <td>{ employee.name }</td>
                    <td>{ employee.surname }</td>
                    <td>{ employee.salary }</td>
                </tr>
            )
        );
    }

    const [table, Table_set] = useState(employees.map(employee => 
            <tr>
                <td>{ employee.name }</td>
                <td>{ employee.surname }</td>
                <td>{ employee.salary }</td>
            </tr>
        ));

    return(
        <div>
            <table border="2">
                <tr>
                    <th
                        style={{ cursor: "pointer"}}
                        onClick={ () => sortByName() } 
                    >Name</th>
                    <th
                        style={{ cursor: "pointer"}}
                        onClick={ () => sortBySurname() }
                    >Surname</th>
                    <th
                        style={{ cursor: "pointer"}}
                        onClick={ () => sortBySalary() }
                    >Salary</th>
                </tr>
                {table}
            </table>
        </div>
    );
}

export default Ex09;