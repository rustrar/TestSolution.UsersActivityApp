import React from 'react';

const Button = function (props) {
    return (
        <div>
            <button disabled={props.disabled} className="btn btn_primary">{props.text}</button>
        </div>
    );
};

export default Button;