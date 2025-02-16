using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("idempotencia")]
    public sealed class Idempotency
    {
        [Key]
        [Column("chave_idempotencia")]
        public string IdempotencyKey { get; set; }

        [StringLength(1000)]
        [Column("requisicao")]
        public string Request { get; set; }

        [StringLength(1000)]
        [Column("resultado")]
        public string Result { get; set; }
    }
}
