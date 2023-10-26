using LGApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LGApi.Controllers;

public class ContaController : Controller
{
    [HttpGet("ObterTodasContas")]
    public async Task<ActionResult<IEnumerable<ContaModel>>> Get()
    {
        return Ok();
    }
    
    [HttpGet("ObterContaPorId/{id}")]
    public async Task<ActionResult<ContaModel>> Get()
    {
        return Ok();
    }

    [HttpPost("NovaConta")]
    public async Task<ActionResult<ContaModel>> Post([FromBody] ContaModel contaModel)
    {
        return Created("", contaModel);
    }

    [HttpPut("AtualizarConta")]
    public async Task<IActionResult> Put([FromBody] ContaModel contaModel)
    {
        return NoContent();
    }

    [HttpDelete("ExcluirConta/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }
}