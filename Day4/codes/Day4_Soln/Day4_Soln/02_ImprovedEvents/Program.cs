namespace _02_ImprovedEvents
{
    delegate void BalanceHandler(Account acc, BalanceEventArgs e);
    class BalanceEventArgs : EventArgs
    {
        public double TxAmmount { get; set; }
        public DateTime TxTime { get; set; }
    }
    class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public double Balance { get; set; }
        private event BalanceHandler _lowBalance = null;
        public event BalanceHandler LowBalance
        {
            add { _lowBalance += value; }
            remove { _lowBalance -= value; }
        }
        public void Deposit(double ammount)
        {
            this.Balance += ammount;
        }
        public void WithDraw(double ammount)
        {
            if (ammount > Balance)
            {
                if (_lowBalance != null)
                {
                    BalanceEventArgs e = new BalanceEventArgs()
                    {
                        TxAmmount = ammount,
                        TxTime = DateTime.Now
                    };
                    _lowBalance(this, e);

                }
            }
            else
                this.Balance -= ammount;
        }

        public override string ToString()
        {
            return $"Id = {Id} , Type = {Type} Balance = {Balance}";
        }
    }
    class HdfcBank
    {
        public void SendLowBalanceSMS(Account acc, BalanceEventArgs e)
        {
            string msg = $"Account with {acc} failed to withdraw {e.TxAmmount} at {e.TxTime}";
            Console.WriteLine(msg);
        }
        public void TestTrasactions()
        {
            Account acc = new Account() { Id = 1, Type = "Savings", Balance = 2000.00 };
            acc.LowBalance += SendLowBalanceSMS;
            Console.WriteLine("Account with init state" + acc);
            acc.Deposit(500);
            Console.WriteLine("After deposit(500)" + acc);
            acc.WithDraw(1000);
            Console.WriteLine("After WithDraw(1500)" + acc);
            acc.WithDraw(2000);
            Console.WriteLine("After WithDraw(2000)" + acc);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HdfcBank hdfcBank = new HdfcBank();
            hdfcBank.TestTrasactions();
        }
    }
}
