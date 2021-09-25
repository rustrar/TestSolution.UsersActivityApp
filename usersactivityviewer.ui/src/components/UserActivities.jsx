import React, { useEffect } from 'react';
import Button from "./ui/button/Button";
import axios from "axios";

const UserActivities = function () {

    useEffect(() => {
        fetchUserActivities();
    }, []);
    
    async function fetchUserActivities() {
        const response = await axios.get("http://localhost:1422/api/");
    }

    return (
        <div>            
            <table>
                <thead>
                    <tr>
                        <th>UserID</th>
                        <th>Date Registration</th>
                        <th>Date Last Activity</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>10.10.2018</td>
                        <td>10.11.2018</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>11.10.2019</td>
                        <td>11.11.2019</td>
                    </tr>
                </tbody>
            </table>
            <Button disabled>Save</Button>
            <Button onClick={fetchUserActivities}>Get</Button>
        </div>
        
    );
};

export default UserActivities;