using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesStore.Api.ShopingCart.App;

namespace ServicesStore.Api.ShopingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<ActionResult<Unit>> Create(ShoppingCartNew.ShoppingCartRequest request) =>
            await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoShoppingCart>> Get(int id)
        {
            return await _mediator.Send(new DtoQuery.Request { ShopingCartSessionId = id });
        }
    }
}
