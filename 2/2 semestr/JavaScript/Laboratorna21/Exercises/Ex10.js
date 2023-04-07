import React, { useState } from "react";

function Ex10(props) {
    const ua = [
        'Понеділок',
        'Вівторок',
        'Середа',
        'Четвер',
        'П`ятниця',
        'Субота',
        'Неділя',
    ]
    const en = [
        'Monday',
        'Tuesday',
        'Wednesday',
        'Thursday',
        'Friday',
        'Saturday',
        'Sunday',
    ]

    const changeSelection = (target) => {
        if(target.value === "Ukraine")
            setTwoSelection(ua.map(day =>
                    <option value={ day }>{ day }</option>
                ));
        else if(target.value === "English")
            setTwoSelection(en.map(day =>
                    <option value={ day }>{ day }</option>
                ));
    }

    const [twoSelect, setTwoSelection] = useState(props?.value ?? '');

    return(
        <div>
            <select
                id="selectID_1"
                style={{ margin: "10px" }}
                onChange={ (event) => changeSelection(event.target) }
            >
                <option selected disabled>Виберіть мову</option>
                <option value="Ukraine" >Українська</option>
                <option value="English" >English</option>
            </select>
            <select
                id="selectID_2"
                style={{margin: "10px" }}
            >
                <option selected disabled>Select day week/Оберіть день тижня</option>
                { twoSelect }
            </select>
        </div>
    );
}

export default Ex10;