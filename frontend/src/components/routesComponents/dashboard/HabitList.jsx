import { Habit } from "./Habit";

export const HabitList = ({ dayTime }) => {
  return (
    <div className="max-w-xl">
      <div className="grid">
        <Habit title="wash" />
      </div>
    </div>
  );
};
