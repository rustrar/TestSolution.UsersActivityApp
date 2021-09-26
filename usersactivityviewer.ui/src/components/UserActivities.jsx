import React, { useEffect, useState } from 'react';
import Button from './ui/button/Button';
import TBody from './TBody';
import THead from './THead';
import AddUserActivities from './AddUserActivities';

const UserActivities = () => {
    const [activities, setActivities] = useState([])

    useEffect(() => {
        fetch('http://localhost:1422/api/')
            .then(response => response.json())
            .then(activities => {
                setActivities(activities)
            });
    }, []);

    function removeActivity(id)
    {
        setActivities(activities.filter((activity) => activity.id !== id));
    }

    function addActivity(value)
    {
        setActivities(
            activities.concat([
                {
                    id: value.id,
                    registrationDate: value.registrationDate,
                    lastActivity: value.lastActivity
                }
            ])
        );
    }

    function sendActivities()
    {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(activities)
        };
        fetch('http://localhost:1422/api/UserActivities', requestOptions)
            .then(response => response)
            .then(data => console.log(data));
    }

    return (
        <div>
            <table>
                <THead />
                {activities.map(activity => {
                    return <TBody activity={activity} key={activity.id} onDelete={removeActivity}/>
                })}
            </table>
            <AddUserActivities onCreate={addActivity} />
            <Button onClick={ sendActivities }>Save</Button>
        </div>
        
    );
};

export default UserActivities;