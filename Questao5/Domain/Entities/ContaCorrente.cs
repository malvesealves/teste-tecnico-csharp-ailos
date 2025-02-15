using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("contacorrente")]
    public class ContaCorrente
    {
        [Key]
        [Column("idcontacorrente")]
        public string IdContaCorrente { get; set; }
        
        [Required]
        [Column("numero")]
        public long Numero { get; set; }
        
        [Required]
        [Column("nome")]
        public string Nome { get; set; }
        
        [Required]
        [DefaultValue(false)]
        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
