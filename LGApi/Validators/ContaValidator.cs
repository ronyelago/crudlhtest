using FluentValidation;
using LGApi.Models;

namespace LGApi.Validators;

public class ContaValidator : AbstractValidator<ContaModel>
{
    public ContaValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Descricao).NotEmpty().MinimumLength(3).MaximumLength(64);
        RuleFor(x => x.Valor).NotEmpty().GreaterThan(0);
        RuleFor(x => x.DiaVencimento).InclusiveBetween(1, 31);
        RuleFor(x => x.Observacoes).MaximumLength(64);
        RuleFor(x => x.DataExpiracao).GreaterThanOrEqualTo(DateTime.Now);
        RuleFor(x => x.DataVencimento).GreaterThanOrEqualTo(DateTime.Now);
    }
}