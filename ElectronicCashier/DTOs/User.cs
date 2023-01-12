namespace ElectronicCashier.DTOs
{
    internal class User
    {
        public string name { get; }
        public string cardNumber { get; }
        public int cardPIN { get; }
        public double amountOfMoney { get; }
        public List<Transaction> transactions { get; }
    }
}