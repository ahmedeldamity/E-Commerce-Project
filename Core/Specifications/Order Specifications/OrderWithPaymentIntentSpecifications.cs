using Core.Entities.Order_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Order_Specifications
{
    public class OrderWithPaymentIntentSpecifications: BaseSpecification<Order>
    {
        public OrderWithPaymentIntentSpecifications(string paymentIntentId)
        {
            WhereCriteria = O => O.PaymentIntentId == paymentIntentId;
        }
    }
}
