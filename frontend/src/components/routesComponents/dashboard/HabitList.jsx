import { Habit } from "./Habit";
import { NewHabit } from "./NewHabit/NewHabit";

export const HabitList = ({ dayTime }) => {
  return (
    <div className="max-w-xl">
      <div className="grid gap-3">
        <Habit title="wash" />
        <NewHabit />
      </div>
    </div>
  );
};
