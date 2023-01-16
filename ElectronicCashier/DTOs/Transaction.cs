namespace ElectronicCashier.DTOs
{
    internal class Transaction
    {
        public string creditCardNumber { get; set; }
        public double money { get; }
        public string date { get; }
        public string typeTransaction { get; }
        public Transaction(string creditCardNumber, double money, string date, string typeTransaction)
        {
            this.creditCardNumber = creditCardNumber;
            this.money = money;
            this.date = date;
            this.typeTransaction = typeTransaction;
        }
    }
}
