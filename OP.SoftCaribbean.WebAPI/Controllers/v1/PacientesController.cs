using Microsoft.AspNetCore.Mvc;
using OP.SoftCaribbean.Application.Features.Pacientes.Commands.CreatePatientsCommand;
using OP.SoftCaribbean.Application.Features.Pacientes.Commands.DeletePatientsCommand;
using OP.SoftCaribbean.Application.Features.Pacientes.Commands.UpdatePatientsCommand;
using OP.SoftCaribbean.Application.Features.Pacientes.Queries.GetAllPatientsQuery;
using OP.SoftCaribbean.Application.Features.Pacientes.Queries.GetPatientByIdQuery;

namespace OP.SoftCaribbean.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PacientesController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPatientsParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPatientsQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                nmid = filter.nmid,
                nmidPersona = filter.nmidPersona,
                nmidMedicotra = filter.nmidMedicotra,
                dseps = filter.dseps,
                dsarl = filter.dsarl,
                cdusuario = filter.cdusuario,
                dscondicion = filter.dscondicion,
                feregistro = filter.feregistro,
                febaja = filter.febaja
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPatientByIdQuery { nmid = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdatePatientsCommand command)
        {
            if (id != command.nmid)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePatientsCommand { nmid = id }));
        }
    }
}