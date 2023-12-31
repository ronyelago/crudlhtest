namespace LGApi.Models;

public class ContaModel
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor {get; set; } = 0;
    public bool Ativa { get; set; }
    public string? Observacoes { get; set; }
    public int DiaVencimento { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime DataExpiracao { get; set; }
}