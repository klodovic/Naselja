using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackTask_API.Model
{
    public class CreateNaseljeDTO
    {
        [Required]
        public int PostanskiBroj { get; set; }

        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "Max lenght is 25 character only ")]
        public string Naziv { get; set; }

        [ForeignKey(nameof(Drzava))]
        public int DrzavaId { get; set; }
    }

    public class NaseljeDTO : CreateNaseljeDTO
    {
        public int Id { get; set; }
        public DrzavaDTO Drzava { get; set; }
    }
}
