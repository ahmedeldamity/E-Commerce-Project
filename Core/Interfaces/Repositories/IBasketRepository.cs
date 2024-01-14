using Core.Entities.Basket_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket?> CreateOrUpdateBasketAsync(Basket basket);
        Task<Basket?> GetBasketAsync(string basketId);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}