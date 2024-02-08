import { useDayTimeStore } from "../store/useDayTimeStore";
import { BsSunrise, BsSun, BsMoon } from "react-icons/bs";

export const DayTime = () => {
  const { selectedTime, setSelectedTime } = useDayTimeStore();

  const getIconOpacity = (time) => {
    return selectedTime === time ? "opacity-100" : "opacity-30";
  };

  return (
    <div className="flex justify-center gap-3">
      <button
        className={`${getIconOpacity("morning")}`}
        onClick={() => setSelectedTime("morning")}
      >
        <BsSunrise size={25} />
      </button>
      <button
        className={`${getIconOpacity("noon")}`}
        onClick={() => setSelectedTime("noon")}
      >
        <BsSun size={25} />
      </button>
      <button
        className={`${getIconOpacity("night")}`}
        onClick={() => setSelectedTime("night")}
      >
        <BsMoon size={22} />
      </button>
    </div>
  );
};
