import React from 'react';
import ReactDOM from 'react-dom';



class App extends React.Component {
    constructor() {
        super();
        this.state = {
            value: 'Hi',
            check: true,
            option: 'option',
            option_value: ["New York", "Chicago", "Chernivtsi", "Putyla"],
            pagelist_task9: ["eeeeeee body", "light weight", "Ronnie Coleman"],
            task_10: [],
            texts: [],
        };
    }

    //1
    handleChange(event) {
        this.setState({value: event.target.value});
    }

    //2-3
    handleChange(event) {
        this.setState({value: event.target.value});
    }

    CheckboxChange(event) {
        this.setState({checked: !this.state.check});
    }

    //4
    SelectChange(event) {
        this.setState({value: event.target.value});
    }

    //5
    ChangeRadio(event) {
        this.setState({option: event.target.value});
    }

    //6
    Texts() {
        this.state.texts.push(this.state.value);
        this.setState({texts: this.state.texts});
    }

    //10
    Options() {
        this.state.task_10.push(this.state.value);
        this.setState({zd10_options: this.state.texts});
    }


    render() {
        const option = this.state.option_value.map((item, index) => {
            return <option key={index} value={item}>{item}</option>;
        });

        const page_n6 = this.state.texts.map((item, index) => {
            return <p>{item}</p>;
        });

        const page_n9 = <p> {this.state.pagelist_task9[this.state.value - 1]} </p>;
        
        const task10_option = this.state.task_10.map((item, index) => {
            return <option key={index} value={index}>{item}</option>;
        });


        return (
            <div>
        1 Завдання
            <p>Абзац: <br/> {this.state.value}</p>
            <textarea value={this.state.value} onChange={this.handleChange.bind(this)}/>
            <hr/>
        Завдання 2-3
            <input type="checkbox" checked={this.state.check} onChange={this.handleChange.bind(this)}/>
            <p>Стан: {this.state.check ? 'відмічено' : 'не відмічено'}</p>
            <hr/>
        Завдання 4
            <br></br>
            <select value={this.state.value} onChange={this.SelectChange.bind(this)}>
                {option}
            </select>
            <p>{this.state.value}</p>
            <hr/>
        Завдання 5
            <p>Зробіть вибір: {this.state.option}</p>
            <input name="lang" type="radio" value="варіант1" checked={this.state.option == 'варіант1'} onChange={this.ChangeRadio.bind(this)}/>
            <input name="lang" type="radio" value="варіант2" checked={this.state.option == 'варіант2'} onChange={this.ChangeRadio.bind(this)}/>
            <input name="lang" type="radio" value="варіант3" checked={this.state.option == 'варіант3'} onChange={this.ChangeRadio.bind(this)}/>
            <hr/>
        Завдання 6
            <br/>
            <textarea value={this.state.value} onChange={this.handleChange.bind(this)}/>
            <br/>
            <button onClick={this.Texts.bind(this)}>Відсунути</button>
            <br/>
            те що ви написали:
            <br/>
            {page_n6}
            <hr/>
        Завдання 7
            <p style={{backgroundColor: this.state.value}}>колір</p>
                <select value={this.state.value} onChange={this.SelectChange.bind(this)}>
                    <option>white</option>
                    <option>purple</option>
                    <option>pink</option>
                    <option>yellow</option>
                    <option>blue</option>
                    <option>black</option>
                </select>
                <hr/>
        Завдання 8
        <input type="checkbox" checked={this.state.check} onChange={this.CheckboxChange.bind(this)}/>
        <select value={this.state.check} onChange={this.SelectChange.bind(this)}>
                    <option>позначено</option>
                    <option>не позначено</option>
        </select>
        <hr/>
        Завдання 9
        <br/>
            <select value={this.state.value} onChange={this.SelectChange.bind(this)}>
                <option>1</option>
                <option>2</option>
                <option>3</option>
            </select>
            <br/>
            {page_n9}
            <hr/>
        Завдання 10
        <br/>
        <p>Введіть текст</p>
        <input name="lang" onChange={this.handleChange.bind(this)}/>
            <button onClick={this.Options.bind(this)}>Додати</button>
            <select value={this.state.value}>
                {task10_option}
            </select>
        <hr/>
        </div>
        );
    }
}

ReactDOM.render(<App/>, document.getElementById("root"));