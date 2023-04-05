import React from 'react';
import ReactDOM from 'react-dom';

class App extends React.Component {
    constructor() {
        super();
        this.state = {
            name: 'Іван', age: 40, show: false,
            name_masiv: ['Коля', 'Василь', 'Петро', 'Іван', 'Дмитро'],
            input5task: 'пишіть',
            input6task: 'пишіть', 
            input7task: '',
            input8task: '',
            input9task: '',
            input9_2task: '',
            input10task: '',
            input10_1task: '',
            input10_2task: '',
            year: 2023,
            pib: ['', '', '', ''],
            input12task: '',
            hrefs: [
                {href: '1.html', text: 'link 1'},
                {href: '2.html', text: 'link 2'},
                {href: '3.html', text: 'link 3'},
            ],
            href: '',
            texthref: '',
            idForDelete: '',
            users: [
                {name: 'Коля', age: 25},
                {name: 'Василь', age: 35},
                {name: 'Петро', age: 45},
            ],
            users_name: '',
            users_age: ''

        };
    }

    // 1 - 4
    addItem(text = 'пункт') {
        this.state.name_masiv.push(text); 
        this.setState({name_mas: this.state.name_masiv}); 
          }

    dellItem() {
        this.state.name_masiv.pop();
        this.setState({name_mas: this.state.name_masiv}); 
    }

    dellItemId(id) {
        this.state.name_masiv.splice(id, 1);
        this.setState({name_mas: this.state.name_masiv}); 
    }

    //5
    changeInput(event) {
        this.setState({input5: event.target.value});
    }

    //6
    changeInput2(event) {
        this.setState({input6: event.target.value});
    }

    //7
    changeInput3(event) {
        if (Number.isInteger(parseInt(event.target.value, 10))) {
            this.setState({input7: parseInt(event.target.value, 10)});
        }
        if (event.target.value == '') {
            this.setState({input7: event.target.value});
        }
    }

    //8
    changeInput4(event) {
        this.setState({input8: event.target.value});
    }

    //9
    changeText9(event) {
        this.setState({text9: event.target.value});
    }

    SubmitText9(event) {
        this.setState({text9_2: this.state.input9task});
        event.preventDefault();
    }

    //10
    changeText10(event) {
        this.setState({text10: event.target.value});
    }

    changeText10_1(event) {
        this.setState({text10_1: event.target.value});
    }

    SubmitText10(event) {
        this.setState({text10_2: parseInt(this.state.input10task) + parseInt(this.state.input10_1task)});
        event.preventDefault();
    }

    //11
    changePib(id, event) {
        this.state.pib[id] = event.target.value;
        this.setState({pib: this.state.pib});
    }

    SubmitPib(event) {
        this.state.pib[3] = this.state.pib[0] + " " + this.state.pib[1] + " " + this.state.pib[2];
        this.setState({pib: this.state.pib});
        event.preventDefault(); 
    }

    //12-13
    changeInputName(event) {
        this.setState({inputName12: event.target.value});
    }

    addItem2(event) {
        this.addItem(this.state.input12task);
        event.preventDefault();
    }

    // 14
    SubmitHref(event) {
        this.state.hrefs.push({href: this.state.href, text: this.state.hrefText});
        this.setState({hrefs: this.state.hrefs});
        event.preventDefault();
    }

    changeHref(event) {
        this.state.href = event.target.value;
        this.setState({href: this.state.href});
    }

    changeHrefText(event) {
        this.state.hrefText = event.target.value;
        this.setState({hrefText: this.state.hrefText});
    }

    //15
    changeIdForDel(event) {
        this.state.idForDelete = event.target.value;
        this.setState({idForDel: this.state.idForDelete});
    }
    SubmitIdForDel(event) {
        this.dellItemId(this.state.idForDelete);
        event.preventDefault();
    }

    //16
    SubmitPushToUsers(event) {
        this.state.users.push({name: this.state.users_name, age: this.state.users_age});
        this.setState({users: this.state.users});
        event.preventDefault();
    }
    changeUsers_name(event) {
        this.state.users_name = event.target.value;
        this.setState({users_name: this.state.users_name});
    }

    changeUsers_age(event) {
        this.state.users_age = event.target.value;
        this.setState({users_age: this.state.users_age});
    }


