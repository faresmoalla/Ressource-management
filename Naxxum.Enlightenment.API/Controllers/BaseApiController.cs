using MediatR;
using Microsoft.AspNetCore.Mvc;
using Naxxum.Enlightenment.Domain.Shared;

namespace Nasxxum.Enlightenment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected IActionResult HandleResult<T>(OperationResult<T> result)
    {
        if (!result.IsSuccess)
            return BadRequest(result.Error);

        if (result.Data is Unit)
            return Ok();

        return Ok(result.Data);
    }
}