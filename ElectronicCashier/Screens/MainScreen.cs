using SimpleATM.Objects;
using SimpleATM.Utils;
using Newtonsoft.Json;

namespace SimpleATM.Screens
{
    internal class MainScreen
    {
        private ReadJson readJson = new ReadJson();
        private TransactionsScreen transactionScreen = new TransactionsScreen();
        private UserListTools userListTools = new UserListTools();
        private SaveChanges saveChanges = new SaveChanges();
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
            List<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(readJson.ReadJsonFile(Constants.pathTransactions));

            User user = userListTools.GetUserFromList(users, creditCardNumber);
            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    {
                        Console.WriteLine("How much money you wish to deposit?");
                        double depositedMoney = double.Parse(Console.ReadLine());
                        MoneyErrorHandler(depositedMoney, user);
                        double newMoney = user.amountOfMoney + depositedMoney;
                        saveChanges.SaveChangesToFiles(user, newMoney, users, transactions, "deposited", depositedMoney);
                        MainScreenFunction(creditCardNumber);
                    }
                    break;

                case "2":
                    {
                        Console.WriteLine("How much money you wish to extract?");
                        double extractedMoney = double.Parse(Console.ReadLine());
                        MoneyErrorHandler(extractedMoney, user);
                        CheckAmountOfMoney(extractedMoney, user);
                        double newMoney = user.amountOfMoney - extractedMoney;
                        saveChanges.SaveChangesToFiles(user, newMoney, users, transactions, "extracted", extractedMoney);
                        MainScreenFunction(creditCardNumber);
                    }
                    break;

                case "3":
                    {
                        transactionScreen.ShowAllTransactions(user.creditCardNumber);
                        MainScreenFunction(creditCardNumber);
                    }
                    break;
                default:
                        MainScreenFunction(creditCardNumber);
                    break;
            }
        }

        private void CheckAmountOfMoney(double extractedMoney, User user)
        {
            if (extractedMoney > user.amountOfMoney)
            {
                Console.WriteLine("You don't have enough money.");
                MainScreenFunction(user.creditCardNumber);
            }
        }

        private void MoneyErrorHandler(double money, User user)
        {
            if (money < 0)
            {
                Console.WriteLine("Please, don't write a negative number.");
                MainScreenFunction(user.creditCardNumber);
            }
        }
    }
}