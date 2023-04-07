import React, { useState } from 'react';

function Ex02(props)  {

    
    const [employees] = useState(
        [
            { Name: 'Іван',     Surname: 'Іванюк',     salary: 890,   totalSalary: true },
            { Name: 'Петро',     Surname: 'Петрюк',      salary: 570,    totalSalary: true },
            { Name: 'Степан',    Surname: 'Степанюк',       salary: 800,    totalSalary: true },
            { Name: 'Марк',     Surname: 'Марків',     salary: 420,   totalSalary: true },
            { Name: 'Олександр',    Surname: 'Олександрів',     salary: 1190,    totalSalary: true },
            { Name: 'Віталій',     Surname: 'Віталюк',    salary: 920,    totalSalary: true },
            { Name: 'Ростислав',    Surname: 'Ростистюк',     salary: 1930,   totalSalary: true },
            { Name: 'Євгеній', Surname: 'Євгенюк',    salary: 1370,   totalSalary: true }
        ]
    ); 

    let result = 0;
    employees.map(employee => result += employee.salary)

    const [totalSalary, setTotalSalary] = useState(result);
    
    function TheTotalSalarychange(event) {
        let fullName = (event.target.id + "").split(' ');

        if (!event.target.checked) {
            employees.forEach(emp => {
                if (emp.Name + ' ' + emp.Surname === fullName.join(' ')) {
                    emp.totalSalary = false;
                    setTotalSalary(totalSalary - emp.salary);
                }
            });
        }
        else {
            employees.forEach(emp => {
                if (emp.Name + ' ' + emp.Surname === fullName.join(' ')) {
                    emp.totalSalary = true;
                    setTotalSalary(totalSalary + emp.salary);
                }
            });
        }
    }

    const table = employees.map(employee => {

        return (
            <tr>
                <td>{ employee.Name }</td>
                <td>{ employee.Surname }</td>
                <td>{ employee.salary }</td>
                <td>
                    <label>
                        <input
                            id={ employee.Name + " " + employee.Surname}
                            type="checkbox"
                            defaultChecked
                            onClick={ TheTotalSalarychange }
                        />Include
                    </label>
                </td>
            </tr>
        );
    });

    return(
        <div>
            <table border='1'>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Salary</th>
                    <th>Total salary</th>
                </tr>
                { table }
            </table>
            <p>Total salary: { totalSalary }</p>
        </div>
    );
}

export default Ex02;