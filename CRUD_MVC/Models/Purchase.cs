using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Purchase
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Price { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Itemdescription { get; set; }
    }
}
