using System;

namespace DailySalesCalculator
{
    public class DailySales
    {
        public string Id => Date.ToString("yyyyMMdd");
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
