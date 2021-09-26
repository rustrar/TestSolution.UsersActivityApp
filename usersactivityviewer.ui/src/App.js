import React from "react";
import RollingRetentionCalculator from "./components/RollingRetentionCalculator";
import UserActivities from "./components/UserActivities";
import "./styles/App.css";

function App() {
  return (
    <div className="App">
      <UserActivities />
      <RollingRetentionCalculator />
    </div>
  );
}

export default App;