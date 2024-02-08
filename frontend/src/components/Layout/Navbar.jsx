export const Navbar = () => {
  return (
    <div className="navbar bg-base-100">
      <div className="flex-1">
        <a className="btn btn-ghost text-xl">daisyUI</a>
      </div>
      <div className="flex-none">
        <a href="/signin" className="btn btn-primary">
          Sign In
        </a>
      </div>
    </div>
  );
};
