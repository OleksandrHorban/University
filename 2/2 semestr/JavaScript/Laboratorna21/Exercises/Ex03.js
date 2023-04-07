import React from 'react';

class Ex03 extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            arr: [
                'Елемент 1',
                'Елемент 2',
                'Елемент 3',
                'Елемент 4',
                'Елемент 5',
                'Елемент 6',
            ]
        };

        this.handleClick = this.Click.bind(this);
    }

    Click(event) {
        if (!event.target.checked)
            document.getElementById(event.target.name).style.display = 'none';
        else
            document.getElementById(event.target.name).style.display = 'block';
    }

    render() {
        let result = this.state.arr.map(item =>
            <div>
                <label>
                    <input
                        type="checkbox"
                        name={ item }
                        onClick={ this.Click }
                        defaultChecked
                    />
                    Checkbox "{ item }"
                </label>
                <p id={ item }>
                    { item }
                </p>
            </div>
        );
        return(
            <div>
                { result }
            </div>
        );
    }
}

export default Ex03;