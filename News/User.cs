//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace News
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.BaiViet = new HashSet<BaiViet>();
            this.LSBaiViet = new HashSet<LSBaiViet>();
            this.Role = new HashSet<Role>();
        }
    
        public int ID_User { get; set; }
        public string TenUser { get; set; }
        public string AnhDaiDien { get; set; }
        public string Password { get; set; }
        public string NgheDanh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public Nullable<int> ID_LoaiTK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViet { get; set; }
        public virtual LoaiTK LoaiTK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LSBaiViet> LSBaiViet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Role { get; set; }
    }
}
