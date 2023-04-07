import React, { useState } from "react";

function Ex07(props) {
    const [routes] = useState([
        { id: 1, name: "Маршрут 1" },
        { id: 2, name: "Маршрут 2" },
        { id: 3, name: "Маршрут 3" },
        { id: 4, name: "Маршрут 4" },
        { id: 5, name: "Маршрут 5" },
    ]);

    const handleClick = (target) => setRoute(target.value);

    const [route, setRoute] = useState(props?.value ?? '');
    const list = routes.map(route => 
            <li key={ route.id } >
                <label>
                    <span>{ route.name }</span>
                    <input
                        type="radio"
                        name="route"
                        value={ route.name }
                        onClick={ (event) => handleClick(event.target) }
                    />
                </label>
            </li>
        );

    return(
        <div>
            <ul>
                { list }
            </ul>
            <p>Ваш маршрут: { route }</p>
        </div>
    );
}

export default Ex07;