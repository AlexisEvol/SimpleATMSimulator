using ElectronicCashier.DTOs;
using ElectronicCashier.Utils;
using Newtonsoft.Json;

namespace ElectronicCashier.Screens
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
            List<User> usersList = LoadListFromFile();
            foreach (User user in usersList)
            {
                CheckIfUserExists(creditCardNumber, pin, user);
            }
            
        }

        private List<User> LoadListFromFile()
        {
            string jsonString = readJson.ReadJsonFile(Constants.pathUsers);
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return usersList;
        }
        private void CheckIfUserExists(string creditCardNumber, string pin, User user)
        {
            if (user.creditCardNumber.Equals(creditCardNumber) && user.cardPIN.Equals(pin))
            {
                mainScreen.MainScreenVisual();
                mainScreen.MainScreenFunction(creditCardNumber);
            }
            else
            {
                Console.WriteLine("The card you tried to login with doesn't exist or the PIN is wrong.");
                LogInScreenFunction();
            }
        }
    }
}
