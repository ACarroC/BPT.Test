using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BPT.Test.ACC.Core.Entities
{
    [Table("AssigmentsTbl")]
    public class AssignmentsCls
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<AssigmentStudentsCls> AssigmentStudents { get; set; }
    }
}
