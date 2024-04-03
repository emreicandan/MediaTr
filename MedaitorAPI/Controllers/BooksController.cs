using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedaitorAPI.Features.BookFeature.Commands;
using MedaitorAPI.Features.BookFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace MedaitorAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IMediator _mediatR;

        public BooksController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        // GET: api/values
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatR.Send(new BookListQuery());

            return Ok(result);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediatR.Send(new BookGetByIdQuery(id));

            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddBookCommand command)
        {
            var result = await _mediatR.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody]UpdateBookCommand command)
        {
            var result = await _mediatR.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediatR.Send(new DeleteBookCommand(id));
            return Ok(result);
        }
    }
}

