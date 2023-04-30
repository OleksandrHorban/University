import React, { useState } from "react";

function Ex04(props) {

    const [cities, setCity] = useState(props?.city ?? "");
    const [select, setSelect] = useState(props?.select ?? "");

    const addNewCity = () => {

        let input = document.getElementById("inputId");
        
        if (input.value !== undefined || input.value.length > 0) {
            
            const newCity = <option value={ input.value }>{ input.value }</option>
            setCity([...cities, newCity]);
            input.value = "";
        }
    }
    const changeSelect = (target) => {

        setSelect(target.value);
    }

    return(
        <div>
            <div>
                <input id="inputId" type="text" placeholder="Input name city" />
                <button onClick={ () => addNewCity() }>Add this city</button>
            </div>
            <select
                style={{ margin: "12px 0px", minWidth: "200px" }}
                onChange={ (event) => changeSelect(event.target) }
            >
                <option selected disabled >Select city</option>
                { cities }
            </select>
            <p>Selected city: { select }</p>
        </div>
    );
}

export default Ex04;