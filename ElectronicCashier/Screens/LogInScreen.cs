using SimpleATM.Objects;
using SimpleATM.Utils;
using Newtonsoft.Json;

namespace SimpleATM.Screens
{
    internal class LogInScreen
    {
        private ReadJson readJson = new ReadJson();
        private MainScreen mainScreen = new MainScreen();
        public void LogInScreenVisual()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("- Write the card number you registered.  -");
            Console.WriteLine("- Write the PIN you registered.          -");
            Console.WriteLine("------------------------------------------");
        }
        public void LogInScreenFunction()
        {
            string creditCardNumber = Console.ReadLine();
            string pin = Console.ReadLine();
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(readJson.ReadJsonFile(Constants.pathUsers));
            if (usersList != null)
            {
                bool accountExists = CheckIfUserExists(creditCardNumber, pin, usersList, usersList.Count) == true;
                if (accountExists == false)
                {
                    Console.WriteLine("The credit card number or the PIN aren't correct");
                    LogInScreenFunction();
                }
            }
            else
            {
                Console.WriteLine("There aren't any accounts registered, be the first one!");
                LogInScreenFunction();
            }

        }
        private bool CheckIfUserExists(string creditCardNumber, string pin, List<User> usersList, int amountUsers)
        {
            foreach (User user in usersList)
            {
                if (user.creditCardNumber.Equals(creditCardNumber) && user.cardPIN.Equals(pin))
                {
                    mainScreen.MainScreenVisual();
                    mainScreen.MainScreenFunction(creditCardNumber);
                    return true;
                }
            }
            return false;
        }
    }
}
