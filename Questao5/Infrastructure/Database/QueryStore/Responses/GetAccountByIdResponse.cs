namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public sealed class GetAccountByIdResponse
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}