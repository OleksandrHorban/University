import React from "react";

function Item(props)
{
    return (
        <li
            key={props.item.id}
            style={{margin: "3px 0px"}}
        >
            <span style={{marginRight: "8px"}} >{props.item.value}</span>
            <input 
                type="text"
                id={props.item.id}
                placeholder="Input your change"
                style={{display: "none"}}
                onBlur={(event) => props.handleEdit(
                    props.item.id,
                    event.target,
                    document.getElementById("link" + props.item.id)
                )}
            />
            <a
                href="#"
                id={"link" + props.item.id}
                onClick={() => props.showInput(
                    document.getElementById(props.item.id),
                    document.getElementById("link" + props.item.id)
                )}
            >
                Edit
            </a>
        </li>
    );
}

export default Item;