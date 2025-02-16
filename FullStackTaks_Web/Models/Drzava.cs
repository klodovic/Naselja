using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackTask_Web.Model
{
    public class Drzava
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 25, ErrorMessage = "Max lenght is 25 character only ")]
        public string Naziv { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
