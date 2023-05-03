import React from "react";


function TItem(props)
{
    return(
        <tr>
            <td>{props.product.name}</td>
            <td>{props.product.price}</td>
            <td>{props.product.amount}</td>
            <td>{props.product.price * props.product.amount}</td>
            <td>
                <button onClick={() => props.deleteProduct(props.product)} >
                    Delete
                </button>
            </td>
        </tr>
    );
}

export default TItem;