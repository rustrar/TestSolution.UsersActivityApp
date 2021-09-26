import React from 'react';
import { Bar } from 'react-chartjs-2';

const LifeTimeBar = ({ lifeTime }) => {    

    const labels = Array.from({length: lifeTime.length}, (_, i) => i + 1)
    const data = {
        labels: labels,
        datasets: [
            {
                label: '# of lifetime',
                data: lifeTime,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.2)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1,
            }
          ],
        };
        
        const options = {
        scales: {
            yAxes: [
            {
                ticks: {
                beginAtZero: true,
                },
            },
            ],
        },
        };

    return (
        <div>
            <Bar data={data} options={options} />
        </div>
    );
};

export default LifeTimeBar;
