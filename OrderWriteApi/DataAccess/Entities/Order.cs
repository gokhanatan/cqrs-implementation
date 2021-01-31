using System;
using OrderWriteApi.Domain.Core;
using OrderWriteApi.Domain.Events;

namespace OrderWriteApi.DataAccess.Entities
{
    public class Order : AggregateRoot
    {
        private Guid _id;

        public static Order Create(Guid id, string orderCode, int userId, decimal totalPrice)
        {
            var order = new Order()
            {
                _id = id,
                Code = orderCode,
                CreateDate = DateTime.Now,
                TotalPrice = totalPrice,
                UserId = userId,
                Status = "Created"
            };

            order.ApplyChange(new OrderCreatedEvent(id, orderCode, order.CreateDate, userId, totalPrice, "Created"));

            return order;
        }

        public override Guid Id
        {
            get
            {
                return _id;
            }
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case OrderCreatedEvent e:
                    _id = e.Id;
                    Code = e.OrderCode;
                    CreateDate = e.OrderDate;
                    UserId = e.UserId;
                    TotalPrice = e.TotalPrice;
                    Status = e.Status;
                    break;
            }
        }

        public string Code { get; private set; }

        public DateTime CreateDate { get; private set; }

        public int UserId { get; private set; }

        public decimal TotalPrice { get; private set; }

        public string Status { get; private set; }
    }
}