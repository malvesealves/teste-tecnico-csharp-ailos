namespace Questao5.Domain.Language
{
    public static class ValidationMessage
    {
        const string InvalidAccount = "Apenas contas correntes cadastradas podem receber movimentação";
        const string InactiveAccount = "Apenas contas correntes ativas podem receber movimentação";
        const string InvalidValue = "Apenas valores positivos podem ser recebidos";
        const string InvalidType = "Apenas os tipos “débito” ou “crédito” podem ser aceitos";        
    }
}
