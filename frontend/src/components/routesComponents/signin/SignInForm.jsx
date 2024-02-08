import { useState } from "react";
import { useNavigate } from "react-router-dom";

export const SignInForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const navigate = useNavigate();

  const fetchSignUp = async (email, password) => {
    const res = await fetch("http://localhost:3000/signup", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ email, password }),
    });

    return res;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    setError("");

    const res = await fetchSignUp(email, password);

    switch (res.status) {
      case 201:
        return navigate("/dashboard");
      case 400:
        return setError("Invalid email or password.");
      default:
        return setError("Something went wrong. Please try again.");
    }
  };

  return (
    <div className="card w-96 shadow-md">
      <form
        onSubmit={handleSubmit}
        className="card-body items-center text-center"
      >
        <h2 className="card-title">Sign In</h2>
        <a href="/signup" className="mb-2 text-sm link">
          Don&apos;t have an account?
        </a>
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          placeholder="Email"
          className="input input-bordered w-full max-w-xs"
        />
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          placeholder="Password"
          className="input input-bordered w-full max-w-xs"
        />
        <button className="btn btn-primary my-2">Sign In</button>
        {error && <p className="text-red-500">{error}</p>}
      </form>
    </div>
  );
};
