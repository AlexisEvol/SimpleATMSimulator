using SimpleATM.Objects;

namespace SimpleATM.Utils
{
    internal class SaveChanges
    {
        private WriteJson writeJson = new WriteJson();
        private UserListTools userListTools = new UserListTools();

        public void SaveChangesToFiles(User user, double money, List<User> users, List<Transaction> transactions, string typeTransaction, double transactionMoney)
        {
            UpdateUserMoney(user, users, money);
            writeJson.WriteJsonFile(users, Constants.pathUsers);

            if (transactions == null)
                transactions = new List<Transaction>();

            AddTransactionToList(transactions, typeTransaction, user.creditCardNumber, transactionMoney);
            writeJson.WriteJsonFile(transactions, Constants.pathTransactions);
        }

        private void UpdateUserMoney(User user, List<User> users, double money)
        {
            userListTools.RemoveUserFromList(users, user.creditCardNumber);
            User updatedUser = new User(
                user.name,
                user.creditCardNumber,
                user.cardPIN,
                money
                );
            users.Add(updatedUser);
        }

        private void AddTransactionToList(List<Transaction> transactions, string typeTransaction, string creditCardNumber, double money)
        {
            Transaction transaction = new Transaction(
            creditCardNumber,
            money,
            DateTime.Now.ToString(),
            typeTransaction
            );
            transactions.Add(transaction);
        }
    }
}
