using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Cash_Flow.Models
{

    public class DataTableViewModel
    {
        public int Id { get; set; }
        public string Csv { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Value")]
        public decimal Value { get; set; }
        [Display(Name = "Transaction Type")]
        public int TransactionTypeId { get; set; }
        [Display(Name = "Transaction Type")]
        public string TransactionTypeName { get; set; }
    }
}