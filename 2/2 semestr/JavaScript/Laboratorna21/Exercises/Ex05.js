import React, { useState } from 'react';

function Ex05() {
    const [items, setItems] = useState([
        { id: 1, value: 'Варіант 1'},
        { id: 2, value: 'Варіант 2'},
        { id: 3, value: 'Варіант 3'},
        { id: 4, value: 'Варіант 4'},
        { id: 5, value: 'Варіант 5'},
        { id: 6, value: 'Варіант 6'},
        { id: 7, value: 'Варіант 7'}
    ]);


    const handleEdit = (id, target) => {
        const updateItems = items.map(item => {
            const newItem = {
                id: id, 
                value: (target.value === '' ? item.value : target.value)
            };

            if (item.id === id) return { ...item, ...newItem };
            else return item;
        });
        
        setItems(updateItems);

        target.style.display = "none";
        target.value = '';
    };


    const showInput = (target) => {
        target.style.display = "inline";
        target.focus();
    }


    let list = items.map(item => (
        <li
            key={ item.id }
            onClick={ () => showInput(document.getElementById(item.id)) }
            style={{ margin: "10px 0px" }}
        >
            <span style={{ marginRight: "20px" }} >{ item.value }</span>
            <input 
                type="text"
                id={ item.id }
                placeholder="Input your change"
                style={{ display: "none" }}
                onBlur={ (event) => handleEdit(item.id, event.target) }
            />
        </li>
    ));

    return(
        <div>
            <ul>
                { list }
            </ul>
        </div>
    );
}

export default Ex05;