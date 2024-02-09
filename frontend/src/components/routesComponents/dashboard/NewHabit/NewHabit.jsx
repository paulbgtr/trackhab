import { useState } from "react";
import { AddHabitForm } from "./AddHabitForm";

export const NewHabit = () => {
  const [isClicked, setIsClicked] = useState(false);

  return (
    <div
      onClick={() => setIsClicked(true)}
      className={` ${
        !isClicked && "duration-200 hover:cursor-pointer hover:opacity-70"
      } 
      rounded-xl min-w-xl border-2 border-dashed border-gray-400 px-7 py-5`}
    >
      {isClicked ? (
        <AddHabitForm />
      ) : (
        <div className="flex justify-between">
          <div className="my-auto mx-4">
            <h3 className={`font-bold text-gray-400`}>New Habit</h3>
          </div>
          <span type="checkbox" className="text-gray-400 text-xl mx-2  my-auto">
            +
          </span>
        </div>
      )}
    </div>
  );
};
