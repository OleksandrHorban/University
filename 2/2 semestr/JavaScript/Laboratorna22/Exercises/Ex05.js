import React, { useState } from "react";

function Ex05(props) {

    const [result, setResult] = useState(props?.result ?? "");

    const converting = () => {

        const selectConvertFrom = document.getElementById("selectConvertFromId").value;
        const selectConvertTo = document.getElementById("selectConvertToId").value;
        const quantity = document.getElementById("inputQuantityId").value;

        if (selectConvertFrom === "usd") {
            if (selectConvertTo === "usd") setResult((quantity).toFixed(2));
            else if (selectConvertTo === "eur") setResult((quantity * 0.93).toFixed(2));
            else if (selectConvertTo === "uah") setResult((quantity * 0.37).toFixed(2));
            else if (selectConvertTo === "cad") setResult((quantity * 0.14).toFixed(2));
        }
        else if (selectConvertFrom === "eur") {
            if (selectConvertTo === "usd") setResult((quantity * 0.11).toFixed(2));
            else if (selectConvertTo === "eur") setResult((quantity * 1.0).toFixed(2));
            else if (selectConvertTo === "uah") setResult((quantity * 0.40).toFixed(2));
            else if (selectConvertTo === "cad") setResult((quantity * 0.15).toFixed(2));
        }
        else if (selectConvertFrom === "uah") {
            if (selectConvertTo === "usd") setResult((quantity * 0.27).toFixed(2));
            else if (selectConvertTo === "eur") setResult((quantity * 0.25).toFixed(2));
            else if (selectConvertTo === "uah") setResult((quantity * 1.0).toFixed(2));
            else if (selectConvertTo === "cad") setResult((quantity * 0.37).toFixed(2));
        }
        else if (selectConvertFrom === "cad") {
            if (selectConvertTo === "usd") setResult((quantity * 0.73).toFixed(2));
            else if (selectConvertTo === "eur") setResult((quantity * 0.68).toFixed(2));
            else if (selectConvertTo === "uah") setResult((quantity * 0.27).toFixed(2));
            else if (selectConvertTo === "cad") setResult((quantity * 1.0).toFixed(2));
        }
    }

    return(
        <div>
            <p>
                Convert from
                <select id="selectConvertFromId" style={{ margin: "0px 12px" }} >
                    <option selected disabled >Select currency</option>
                    <option value="usd">US Dollar</option>
                    <option value="eur">Euro</option>
                    <option value="uah">Ukrainian Hryvnia</option>
                    <option value="cad">Canadian Dollar</option>
                </select>
                to
                <select id="selectConvertToId" style={{ margin: "0px 12px" }} >
                    <option selected disabled >Select currency</option>
                    <option value="usd">US Dollar</option>
                    <option value="eur">Euro</option>
                    <option value="uah">Ukrainian Hryvnia</option>
                    <option value="cad">Canadian Dollar</option>
                </select>
            </p>
            <div>
                <input id="inputQuantityId" type="number" placeholder="Enter quantity" />
                <button onClick={ () => converting() }>Convert</button>
                <p>Convert value: { result }</p>
            </div>
        </div>
    );
}

export default Ex05;