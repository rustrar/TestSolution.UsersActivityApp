import React, { useState } from 'react';
import Button from './ui/button/Button';

const RollingRetentionCalculator = () => {
    const [rollingRetention, setRollingRetention] = useState([])
    
    function calculateRollingRetention() {
        fetch('http://localhost:1422/api/calculateMetrics/rollingretention')
            .then(response => response.json())
            .then(rollingRetention => {
                setRollingRetention(rollingRetention)
            });
    }

    return (
        <div>
            <Button onClick={ calculateRollingRetention }>Calculate</Button>
            <span className="result-rollingretention">{rollingRetention}</span>
        </div>
    );
};

export default RollingRetentionCalculator;