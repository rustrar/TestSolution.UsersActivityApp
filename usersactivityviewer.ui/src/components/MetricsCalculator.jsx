import React, { useState } from 'react';
import LifeTimeBar from './LifeTimeBar';
import Button from './ui/button/Button';

const MetricsCalculator = () => {
    const [rollingRetention, setRollingRetention] = useState([])
    const [lifeTime, setLifeTime] = useState([])
    
    function calculateRollingRetention() {
        fetch('http://localhost:1422/api/calculateMetrics/rollingretention')
            .then(response => response.json())
            .then(rollingRetention => {
                setRollingRetention(rollingRetention)
            });
        
        getLifeTime();
    }

    function getLifeTime() {
        fetch('http://localhost:1422/api/calculateMetrics/lifetime')
        .then(response => response.json())
        .then(lifeTime => {
            setLifeTime(lifeTime)
        });
    }

    return (
        <div>
            <Button onClick={ calculateRollingRetention }>Calculate</Button>
            <span className="result-rollingretention">{rollingRetention}</span>
            {
                lifeTime.length ?
                    <LifeTimeBar lifeTime={lifeTime} /> :
                    null
            }
        </div>
    );
};

export default MetricsCalculator;
