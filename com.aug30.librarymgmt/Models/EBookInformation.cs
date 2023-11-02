using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.aug30.librarymgmt.Models
{
    public class EBookInformation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Publication { get; set; }
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string ISBN { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Barcode { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Author { get; set; }
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Edition { get; set; }
        public int BookCategoryId { get; set; }
        [ValidateNever]
        public virtual EBookCategory BookCategory { get; set; }
    }
}
