namespace ElectronicCashier.DTOs
{
    internal class Transaction
    {
        public string creditCardNumber { get; set; }
        public double money { get; }
        public string date { get; }
        public string typeTransaction { get; }
    }
}
