using ElectronicCashier.Utils;

namespace ElectronicCashier.Screens
{
    internal class StartScreen
    {        
        private LogInScreen logInScreen = new LogInScreen();
        private RegisterScreen registerScreen = new RegisterScreen();
        public void StartScreenVisual()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("- 1. LogIn.                              -");
            Console.WriteLine("- 2. Register.                           -");
            Console.WriteLine("------------------------------------------");
        }
        public void StartScreenFunction()
        {
            
            if(!File.Exists(Constants.path))
                File.Create(Constants.path);

            int selectedOption = int.Parse(Console.ReadLine());

            switch (selectedOption)
            {
                case 1:
                    {
                        logInScreen.LogInScreenVisual();
                        logInScreen.LogInScreenFunction();
                    }
                    break;

                case 2:
                    {
                        registerScreen.RegisterScreenVisual();
                        registerScreen.RegisterScreenFunction();
                    }
                    break;

                default:
                    {
                        StartScreenVisual();
                        StartScreenFunction();
                    }
                    break;
            }
        }
    }
}
