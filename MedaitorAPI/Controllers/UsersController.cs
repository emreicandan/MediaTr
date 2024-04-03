using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedaitorAPI.Features.UserFeature.Commands;
using MedaitorAPI.Features.UserFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedaitorAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediatR;

        public UsersController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediatR.Send(new UserListQuery());

            return Ok(result);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediatR.Send(new UserGetByIdQuery(id));
            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddUserCommand command)
        {
            var result = await _mediatR.Send(command);
            return Ok(result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command )
        {
            var result = await _mediatR.Send(command);
            return Ok(result);
        }


        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _mediatR.Send(new DeleteUserCommand(id));
            return Ok("Transaction Successful");
        }
    }
}

