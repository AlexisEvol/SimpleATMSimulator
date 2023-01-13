using ElectronicCashier.DTOs;
using Newtonsoft.Json;

namespace ElectronicCashier.Screens
{
    internal class RegisterScreen
    {
        private ReadJson readJson = new ReadJson();
        private WriteJson writeJson = new WriteJson();
        private LogInScreen logInScreen = new LogInScreen();
        public void RegisterScreenVisual()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("- First write the card number (Don't use your real one please) -");
            Console.WriteLine("- Second you'll need to write your PIN.                        -");
            Console.WriteLine("- Lastly your name will be asked.                              -");
            Console.WriteLine("----------------------------------------------------------------");
        }

        public void RegisterScreenFunction()
        {
            string creditCardNumber = Console.ReadLine();
            string pinNumber = Console.ReadLine();
            string username = Console.ReadLine();
            double amountMoney = 0;
            var newUser = new User(
                username,
                creditCardNumber,
                pinNumber,
                amountMoney,
                new List<Transaction> {}
            );

            string jsonString = readJson.ReadJsonFile();
            List<User> usersList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            
            if (usersList != null)
            {
                CheckCreditCardExistance(usersList, newUser);
                usersList.Add(newUser);
                writeJson.WriteJsonFile(usersList);
                RedirectToLogIn();
            }
            else
            {
                usersList = new List<User>();
                usersList.Add(newUser);
                writeJson.WriteJsonFile(usersList);
                RedirectToLogIn();
            }
        }

        private void CheckCreditCardExistance(List<User> usersList, User newUser)
        {
            foreach (User user in usersList)
            {
                if (user.creditCardNumber.Equals(newUser.creditCardNumber))
                {
                    Console.Clear();
                    Console.WriteLine("This credit card is already registered, please use a new one.");
                    RegisterScreenVisual();
                    RegisterScreenFunction();
                }
            }
        }

        private void RedirectToLogIn()
        {
            logInScreen.LogInScreenVisual();
            logInScreen.LogInScreenFunction();
        }
    }
}
