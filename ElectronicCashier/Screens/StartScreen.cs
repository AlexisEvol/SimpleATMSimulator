using SimpleATM.Utils;

namespace SimpleATM.Screens
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
            CreateNecessaryFiles();
            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    {
                        logInScreen.LogInScreenVisual();
                        logInScreen.LogInScreenFunction();
                    }
                    break;

                case "2":
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

        private void CreateNecessaryFiles()
        {
            if (!File.Exists(Constants.pathUsers))
            {
                var userFile = File.Create(Constants.pathUsers);
                userFile.Close();
            }
                
            

            if (!File.Exists(Constants.pathTransactions))
            {
                var transactionFile = File.Create(Constants.pathTransactions);
                transactionFile.Close();
            }
        }
    }
}
