import React from "react";
import MetricsCalculator from "./components/MetricsCalculator";
import UserActivities from "./components/UserActivities";
import "./styles/App.css";

function App() {
  return (
    <div className="App">
      <UserActivities />
      <MetricsCalculator />
    </div>
  );
}

export default App;