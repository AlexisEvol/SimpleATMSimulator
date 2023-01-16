namespace ElectronicCashier.DTOs
{
    internal class User
    {
        public string name { get; }
        public string creditCardNumber { get; }
        public string cardPIN { get; }
        public double amountOfMoney { get; }

        public User(string name, string creditCardNumber, string cardPIN, double amountOfMoney)
        {
            this.name = name;
            this.creditCardNumber = creditCardNumber;
            this.cardPIN = cardPIN;
            this.amountOfMoney = amountOfMoney;
        }
    }
}