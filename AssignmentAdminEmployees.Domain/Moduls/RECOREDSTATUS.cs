using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Domain.Moduls
{
    [Table("RECOREDSTATUS")]
    public class RECOREDSTATUS
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal RECORED_STATUS_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string RECORED_STATUS_DESC { get; set; }

        
    }
}
