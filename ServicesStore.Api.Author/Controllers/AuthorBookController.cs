using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesStore.Api.Author.App;
using ServicesStore.Api.Author.Model;

namespace ServicesStore.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBookController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthorBookController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(NewAuthorBook.Execute author)
        {
            return await mediator.Send(author);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorBookDto>>> Get()
        {
            return await mediator.Send(new GetListAuthorBook.ListAuthorBook());
        }

        [HttpDelete]
        public async Task<ActionResult<Unit>> Delete(AuthorBookDelete.AuthorBookDeleteRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBookDto>> GetAuthorBook(string id)
        {
            return await mediator.Send(new GetAuthorById.Request { AuthorBookGuid = id });
        }
    }
}
