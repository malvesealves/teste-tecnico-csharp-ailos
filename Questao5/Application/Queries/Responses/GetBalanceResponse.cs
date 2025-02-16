namespace Questao5.Application.Queries.Responses
{
    public sealed class GetBalanceResponse
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTimeOffset QueryDateTime { get; set; }
        public double Balance { get; set; }
    }
}
