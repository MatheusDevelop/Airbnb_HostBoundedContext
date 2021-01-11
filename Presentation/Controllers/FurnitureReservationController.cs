using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.Request;
using Domain.Commands.Result;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureReservationController : ControllerBase
    {   
        [HttpPost]
        public ActionResult<FurnitureReservationResult> Post(
            [FromBody] FurnitureReservationRequest command,
            [FromServices] IMediator mediator
        )
        {
            var res = mediator.Send(command);
            if(res.Result.Errors.Count > 0)
            {
                return BadRequest(res.Result.Errors);
            }
            return Ok(res.Result);
        }
    }
}
