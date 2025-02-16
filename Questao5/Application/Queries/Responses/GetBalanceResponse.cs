namespace Questao5.Application.Queries.Responses
{
    public sealed class GetBalanceResponse
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public DateTime QueryDateTime { get; set; }
        public double Balance { get; set; }
    }
}
