using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_DEMO.Model
{
    public class Registration
    {
        [Key]
        [Column(TypeName ="int")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Empid { get; set; }

        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

    }
}
