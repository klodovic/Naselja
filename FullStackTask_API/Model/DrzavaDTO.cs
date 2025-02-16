using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackTask_API.Model
{
    public class CreateDrzavaDTO
    {
        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "Max lenght is 25 character only ")]
        public string Naziv { get; set; }
    }

    public class DrzavaDTO : CreateDrzavaDTO 
    {
        public int Id { get; set; }
    }
}
