using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("movimento")]
    public class Movimento
    {
        [Key]
        [Column("idmovimento")]
        public string IdMovimento { get; set; }

        [Required]
        [ForeignKey("idcontacorrente")]
        [Column("idcontacorrente")]
        public string IdContaCorrente { get; set; }

        [Required]
        [Column("datamovimento")]
        public string DataMovimento { get; set; }

        [Required]
        [MaxLength(1)]
        [RegularExpression("C|D")]
        [Column("tipomovimento")]
        public string TipoMovimento { get; set; }
        
        [Required]
        [Column("valor")]
        public double Valor { get; set; }
    }
}
