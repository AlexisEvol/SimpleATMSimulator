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
            if (usersList != null)
            {
                bool accountExists = CheckIfUserExists(creditCardNumber, pin, usersList, usersList.Count) == true;
                if (accountExists == false)
                {
                    Console.WriteLine("XD");
                }
            }
            else
            {
                Console.WriteLine("There aren't any accounts registered, be the first one!");
                LogInScreenFunction();
            }

        }

        private List<User> LoadListFromFile()
        {
            string jsonString = readJson.ReadJsonFile(Constants.pathUsers);
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return usersList;
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
