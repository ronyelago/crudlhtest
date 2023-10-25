namespace LGApi.Entities;

public class Conta
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor {get; set; } = 0;
    public bool Ativa { get; set; }
    public string? Observacoes { get; set; }
    public int DiaVencimento { get; set; }
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataExpiracao { get; set; }
}
