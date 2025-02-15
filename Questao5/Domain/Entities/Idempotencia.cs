using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("idempotencia")]
    public class Idempotencia
    {
        [Key]
        [Column("chave_idempotencia")]
        public string ChaveIdempotencia { get; set; }

        [StringLength(1000)]
        [Column("requisicao")]
        public string Requisicao { get; set; }

        [StringLength(1000)]
        [Column("resultado")]
        public string Resultado { get; set; }
    }
}
