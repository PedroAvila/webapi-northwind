namespace Prueba.Persistencia
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dept")]
    public partial class Dept
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DEPTNO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string DNAME { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string LOC { get; set; }
    }
}
