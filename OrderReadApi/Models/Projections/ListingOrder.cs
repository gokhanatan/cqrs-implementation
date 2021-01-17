using System;
using MongoDB.Bson;

namespace OrderReadApi.Models.Projections
{
    public class ListingOrder
    {
        public ObjectId _id { get; set; }
        public string OrderId { get; set; }
        public string Code { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}