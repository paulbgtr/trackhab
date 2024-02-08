import { SignUpForm } from "../components/routesComponents/signup/SignUpForm";

const SignUp = () => {
  return (
    <div className="hero min-h-screen">
      <div className="hero-content text-center">
        <div className="max-w-md">
          <SignUpForm />
        </div>
      </div>
    </div>
  );
};

export default SignUp;
