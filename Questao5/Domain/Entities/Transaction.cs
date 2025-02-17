using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("movimento")]
    public sealed class Transaction
    {
        [Key]
        [Column("idmovimento")]
        public string TransactionId { get; set; }

        [Required]
        [ForeignKey("idcontacorrente")]
        [Column("idcontacorrente")]
        public string AccountId { get; set; }

        [Required]
        [Column("datamovimento")]
        public string TransactionDate { get; set; }

        [Required]
        [MaxLength(1)]
        [RegularExpression("C|D")]
        [Column("tipomovimento")]
        public TransactionType TransactionType { get; set; }
        
        [Required]
        [Column("valor")]
        public double Value { get; set; }
    }
}
