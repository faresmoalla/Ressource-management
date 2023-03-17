using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nasxxum.Enlightenment.API.Controllers;
using Naxxum.Enlightenment.Application.Handlers.Command;
using Naxxum.Enlightenment.Domain.Entities;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Naxxum.Enlightenment.Application.DTOs.Auth;
using Naxxum.Enlightenment.Application.DTOs.Users;
using Naxxum.Enlightenment.Domain.Shared;
namespace Naxxum.Enlightenment.API.Controllers
{
    public class ClientController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ISender _sender;
        public ClientController(IMediator mediator, ISender sender)
        {
            _mediator = mediator;
            _sender = sender;
        }

        [HttpPost("registration")]
        [Produces(typeof(Client))]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> Create(CreateClientCommand command )
        {
            return await _sender.Send(command); 
        }


    }
}