    render() {
        const pib = this.state.input8task.split(" ");

        const rez9 = this.state.name_masiv.map((item, index) => {
            return <li key={index}>
                {item}
                <button onClick={this.dellItemId.bind(this, index)}>
                    del
                </button>
            </li>;
        });

        const rez14 = this.state.hrefs.map(function (item, index) {
            return <li><a href={item.href}> {item.text}</a></li>;
        });

        const rez15 = this.state.name_masiv.map((item, index) => {
            return <li key={index}>
                {item}
            </li>;
        });

        const rez16 = this.state.users.map((item, index) => {
            return <tr>
                <td> {item.name} </td><td> {item.age} </td>
            </tr>;
        });


        return (
            <div>
              Завдання 1-4
                <div>
                    <ul>
                        {rez9}
                    </ul>
                    <button onClick={this.dellItem.bind(this)}>Delete</button>
                </div>
                <hr/>

              Завдання 5
                <div>
                    <input value={this.state.input5task} onChange={this.changeInput.bind(this)}/>
                    <p>
                        {this.state.input5task}
                    </p>
                </div>
                <hr/>
          
              Завдання 6
                <div>
                    <input value={this.state.input6task} onChange={this.changeInput2.bind(this)}/>
                    <p>
                        {this.state.input6task.toUpperCase()} 
                    </p>
                </div>
                <hr/>

              Завдання 7
                <div>
                    <input value={this.state.input7task} onChange={this.changeInput3.bind(this)}/>
                    <p>
                        Вік: {this.state.input7task}
                    </p>
                    <p>
                      Рік народження: {this.state.year - this.state.input7task}
                    </p>
                </div>
                <hr/>

                <div>
                    <p>Завдання 8</p>
                    Введіть ПІБ
                    <br/>
                    <input value={this.state.input8task} onChange={this.changeInput4.bind(this)}/>
                    <p>
                        Прізвище: {pib[0]}
                    </p>
                    <p>
                        Ім'я: {pib[1]}
                    </p>
                    <p>
                        По батькові: {pib[2]}
                    </p>
                </div>
                <hr/>

               Завдання 9
                <form onSubmit={this.SubmitText9.bind(this)}>
                    <input value={this.state.input9task} onChange={this.changeText9.bind(this)}/>
                    <input type="submit"/>
                    <p>{this.state.input9_2task}</p>
                </form>
                <hr/>

               Завдання 10
               <p>Введіть числа</p>
                <form onSubmit={this.SubmitText10.bind(this)}>
                    <input value={this.state.input10task} onChange={this.changeText10.bind(this)}/>
                    <input value={this.state.input10_1task} onChange={this.changeText10_1.bind(this)}/>
                    <input type="submit"/>
                    <p>{this.state.input10_2task}</p>
                </form>
                <hr/>

                Завдання 11
                <p>Введіть ПІБ</p>
                <form onSubmit={this.SubmitPib.bind(this)}>
                    <input onChange={this.changePib.bind(this, 0)}/>
                    <input onChange={this.changePib.bind(this, 1)}/>
                    <input onChange={this.changePib.bind(this, 2)}/>
                    <input type="submit"/>
                    <p>{this.state.pib[3]}</p>
                </form>
                <hr/>

                Завдання 12-13
                <form onSubmit={this.addItem2.bind(this)}>
                    <ul>
                        {rez9}
                    </ul>
                    <input value={this.state.input12task} onChange={this.changeInputName.bind(this)}/>
                    <input type="submit"/>
                </form>
                <hr/>

                Завдання 14
                <p>Введіть href + текст посилання</p>
                <form onSubmit={this.SubmitHref.bind(this)}>
                    <ul>
                        {rez14}
                    </ul>
                    <input value={this.state.href} onChange={this.changeHref.bind(this)}/>
                    <input value={this.state.hrefText} onChange={this.changeHrefText.bind(this)}/>
                    <input type="submit"/>
                </form>
                <hr/>

                Завдання 15
                <form onSubmit={this.SubmitIdForDel.bind(this)}>
                    <ul>
                        {rez15}
                    </ul>
                    <input value={this.state.idForDelete} onChange={this.changeIdForDel.bind(this)}/>
                    <input type="submit"/>
                </form>
                <hr/>

                Завдання 16
                <table>
                    {rez16}
                </table>
                <form onSubmit={this.SubmitPushToUsers.bind(this)}>
                    <input value={this.state.users_name} onChange={this.changeUsers_name.bind(this)}/>
                    <input value={this.state.users_age} onChange={this.changeUsers_age.bind(this)}/>
                    <input type="submit"/>
                </form>

            </div>
        );
    }
}

ReactDOM.render(<App/>, document.getElementById("root"));
