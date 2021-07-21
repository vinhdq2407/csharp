﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanHangTTCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            this.DanhGias = new HashSet<DanhGia>();
            this.KhachHangs = new HashSet<KhachHang>();
        }
    
        public int MaThanhVien { get; set; }
        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(10,ErrorMessage ="Không được quá 10 ký tự")]
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDT { get; set; }
        public string CauHoi { get; set; }
        public string CauTraLoi { get; set; }
        public Nullable<int> MaLoaiTV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual LoaiThanhVien LoaiThanhVien { get; set; }
    }
}