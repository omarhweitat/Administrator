using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Domain.Moduls
{
    [Table("DEPARTMENT")]
    public class DEPARTMENT
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal DEPARTMENT_ID { get; set; }

        [Required]
        [StringLength(400)]
        public string DEPARTMENT_DESC { get; set; }
       
    }
}
