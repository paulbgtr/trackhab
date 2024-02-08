import { SignInForm } from "../components/routesComponents/signin/SignInForm";

const SignIn = () => {
  return (
    <div className="hero min-h-screen">
      <div className="hero-content text-center">
        <div className="max-w-md">
          <SignInForm />
        </div>
      </div>
    </div>
  );
};

export default SignIn;
