using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebDemo.Models.Entity_Framework
{
    [Table("Table_SystemSetting")]
    public class SystemSetting
    {
        [Key]
        [StringLength(50)]
        public String SettingKey { get; set; }

        [StringLength(4000)]
        public String SettingValue { get; set; }

        [StringLength(4000)]
        public String SettingDescription { get; set; }

    }
}