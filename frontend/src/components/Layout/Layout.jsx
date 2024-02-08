import { Navbar } from "./Navbar";

export const Layout = ({ navbar, children, className }) => {
  return (
    <>
      {navbar && <Navbar />}
      <div className={`${className}`}>
        <div className="grid mx-auto px-5 py-3 max-w-4xl">{children}</div>
      </div>
    </>
  );
};
