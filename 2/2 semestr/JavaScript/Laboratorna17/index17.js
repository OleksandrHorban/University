import React from 'react';
import ReactDOM from 'react-dom';


class App extends React.Component {
	render() {
		const text = 'текст';
    const textt = '<p>текст</p>';
    const text1 = '<p>текст1</p>';
    const text2 = '<p>текст2</p>';
    const attr = 'block';
    const str = 'block';
    const css = {color: '#a0d9cd', border: '2px solid #4d9695', borderRadius: '40px',};

    const show = Math.random() > 0.5;
    var rezult = '';
    if (show) {
      rezult = <div> текст 1 </div>;
  } else {
      rezult = <div> текст 2 </div>;
  }
  
  const arr = ['a', 'b', 'c', 'd', 'e'];
  const list = arr.map((item,index) => {
    return <li>{item}</li>
  })

  function getText(){
    return <p>текст</p>;
  }

  function getNum1(){
    return 1;
  }
  function getNum2(){
    return 2;
  }

    return (
			<div> 
        1
				<div>текст</div><hr/>
        2
        <div>{text}</div><hr/>
        3
        <div>{textt}</div><hr/>
        4 
        <div>
        {text1}
        <p>!!!</p>
        {text2}
        </div><hr/>
        5
        <div id={attr}>текст</div><hr/>
        6
        <div class={str}>текст</div><hr/>
        7
        <div style={css}>текст</div><hr/>
        8
        <div>{rezult}</div><hr/>
        9
        <div><ul>{list}</ul></div><hr/>
        10
        <div>{getText()}</div><hr/>
        11
        <div>текст {getNum1() + getNum2()}</div>

			</div>
    );
	}
}

ReactDOM.render(<App/>, document.getElementById('root'));