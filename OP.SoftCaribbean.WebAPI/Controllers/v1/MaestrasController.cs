using Microsoft.AspNetCore.Mvc;
using OP.SoftCaribbean.Application.Features.Maestras.Commands.CreateTeachersCommand;
using OP.SoftCaribbean.Application.Features.Maestras.Commands.DeleteTeachersCommand;
using OP.SoftCaribbean.Application.Features.Maestras.Commands.UpdateTeachersCommand;
using OP.SoftCaribbean.Application.Features.Maestras.Queries.GetAllTeachersQuery;
using OP.SoftCaribbean.Application.Features.Maestras.Queries.GetTeacherByIdQuery;

namespace OP.SoftCaribbean.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MaestrasController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTeachersParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllTeachersQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                nmmaestro = filter.nmmaestro,
                cdmaestro = filter.cdmaestro,
                dsmaestro = filter.dsmaestro,
                feregistro = filter.feregistro,
                febaja = filter.febaja
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetTeacherByIdQuery { nmmaestro = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTeachersCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, UpdateTeachersCommand command)
        {
            if (id != command.nmmaestro)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new DeleteTeachersCommand { nmmaestro = id }));
        }
    }
}