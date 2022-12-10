using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rehber.Entity
{
    public class Kisiler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string KisiNum { get; set; }

        [StringLength(50)]
        [Required]
        public string KisiAd { get; set; }

        [StringLength(50)]
        [Required]
        public string KisiSoyad { get; set; }
    }
}
