using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models.Entity_Framework
{
    [Table("Table_Contact")]
    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 kí tự")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 kí tự")]
        public string Website { get; set; }
        [StringLength(50, ErrorMessage = "Không được vượt quá 50 kí tự")]
        public string Email { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}