import React, { useState } from "react";
import TItem from "./TItem";

function Ex09(props) 
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
    const addProduct = () => {
        const newProduct = {
            id: products[products.length - 1].id + 1,
            name: document.getElementsByName("name_product")[0].value,
            price: +document.getElementsByName("price_product")[0].value,
            amount: +document.getElementsByName("amount_product")[0].value,
        };
        setProduct([...products, newProduct]);
    }


    const table = products.map(product =>
            <TItem product={product} deleteProduct={deleteProduct} />
        );
    return(
        <div>
            <div style={{margin: "22px"}}>
                <h4>Add new product</h4>
                <div>Name <input type="text" name="name_product" /></div><br/>
                <div>Price <input type="number" name="price_product" /></div><br/>
                <div>Amount <input type="number" name="amount_product" /></div><br/>

                <button onClick={addProduct}>Add product</button>
            </div>

            <table border="1" style={{minWidth: "450px", textAlign: "center"}}>
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Amount</th>
                    <th>Sum</th>
                    <th>Edit</th>
                </tr>
                { table }
            </table>
            
            <h2>
                Total Price:
                <span style={{margin: "0px 12px", textDecoration: "underline"}}>
                {
                    products
                        .map(obj => obj)
                        .reduce((acc, obj) => acc + (obj.price * obj.amount), 0)
                }
                </span>
            </h2>
        </div>
    );
}

export default Ex09;