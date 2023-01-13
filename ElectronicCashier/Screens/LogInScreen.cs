using ElectronicCashier.DTOs;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

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
            CheckIfUserExists(usersList, creditCardNumber, pin);
            /*foreach(User user in usersList)
            {
                if (user.creditCardNumber.Equals(creditCardNumber) && user.cardPIN.Equals(pin))
                {
                    mainScreen.MainScreenVisual();
                    mainScreen.MainScreenFunction(user);
                }
            }
            Console.WriteLine("The card you tried to login with doesn't exist or the PIN is wrong.");
            LogInScreenVisual();
            LogInScreenFunction();*/
        }

        private List<User> LoadListFromFile()
        {
            string jsonString = readJson.ReadJsonFile();
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return usersList;
        }
        private void CheckIfUserExists(List<User> usersList, string creditCardNumber, string pin)
        {
            foreach (User user in usersList)
            {
                if (user.creditCardNumber.Equals(creditCardNumber) && user.cardPIN.Equals(pin))
                {
                    mainScreen.MainScreenVisual();
                    mainScreen.MainScreenFunction(user);
                }
            }
            Console.WriteLine("The card you tried to login with doesn't exist or the PIN is wrong.");
            LogInScreenVisual();
            LogInScreenFunction();
        }
    }
}
