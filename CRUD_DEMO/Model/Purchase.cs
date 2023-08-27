using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_DEMO.Model
{
    public class Purchase
    {
        [Key]
        [Column(TypeName ="int")]
        public int ID { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Price { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Itemdescription {get;set;}
    }
}
