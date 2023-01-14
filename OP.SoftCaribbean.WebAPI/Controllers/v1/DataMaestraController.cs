using Microsoft.AspNetCore.Mvc;
using OP.SoftCaribbean.Application.Features.DataMaestra.Commands.CreateDataMasterCommand;
using OP.SoftCaribbean.Application.Features.DataMaestra.Commands.DeleteDataMasterCommand;
using OP.SoftCaribbean.Application.Features.DataMaestra.Commands.UpdateDataMasterCommand;
using OP.SoftCaribbean.Application.Features.DataMaestra.Queries.GetAllDataMasterQuery;
using OP.SoftCaribbean.Application.Features.DataMaestra.Queries.GetDataMasterByIdQuery;

namespace OP.SoftCaribbean.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DataMaestraController : BaseApiController
    {
        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllDataMasterParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllDataMasterQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                nmdato = filter.nmdato,
                nmmaestro = filter.nmmaestro,
                cddato = filter.cddato,
                dsddato = filter.dsddato,
                cddato1 = filter.cddato1,
                cddato2 = filter.cddato2,
                cddato3 = filter.cddato3,
                feregistro = filter.feregistro,
                febaja = filter.febaja
            }));
        }

        //GET api/<controller>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetDataMasterByIdQuery { nmdato = id }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDataMasterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/3
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, UpdateDataMasterCommand command)
        {
            if (id != command.nmdato)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            return Ok(await Mediator.Send(new DeleteDataMasterCommand { nmdato = id }));
        }
    }
}