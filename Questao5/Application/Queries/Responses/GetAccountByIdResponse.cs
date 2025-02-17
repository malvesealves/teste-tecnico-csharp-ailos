namespace Questao5.Application.Queries.Responses
{
    public sealed record GetAccountByIdResponse(int? Number, string Name, bool? Active);
}
