using Localiza.Frotas.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository veiculosRepository;
        private readonly IVeiculoDetran veiculoDetran;

        public VeiculosController(IVeiculoRepository veiculosRepository, IVeiculoDetran veiculoDetran)
        {
            this.veiculosRepository = veiculosRepository;
            this.veiculoDetran = veiculoDetran;
        }

        [HttpGet]
        public IActionResult Get() => Ok(veiculosRepository.GetAll());

        [HttpGet("Id")]
        public IActionResult Get(Guid Id)
        {
            var veiculo = veiculosRepository.GetById(Id);
            if (veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            veiculosRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut]
        public IActionResult Put(Guid Id, [FromBody] Veiculo veiculo)
        {
            veiculosRepository.Update(veiculo);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            var veiculo = veiculosRepository.GetById(Id);
            if (veiculo == null)
                return NotFound();

            veiculosRepository.Delete(veiculo);
            return NoContent();
        }

        [HttpPut("{id}/vistoria")]
        public IActionResult Put(Guid id)
        {
            veiculoDetran.AgendarVistoriaDetran(id);
            return NoContent();
        }
    }
}
