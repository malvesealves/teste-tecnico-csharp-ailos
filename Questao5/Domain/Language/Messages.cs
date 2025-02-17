namespace Questao5.Domain.Language
{
    public static class Messages
    {
        #region Transaction

        #endregion
        public const string Transaction_IdempotencyKeyRequired = "Cabeçalho Idempotency-Key é obrigatório";
        public const string Transaction_InvalidIdempotency = "Chave de idempotência inválida";

        public const string Transaction_Succeeded = "Movimentação realizada com sucesso";

        public const string Transaction_InvalidAccount = "Apenas contas correntes cadastradas podem receber movimentação";
        public const string Transaction_InactiveAccount = "Apenas contas correntes ativas podem receber movimentação";
        public const string Transaction_InvalidValue = "Apenas valores positivos podem ser recebidos";
        public const string Transaction_InvalidType = "Apenas os tipos “débito” ou “crédito” podem ser aceitos";

        #region Balance
        public const string Balance_Succeeded = "Consulta de saldo realizada com sucesso";

        public const string Balance_InvalidAccount = "Apenas contas correntes cadastradas podem consultar o saldo";
        public const string Balance_InactiveAccount = "Apenas contas correntes ativas podem consultar o saldo";
        #endregion
    }
}
