namespace Questao5.Application.Responses
{
    public sealed class BalanceResponse
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Balance { get; set; }

        public BalanceResponse(int number, string name, string date, string balance)
        {
            Number = number;
            Name = name;
            Date = date;
            Balance = balance;
        }        
    }
}
