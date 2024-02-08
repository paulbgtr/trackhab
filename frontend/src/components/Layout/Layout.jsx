import { Navbar } from "./Navbar";

export const Layout = ({ navbar, children, className }) => {
  return (
    <>
      {navbar && <Navbar />}
      <div className={`${className}`}>{children}</div>
    </>
  );
};
