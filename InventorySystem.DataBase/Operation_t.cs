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
    
    public partial class Operation_t
    {
        public int Id { get; set; }
        public int Sell_Id { get; set; }
        public int product_id { get; set; }
        public int Operation_type_Id { get; set; }
        public Nullable<System.DateTime> last_update_date { get; set; }
        public Nullable<System.DateTime> creation_Date { get; set; }
        public string last_user_update { get; set; }
    
        public virtual Product_t Product_t { get; set; }
        public virtual Operation_type_t Operation_type_t { get; set; }
        public virtual Sell_t Sell_t { get; set; }
    }
}