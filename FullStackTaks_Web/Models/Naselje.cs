using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackTask_Web.Model
{
    public class Naselje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PostanskiBroj { get; set; }

        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "Max lenght is 25 character only ")]
        public string Naziv { get; set; }

        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }

        [Required]
        public Drzava Drzava { get; set; }

        public DateTime CreatedDate { get; set; }
    }

}
