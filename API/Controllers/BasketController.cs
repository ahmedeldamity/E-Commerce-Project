using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities.Basket_Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> CreateOrUpdateBasket(BasketDto basketDto)
        {
            var basket = _mapper.Map<BasketDto, Basket>(basketDto);

            var createdOrUpdated = await _basketRepository.CreateOrUpdateBasketAsync(basket);

            if (createdOrUpdated is null) return BadRequest(new ApiResponse(400));

            return Ok(createdOrUpdated);
        }
        
        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new Basket(id));
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}