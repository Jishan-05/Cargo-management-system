using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoApi.Models
{
    [Table("admin")]
    public partial class Admin
    {
        [Key]
        [Column("Admin_id")]
        public int AdminId { get; set; }

        [Column("Admin_name")]
        [StringLength(45)]
        [Unicode(false)]
        public string AdminName { get; set; } = null!;

        [Column("Admin_pass")]
        [StringLength(10)]
        [Unicode(false)]
        public string AdminPass { get; set; } = null!;
    }

}
