using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BPT.Test.ACC.Core.Entities
{
    [Table("AssigmentStudents")]
    public class AssigmentStudentsCls
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public StudentCls Student { get; set; }

        public int AssigmentId { get; set; }
        public AssignmentsCls Assignment { get; set; }

    }
}
