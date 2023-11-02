using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.aug30.librarymgmt.Models
{
    public class EMemberInformation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string FullName { get; set; }
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string ContactNo { get; set; }
        [StringLength(250)]
        [Column(TypeName = "varchar(250)")]
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
