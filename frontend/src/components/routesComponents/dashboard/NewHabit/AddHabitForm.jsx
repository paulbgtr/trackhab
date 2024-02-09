import { useState } from "react";

export const AddHabitForm = () => {
  const [title, setTitle] = useState("");
  const [time, setTime] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    console.log(title, time);
  };

  return (
    <form onSubmit={handleSubmit} className="grid gap-3">
      <input
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        type="text"
        placeholder="Habit Title"
        className="input w-full"
      />
      <select
        value={time}
        onChange={(e) => setTime(e.target.value)}
        className="select w-full"
      >
        <option>Morning</option>
        <option>Afternoon</option>
        <option>Evening</option>
      </select>
      <button className="btn">Add Habit</button>
    </form>
  );
};
