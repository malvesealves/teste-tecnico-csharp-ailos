using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    [Table("contacorrente")]
    public sealed class Account
    {
        [Key]
        [Column("idcontacorrente")]
        public string AccountId { get; set; }

        [Required]
        [Column("numero")]
        public long Number { get; set; }

        [Required]
        [Column("nome")]
        public string Name { get; set; }

        [Required]
        [Column("ativo")]
        public AccountStatus Active { get; set; }
    }
}
