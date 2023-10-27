using AutoMapper;
using LGApi.Entities;
using LGApi.Interfaces;
using LGApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LGApi.Controllers;

public class ContaController : Controller
{
    private readonly IContaRepository contaRepository;
    private readonly IMapper mapper;
    
    public ContaController(IContaRepository contaRepository, IMapper mapper)
    {
        this.contaRepository = contaRepository;
        this.mapper = mapper;
    }
    
    [HttpGet("ObterTodasContas")]
    public async Task<ActionResult<IEnumerable<ContaModel>>> GetAll()
    {
        var contas = await contaRepository.GetAll();
        return Ok(contas);
    }
    
    [HttpGet("ObterContaPorId/{id}")]
    public async Task<ActionResult<ContaModel>> GetById(int id)
    {
        var conta = await contaRepository.GetById(id);

        if (conta == null)
            return NotFound();
        
        return Ok(conta);
    }

    [HttpPost("NovaConta")]
    public async Task<ActionResult<ContaModel>> Post([FromBody] ContaModel contaModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        await contaRepository.Add(mapper.Map<Conta>(contaModel));
        return Created("", contaModel);
    }

    [HttpPut("AtualizarConta/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ContaModel contaModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (id != contaModel.Id)
            return BadRequest();

        var conta = contaRepository.GetById(id).Result;

        if (conta == null)
            return NotFound();

        await contaRepository.Update(mapper.Map<Conta>(contaModel));

        return NoContent();
    }

    [HttpDelete("ExcluirConta/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var conta = contaRepository.GetById(id).Result;

        if (conta == null)
            return NotFound();

        await contaRepository.Delete(conta);

        return NoContent();
    }
}