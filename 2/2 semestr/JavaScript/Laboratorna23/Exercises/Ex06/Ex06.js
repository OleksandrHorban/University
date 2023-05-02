import React, { useState } from "react";
import Item from "./Item.js";


function Ex06(props)
{
    const [items, setItems] = useState([
        { id: 1, value: 'Item 1'},
        { id: 2, value: 'Item 2'},
        { id: 3, value: 'Item 3'},
        { id: 4, value: 'Item 4'},
        { id: 5, value: 'Item 5'},
        { id: 6, value: 'Item 6'},
        { id: 7, value: 'Item 7'},
        { id: 8, value: 'Item 8'},
        { id: 9, value: 'Item 9'},
        { id: 10, value: 'Item 10'}
    ]);



    const focusEdit = (id, input, link) => {
        const updateItems = items.map(item => {
            const newItem = {
                id: id, 
                value: (input.value === '' ? item.value : input.value)
            };

            if (item.id === id) return {...item, ...newItem};
            else return item;
        });
        
        setItems(updateItems);

        link.style.display = "inline";
        input.style.display = "none";
        input.value = '';
    };

    
    const InputShow = (input, link) => 
    {
        link.style.display = "none";
        input.style.display = "inline";
        input.focus();
    }


    let list = items.map(item => 
        <Item 
            item={item} 
            showInput={InputShow}
            handleEdit={focusEdit}
        />);

    return(
        <div>
            <ul>
                { list }
            </ul>
        </div>
    );
}

export default Ex06;