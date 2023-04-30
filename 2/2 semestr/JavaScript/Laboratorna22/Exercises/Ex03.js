import React, { useState } from "react";


function Ex03(props) {

    const arrayEmployees = [
        { id: 1, name: "Name01", surname: "Surname01", salary: 1000 },
        { id: 2, name: "Name02", surname: "Surname02", salary: 1000 },
        { id: 3, name: "Name03", surname: "Surname03", salary: 1000 },
        { id: 4, name: "Name04", surname: "Surname04", salary: 1000 },
        { id: 5, name: "Name05", surname: "Surname05", salary: 1000 },
        { id: 6, name: "Name06", surname: "Surname06", salary: 1000 },
        { id: 7, name: "Name07", surname: "Surname07", salary: 1000 },
        { id: 8, name: "Name08", surname: "Surname08", salary: 1000 },
        { id: 9, name: "Name09", surname: "Surname09", salary: 1000 },
        { id: 10, name: "Name10", surname: "Surname10", salary: 1000 },
        { id: 11, name: "Name11", surname: "Surname11", salary: 1000 },
        { id: 12, name: "Name12", surname: "Surname12", salary: 1000 },
        { id: 13, name: "Name13", surname: "Surname13", salary: 1000 },
        { id: 14, name: "Name14", surname: "Surname14", salary: 1000 },
        { id: 15, name: "Name15", surname: "Surname15", salary: 1000 },
        { id: 16, name: "Name16", surname: "Surname16", salary: 1000 },
        { id: 17, name: "Name17", surname: "Surname17", salary: 1000 },
        { id: 18, name: "Name18", surname: "Surname18", salary: 1000 },
        { id: 19, name: "Name19", surname: "Surname19", salary: 1000 },
        { id: 20, name: "Name20", surname: "Surname20", salary: 1000 },
        { id: 21, name: "Name21", surname: "Surname21", salary: 1000 },
        { id: 22, name: "Name22", surname: "Surname22", salary: 1000 },
        { id: 23, name: "Name23", surname: "Surname23", salary: 1000 },
        { id: 24, name: "Name24", surname: "Surname24", salary: 1000 },
        { id: 25, name: "Name25", surname: "Surname25", salary: 1000 },
        { id: 26, name: "Name26", surname: "Surname26", salary: 1000 },
        { id: 27, name: "Name27", surname: "Surname27", salary: 1000 },
        { id: 28, name: "Name28", surname: "Surname28", salary: 1000 },
        { id: 29, name: "Name29", surname: "Surname29", salary: 1000 },
        { id: 30, name: "Name30", surname: "Surname30", salary: 1000 },
        { id: 31, name: "Name31", surname: "Surname31", salary: 1000 },
        { id: 32, name: "Name32", surname: "Surname32", salary: 1000 },
        { id: 33, name: "Name33", surname: "Surname33", salary: 1000 },
        { id: 34, name: "Name34", surname: "Surname34", salary: 1000 },
        { id: 35, name: "Name35", surname: "Surname35", salary: 1000 },
        { id: 36, name: "Name36", surname: "Surname36", salary: 1000 },
        { id: 37, name: "Name37", surname: "Surname37", salary: 1000 },
        { id: 38, name: "Name38", surname: "Surname38", salary: 1000 },
        { id: 39, name: "Name39", surname: "Surname39", salary: 1000 },
        { id: 40, name: "Name40", surname: "Surname40", salary: 1000 },
        { id: 41, name: "Name41", surname: "Surname41", salary: 1000 },
        { id: 42, name: "Name42", surname: "Surname42", salary: 1000 },
    ]


    const nPage = () => {
        if (page < maxpage) {
            setPage(1 + page);

            setEmployee(arrayEmployees.filter(employee =>
                employee.id <= (page + 1) * 10 && employee.id > page * 10));
            }
    }
    const pPage = () => {
        if (page > 1) {
            setPage(page - 1);

            setEmployee(arrayEmployees.filter(employee =>
                employee.id <= (page - 1) * 10 && employee.id > (page - 2) * 10 ));
        }
    }


    const maxpage = Math.ceil(arrayEmployees.length / 10);
    const [page, setPage] = useState(1);

    const [employees, setEmployee] = useState(arrayEmployees.filter(employee =>
        employee.id <= page * 10 && employee.id >= page));

    const table = employees.map(employee => {
            return (
                <tr>
                    <td>{ employee.name }</td>
                    <td>{ employee.surname }</td>
                    <td>{ employee.salary }</td>
                </tr>
            );
    });

    return(
        <div style={{ width: "400px" }} >
            <div align="center" style={{ margin: "10px 0px" }} >
                <button onClick={ () => pPage() } >
                    Prev
                </button>

                <span style={{ margin: "0px 10px" }} >
                    { page }
                </span>

                <button onClick={ () => nPage() } >
                    Next
                </button>
            </div>

            <table border="1" style={{ width: "100%" }} >
                <tr>
                    <th>Name</th>
                    <th>Surname</th>
                    <th>Salary</th>
                </tr>
                { table }
            </table>
        </div>
    );
}


export default Ex03;