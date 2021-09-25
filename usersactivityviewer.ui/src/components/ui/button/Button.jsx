import React from 'react';
import classes from './Button.module.css';

const Button = ({children, disabled, ...props}) => {
    return (
        <button {...props} className={`${classes.btn} ${disabled ? classes.btn_disabled : classes.btn_primary}`}>
            {children}
        </button>
    );
};

export default Button;
