using SimpleATM.Objects;
using SimpleATM.Utils;
using Newtonsoft.Json;

namespace SimpleATM.Screens
{
    internal class TransactionsScreen
    {
        private ReadJson readJson = new ReadJson();
        public void ShowAllTransactions(string creditCardNumber)
        {
            int transactionsCounter = 0;
            string transactionJson = readJson.ReadJsonFile(Constants.pathTransactions);
            List<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(transactionJson);
            if (transactions != null)
            {
                foreach (Transaction transaction in transactions)
                {
                    if (transaction.creditCardNumber.Equals(creditCardNumber))
                    {
                        Console.WriteLine($"You have {transaction.typeTransaction} a total of {transaction.money} $ on the {transaction.date}.");
                        transactionsCounter++;
                    }
                }
            }
            if(transactionsCounter == 0)
                Console.WriteLine("You haven't realized any transaction.");
        }
    }
}
