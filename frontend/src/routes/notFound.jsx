const NotFound = () => {
  return (
    <div className="hero min-h-screen">
      <div className="hero-content text-center">
        <div className="max-w-md">
          <h1 className="text-5xl font-bold">404</h1>
          <p className="py-6">The page you are looking for does not exist.</p>
          <a className="btn btn-primary" href="/dashboard">
            Go Home
          </a>
        </div>
      </div>
    </div>
  );
};

export default NotFound;
