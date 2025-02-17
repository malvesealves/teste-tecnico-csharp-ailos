using System.ComponentModel;

namespace Questao5.Domain.Enumerators
{
    public enum TransactionType
    {
        [Description("Crédito")]
        C,
        [Description("Débito")]
        D
    }
}
