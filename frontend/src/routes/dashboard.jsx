import { Layout } from "../components/Layout/Layout";
import { DayTime } from "./DayTime";

const Dashboard = () => {
  return (
    <Layout navbar>
      <h1 className="font-bold text-3xl">Hey, User!</h1>
      <DayTime />
    </Layout>
  );
};

export default Dashboard;
