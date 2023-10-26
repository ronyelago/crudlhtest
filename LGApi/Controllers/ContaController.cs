using LGApi.Entities;
using LGApi.Interfaces;
using LGApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LGApi.Controllers;

public class ContaController : Controller
{
    private readonly IContaRepository contaRepository;
    
    public ContaController(IContaRepository contaRepository)
    {
        this.contaRepository = contaRepository;
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
        await contaRepository.Add(new Conta
        {
            Descricao = contaModel.Descricao,
            Valor = contaModel.Valor,
            Ativa = true,
            Observacoes = contaModel.Observacoes,
            DiaVencimento = contaModel.DiaVencimento,
            DataVencimento = contaModel.DataVencimento.ToUniversalTime(),
            DataCadastro = DateTime.Now.ToUniversalTime(),
            DataExpiracao = contaModel.DataExpiracao.ToUniversalTime()
        });
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