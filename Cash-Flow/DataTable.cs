//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cash_Flow
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataTable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
    
        public virtual User User { get; set; }
        public virtual TransactionType TransactionType1 { get; set; }
    }
}