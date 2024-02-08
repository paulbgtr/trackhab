export const Habit = ({ title, isDone }) => {
  return (
    <div className={`rounded-xl min-w-xl shadow-md px-7 py-5`}>
      <div className="flex justify-between">
        <div className="my-3 mx-4">
          <h3
            className={`${
              isDone && "line-through text-gray-500"
            } font-bold text-xl`}
          >
            {title}
          </h3>
        </div>
        <input type="checkbox" className="checkbox mt-5 checkbox-lg" />
      </div>
    </div>
  );
};
