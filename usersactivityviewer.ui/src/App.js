import React from "react";
import Button from "./components/Button";
import UserActivities from "./components/UserActivities";
import "./styles/App.css";

function App() {
  return (
    <div className="App">
      <UserActivities />
      <Button text={"Calculate"}></Button>
    </div>
  );
}

export default App;
