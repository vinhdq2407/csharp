using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BanHangTTCS.Models.Metadata
{  
    [MetadataTypeAttribute(typeof(ThanhVienMetadata))]

    public partial class ThanhVien
    {
        internal sealed class ThanhVienMetadata
        {
            public int MaThanhVien { get; set; }
            [Required(ErrorMessage = "{0} Không được để trống")]
            [StringLength(10, ErrorMessage = "Không được quá 10 ký tự")]
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public string HoTen { get; set; }
            public string DiaChi { get; set; }
            public string Email { get; set; }
            public string SoDT { get; set; }
            public string CauHoi { get; set; }
            public string CauTraLoi { get; set; }
            public Nullable<int> MaLoaiTV { get; set; }
        }
    }
}