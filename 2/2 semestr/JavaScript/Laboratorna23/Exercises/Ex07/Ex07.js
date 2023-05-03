import React, { useState } from "react";
import TItem from "./TItem";

function Ex07(props) 
{
    const [products, setProduct] = useState(
        [
            {id: 1, name: "Name01", price: 1000, amount: 100},
            {id: 2, name: "Name02", price: 2000, amount: 200},
            {id: 3, name: "Name03", price: 3000, amount: 300},
            {id: 4, name: "Name04", price: 4000, amount: 400},
            {id: 5, name: "Name05", price: 5000, amount: 500},
            {id: 6, name: "Name06", price: 6000, amount: 600}
        ]);


    const deleteProduct = (pro) => {
        setProduct(products.filter(product => product.id !== pro.id));
    }


    const table = products.map(product =>
            <TItem product={product} deleteProduct={deleteProduct} />
        );
    return(
        <table border="1" style={{minWidth: "300px", textAlign: "center"}}>
            <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Amount</th>
                <th>Sum</th>
                <th>Edit</th>
            </tr>
            { table }
        </table>
    );
}

export default Ex07;