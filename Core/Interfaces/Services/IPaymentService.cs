using Core.Entities.Basket_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Basket?> CreateOrUpdatePaymentIntent(string basketId);
    }
}
