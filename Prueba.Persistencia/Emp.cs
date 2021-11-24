namespace Prueba.Persistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emp")]
    public partial class Emp
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [StringLength(50)]
        public string EMPNO { get; set; }

        [StringLength(50)]
        public string ENAME { get; set; }

        [StringLength(50)]
        public string JOB { get; set; }

        [StringLength(50)]
        public string MGR { get; set; }

        public DateTime? HIREDATE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SAL { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string COMM { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string DEPTNO { get; set; }
    }
}
