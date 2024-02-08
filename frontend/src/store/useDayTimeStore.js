import { create } from "zustand";

export const useDayTimeStore = create((set) => ({
  selectedTime: "morning",
  setSelectedTime: (time) => set({ selectedTime: time }),
}));
