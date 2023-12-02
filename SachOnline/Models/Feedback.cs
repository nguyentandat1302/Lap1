using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SachOnline.Models
{

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDFeedback { get; set; }

        public int? MaKH { get; set; }

        [Column("Feedback")]
        [StringLength(255)]
        public string Feedback1 { get; set; }

        public int Rating { get; set; }

        public virtual  KHACHHANG KHACHHANG { get; set; }
    }
}