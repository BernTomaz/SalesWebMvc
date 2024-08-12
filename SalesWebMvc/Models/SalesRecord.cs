using SalesWebMvc.Models.Enums;
using System;



namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(double amount, DateTime date, int id, SaleStatus status, Seller seller)
        {
            Amount = amount;
            Date = date;
            Id = id;
            Status = status;
            Seller = seller;
        }
    }
}
