using ElectronicCashier.DTOs;
using ElectronicCashier.Utils;
using Newtonsoft.Json;

namespace ElectronicCashier.Screens
{
    internal class MainScreen
    {
        private WriteJson writeJson = new WriteJson();
        private ReadJson readJson = new ReadJson();
        private TransactionsScreen transactionScreen = new TransactionsScreen();
        public void MainScreenVisual()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("- 1. Deposit money.                      -");
            Console.WriteLine("- 2. Extract money.                      -");
            Console.WriteLine("- 3. Show all transactions.              -");
            Console.WriteLine("------------------------------------------");
        }
        public void MainScreenFunction(string creditCardNumber)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(readJson.ReadJsonFile(Constants.pathUsers));
            User user = GetUserFromList(users, creditCardNumber);
            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    {
                        Console.WriteLine("How much money you wish to deposit?");
                        double depositedMoney = double.Parse(Console.ReadLine());
                        SaveChangesToFiles(user, user.amountOfMoney + depositedMoney, users, Constants.pathUsers);
                        MainScreenFunction(creditCardNumber);
                    }
                    break;

                case "2":
                    {
                        Console.WriteLine("How much money you wish to extract?");
                        double extractedMoney = double.Parse(Console.ReadLine());
                        CheckAmountOfMoney(extractedMoney, user);
                        SaveChangesToFiles(user, user.amountOfMoney - extractedMoney, users, Constants.pathUsers);
                        MainScreenFunction(creditCardNumber);
                    }
                    break;

                case "3":
                    {
                        transactionScreen.ShowAllTransactions();
                    }
                    break;
                default:
                        MainScreenFunction(creditCardNumber);
                    break;
            }
        }

        private void SaveChangesToFiles(User user, double money, List<User> users, string path)
        {
            UpdateUserMoney(user, users, money);
            writeJson.WriteJsonFile(users, path);
            //Crear una transacción y escribirla en el json
        }

        private void CheckAmountOfMoney(double extractedMoney, User user)
        {
            if (extractedMoney > user.amountOfMoney)
            {
                Console.WriteLine("You don't have enough money.");
                MainScreenFunction(user.creditCardNumber);
            }
        }

        private void UpdateUserMoney(User user, List<User> users, double money)
        {
            RemoveUserFromList(users);
            User updatedUser = new User(
                user.name,
                user.creditCardNumber,
                user.cardPIN,
                money
                );
            users.Add(updatedUser);
        }

        private void RemoveUserFromList(List<User> users)
        {
            users.RemoveAll(user => user.creditCardNumber == user.creditCardNumber);
        }

        private User GetUserFromList(List<User> users, string creditCardNumber)
        {
            return users.Where(user => user.creditCardNumber == creditCardNumber).First();
        }
    }
}