import { Layout } from "../components/Layout/Layout";
import { DayTime } from "../components/routesComponents/dashboard/DayTime";
import { HabitList } from "../components/routesComponents/dashboard/HabitList";

const Dashboard = () => {
  return (
    <Layout navbar>
      <h1 className="font-bold text-3xl">Hey, User!</h1>
      <DayTime />
      <HabitList />
    </Layout>
  );
};

export default Dashboard;
