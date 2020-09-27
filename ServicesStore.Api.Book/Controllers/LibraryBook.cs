using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesStore.Api.Book.App;

namespace ServicesStore.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryBookController : ControllerBase
    {
        private readonly IMediator mediator;

        public LibraryBookController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> NewBook(BookNew.RequestBookNew newBook)
        {
            return await mediator.Send(newBook);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibraryBookDto>>> GetListBooks()
        {
            return await mediator.Send(new BookGetList.RequestBookGetList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryBookDto>> GetListBooks(Guid id)
        {
            return await mediator.Send(new BookGet.RequestBookGet { LibraryBookGuid = id });
        }
    }
}
