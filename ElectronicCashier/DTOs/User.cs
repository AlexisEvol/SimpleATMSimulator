namespace ElectronicCashier.DTOs
{
    internal class User
    {
        public string name { get; }
        public string creditCardNumber { get; }
        public string cardPIN { get; }
        public double amountOfMoney { get; }
        public List<Transaction> transactions { get; }

        public User(string name, string creditCardNumber, string cardPIN, double amountOfMoney, List<Transaction> transactions)
        {
            this.name = name;
            this.creditCardNumber = creditCardNumber;
            this.cardPIN = cardPIN;
            this.amountOfMoney = amountOfMoney;
            this.transactions = transactions;
        }
    }
}