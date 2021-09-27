import React, { useState } from "react";
import Button from "./ui/button/Button";
import Input from "./ui/input/Input";

const AddUserActivities = ({ onCreate }) => {
  const [userId, setUserId] = useState("");
  const [registrationDate, setregistrationDate] = useState("");
  const [lastActivity, setlastActivity] = useState("");

  function submitHandler(event) {
    event.preventDefault();

    if (userId.trim() && registrationDate.trim()) {
      const value = {
        id: userId,
        registrationDate: registrationDate,
        lastActivity: lastActivity,
      };
      onCreate(value);
    }
  }

  return (
    <form className="add-user-activities" onSubmit={submitHandler}>
      <Input
        type="number"
        min="1"
        value={userId}
        onChange={(event) => setUserId(event.target.value)}
      />
      <Input
        type="date"
        value={registrationDate}
        onChange={(event) => setregistrationDate(event.target.value)}
      />
      <Input
        type="date"
        min={registrationDate}
        max={new Date().toJSON().split("T")[0]}
        value={lastActivity}
        onChange={(event) => setlastActivity(event.target.value)}
      />
      <Button type="submit">Добавить</Button>
    </form>
  );
};

export default AddUserActivities;
