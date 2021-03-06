import React from "react";

const TBody = ({ activity, onDelete }) => {
  function formatDate(stringDate) {
    var timestamp = Date.parse(stringDate);

    if (isNaN(timestamp)) {
      return "";
    }

    return new Date(timestamp).toLocaleDateString();
  }

  return (
    <tbody>
      <tr>
        <td>{activity.id}</td>
        <td>{formatDate(activity.registrationDate)}</td>
        <td>{formatDate(activity.lastActivity)}</td>
        <td>
          <button className="delete-btn" onClick={() => onDelete(activity.id)}>
            <svg
              width="14"
              height="16"
              viewBox="0 0 14 16"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="M5.6 0C5.2346 0 4.858 0.123333 4.5934 0.375333C4.3295 0.626667 4.2 0.985333 4.2 1.33333V2H0V3.33333H0.7V14C0.7 15.0967 1.6485 16 2.8 16H11.2C12.3515 16 13.3 15.0967 13.3 14V3.33333H14V2H9.8V1.33333C9.8 0.985333 9.6705 0.626667 9.4059 0.374667C9.142 0.124 8.7661 0 8.4 0H5.6ZM5.6 1.33333H8.4V2H5.6V1.33333ZM2.1 3.33333H11.9V14C11.9 14.37 11.5885 14.6667 11.2 14.6667H2.8C2.4115 14.6667 2.1 14.37 2.1 14V3.33333ZM3.5 5.33333V12.6667H4.9V5.33333H3.5ZM6.3 5.33333V12.6667H7.7V5.33333H6.3ZM9.1 5.33333V12.6667H10.5V5.33333H9.1Z"
                fill="#5D6D97"
              />
            </svg>
          </button>
        </td>
      </tr>
    </tbody>
  );
};

export default TBody;
