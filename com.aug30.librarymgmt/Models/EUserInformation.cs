using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.aug30.librarymgmt.Models
{
    public class EUserInformation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Column(TypeName = "varchar(150)")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [StringLength(150), MinLength(8)]
        [Column(TypeName = "varchar(150)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
