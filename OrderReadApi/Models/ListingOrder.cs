using System;
using MongoDB.Bson;

namespace OrderReadApi.Models
{
    public class ListingOrder
    {
        public ObjectId _id { get; set; }
        public string OrderId { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}