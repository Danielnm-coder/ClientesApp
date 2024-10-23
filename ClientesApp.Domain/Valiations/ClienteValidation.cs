using ClientesApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Valiations
{
    /// <summary>
    /// CLasse de validação do FluentValidator para a entidade Cliente
    /// </summary>
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O id do cliente e obrigatorio");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente e obrigatorio")
                .Length(6, 150).WithMessage("O Nome do cliente tem que ter de 6 a 150 caracteres");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email do dliente eobrigatorio")
                .EmailAddress().WithMessage("O email do cliente deve ser um endereço de email valido ");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O cpf do cliente é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O cpf do cliente deve ter exatamente 11 dígitos.");

            RuleFor(c => c.DataInclusao)
                .NotEmpty().WithMessage("A data de inclussão do cliente e obrigatoria");

            RuleFor(c => c.DataUltimaAlteracao)
               .NotEmpty().WithMessage("A data da última alteração do cliente é obrigatória.");

            RuleFor(c => c.Ativo)
                .NotEmpty().WithMessage("A informação de Ativo ou Inativo do cliente é obrigatória.");
        }
    }
}


