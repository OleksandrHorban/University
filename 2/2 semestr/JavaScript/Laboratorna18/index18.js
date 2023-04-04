import React from 'react';
import ReactDOM from 'react-dom';


class App extends React.Component {
  constructor() {
    super();

    this.state = 
    {name:'Іван', age: 25, show:false, mass: ['Коля','Вася','Петро'], hrefs: [
    {href: '1.html', text:'посилання 1'},
    {href: '2.html', text:'посилання 2'},
    {href: '3.html', text:'посилання 3'},
  ]};
  }

  showMessage(){
    alert('hello!');
  }

  showName(){
    alert(""+this.state.name);
  }

  changeName(){
    this.setState({name: 'Коля'});
  }

  changeAge(){
    this.setState({age: 30});
  }

  changeState(){
    this.setState({show: !this.state.show});
  }
	render() {
    if (this.state.show) {
			var message1 = <p>ім'я: {this.state.name}, вік: {this.state.age}</p>;
		}

    if(this.state.show){
      var message = <p>ім'я: {this.state.name}, вік: {this.state.age}</p>
      var textButton = "Сховати";
    } else var textButton = "Показати";
	
    const result9 = this.state.mass.map(function(item, index){
      return <li> {item} - {index+1}</li>;
    });

    const result11 = this.state.hrefs.map(function(item, index){
      return <li><a href={item.href}>{item.text}</a></li>
    })

    return ( <div>
			1 завдання
      <div>
        ім'я: {this.state.name}, вік: {this.state.age}
      </div>
      <hr/>
      2 завдання 
      <div onClick={this.showMessage}></div>
      <hr/>
      3 завдання 
      <div onClick={this.showName.bind(this)}></div>
      <hr/>
      4 завдання
      <div>
        <p onClick={this.changeName.bind(this)}>ім'я: {this.state.name}</p>
        <p onClick={this.changeAge.bind(this)}>вік: {this.state.age}</p>
      </div>
      <hr/>
      5 завдання
      <div>
        <p>{this.state.show ? 'Hi' : 'Bye'}, {this.state.name}!</p>
      </div>
      <hr/>
      6 завдання
      <div>
			<p>ім’я: {this.state.name}</p>
			<button onClick={this.changeName.bind(this)}>Натисни на мене</button>
      </div>
      <hr/>
      7 завдання
      <div>
        {message1}
      </div>
      <hr/>
      8 завдання
      <div>
        {message}
        <button onClick={this.changeState.bind(this)}>{textButton}</button>
      </div>
      <hr/>
      9-10 завдання
      <div>
        <ul>
          {result9}
        </ul>
      </div>
      11 завдання
      <div>
        <ul>
          {result11}
        </ul>
      </div>

      </div>);
	}
}

ReactDOM.render(<App/>, document.getElementById('root'));