//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventorySystem.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category_t
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category_t()
        {
            this.Product_t = new HashSet<Product_t>();
        }
    
        public int category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> last_update_date { get; set; }
        public Nullable<System.DateTime> creation_Date { get; set; }
        public string last_user_update { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_t> Product_t { get; set; }
    }
}
