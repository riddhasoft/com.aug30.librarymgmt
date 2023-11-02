using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.aug30.librarymgmt.Models
{
    public class EBookCategory
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string Code { get; set; }
        [StringLength(50)]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
    }
}
