using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Domain.Moduls
{
    [Table("GENDER")]
    public class GENDER
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal GENDER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string GENDER_DESC { get; set; }
    }
}
