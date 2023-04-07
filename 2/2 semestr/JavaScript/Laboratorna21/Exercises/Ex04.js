import React from 'react';

class Ex04 extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            users: [
                { name: "Микола", surname: "Шевченко", age: 30 },
                { name: "Василь", surname: "Чумак", age: 40 },
                { name: "Петро", surname: "Стеценконко", age: 50 },
            ]
        };

        this.handleClick = this.Click.bind(this);
    }

    Click(event) {
        let fullName = '';
        this.state.users.forEach(user => {
            if(event.target.name === user.name + ' ' + user.surname)
            {
                fullName = user.name + ' ' + user.surname + ' ' + user.age;
            }
        });

        if (event.target.checked)
            document.getElementById(event.target.name).textContent = fullName;
        else
            document.getElementById(event.target.name).textContent = fullName.split(' ')[0];
    }

    render() {
        let list = this.state.users.map(user => 
                <li key={ Math.random() }>
                    <input
                        type="checkbox"
                        name={ user.name + ' ' + user.surname }
                        onClick={ this.Click }
                    />
                    <span id={ user.name + ' ' + user.surname }>
                        { user.name }
                    </span>
                </li>
            );

        return(
            <div>
                <ul>
                    { list }
                </ul>
            </div>
        );
    }
}

export default Ex04;