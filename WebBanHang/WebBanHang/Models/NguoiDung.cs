//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NguoiDung
    {
        public string IDNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public Nullable<System.DateTime> DoB { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string IDChucVu { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
    }
}
