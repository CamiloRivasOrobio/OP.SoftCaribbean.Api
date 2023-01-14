using Microsoft.AspNetCore.Mvc;
using OP.SoftCaribbean.Application.Features.Personas.Commands.CreatePeopleCommand;
using OP.SoftCaribbean.Application.Features.Personas.Commands.DeletePeopleCommand;
using OP.SoftCaribbean.Application.Features.Personas.Commands.UpdatePeopleCommand;
using OP.SoftCaribbean.Application.Features.Personas.Queries.GetAllPeopleQuery;
using OP.SoftCaribbean.Application.Features.Personas.Queries.GetPeopleByIdQuery;

namespace OP.SoftCaribbean.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonasController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPeopleParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPeopleQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                nmid = filter.nmid,
                cddocumento = filter.cddocumento,
                dsnombres = filter.dsnombres,
                dsapellidos = filter.dsapellidos,
                fenacimiento = filter.fenacimiento,
                cdtipo = filter.cdtipo,
                cdgenero = filter.cdgenero,
                cdusuario = filter.cdusuario,
                dsdireccion = filter.dsdireccion,
                cdtelefonoFijo = filter.cdtelefonoFijo,
                cdtelefonoMovil = filter.cdtelefonoMovil,
                dsemail = filter.dsemail,
                feregistro = filter.feregistro,
                febaja = filter.febaja
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPeopleByIdQuery { nmid = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePeopleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdatePeopleCommand command)
        {
            if (id != command.nmid)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePeopleCommand { nmid = id }));
        }
    }
}