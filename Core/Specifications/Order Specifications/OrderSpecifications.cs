using Core.Entities.Order_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Order_Specifications
{
    public class OrderSpecifications: BaseSpecification<Order>
    {
        public OrderSpecifications(string buyerEmail)
        {
            WhereCriteria = P => P.BuyerEmail == buyerEmail;

            IncludesCriteria.Add(P => P.DeliveryMethod);
            IncludesCriteria.Add(P => P.Items);

            OrderByDesc = P => P.OrderDate;
        }

        public OrderSpecifications(string buyerEmail, int orderId)
        {
            WhereCriteria = P => P.BuyerEmail == buyerEmail && P.Id == orderId;

            IncludesCriteria.Add(P => P.DeliveryMethod);
            IncludesCriteria.Add(P => P.Items);
        }
    }
}
