using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("movimento")]
    public sealed class Movement
    {
        [Key]
        [Column("idmovimento")]
        public string MovementId { get; set; }

        [Required]
        [ForeignKey("idcontacorrente")]
        [Column("idcontacorrente")]
        public string AccountId { get; set; }

        [Required]
        [Column("datamovimento")]
        public string MovementDate { get; set; }

        [Required]
        [MaxLength(1)]
        [RegularExpression("C|D")]
        [Column("tipomovimento")]
        public MovementType MovementType { get; set; }
        
        [Required]
        [Column("valor")]
        public double Value { get; set; }
    }
}
