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
    
    public partial class SanPham
    {
        public string IDSanPham { get; set; }
        public string TenSanPham { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public int GiaSanPham { get; set; }
        public string MoTa { get; set; }
        public string ThongTin { get; set; }
        public string IDNhomSanPham { get; set; }
    
        public virtual NhomSanPham NhomSanPham { get; set; }
    }
}
