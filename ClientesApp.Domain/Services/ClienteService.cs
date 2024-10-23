using ClientesApp.Domain.Dtos;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repository;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Valiations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Services
{
    /// <summary>
    /// Implementação da interface de servicos de dominio
    /// </summary>
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public ClienteResponseDto Incluir(ClienteRequestDto dto)
        {
            #region Capturar e validdasr os dados do cliente 

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
                Ativo = true
            };

            var clienteValidator = new ClienteValidation();
            var result = clienteValidator.Validate(cliente);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion


            #region Não permitir a inclusão de clientes com o mesmo email

            if (this.clienteRepository.VerifyEmail(dto.Email, cliente.Id))
                throw new ApplicationException("O email informado já está cadastrado para outro cliente.");

            #endregion

            #region Não permitir a inclusão de clientes com o mesmo cpf

            if (this.clienteRepository.VerifyCpf(dto.Cpf, cliente.Id))
                throw new ApplicationException("O cpf informado já está cadastrado para outro cliente.");

            #endregion

            #region Validar e realizar o cadastro do cliente

            

            this.clienteRepository.Add(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            #endregion
        }


        public ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto)
        {
            #region Buscar o cliente no banco de dados atravez do Id

            var cliente = this.clienteRepository.GetById(id);
            if (cliente == null)
                throw new ApplicationException("CLiente não encontrado, verifique o Id informado ");
            #endregion

            #region Capturar e validdasr os dados do cliente 

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.Cpf = dto.Cpf;
            cliente.DataUltimaAlteracao = DateTime.Now;        
            

            var clienteValidator = new ClienteValidation();
            var result = clienteValidator.Validate(cliente);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion


            #region Não permitir a inclusão de clientes com o mesmo email

            if (this.clienteRepository.VerifyEmail(dto.Email, cliente.Id))
                throw new ApplicationException("O email informado já está cadastrado para outro cliente.");

            #endregion

            #region Não permitir a inclusão de clientes com o mesmo cpf

            if (this.clienteRepository.VerifyCpf(dto.Cpf, cliente.Id))
                throw new ApplicationException("O cpf informado já está cadastrado para outro cliente.");

            #endregion

            #region Validar e realizar o cadastro do cliente



            this.clienteRepository.Update(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            #endregion
        }

        public ClienteResponseDto Excluir(Guid id)
        {
            #region Buscar o cliente no banco de dados atravez do Id

            var cliente = this.clienteRepository.GetById(id);
            if (cliente == null)
                throw new ApplicationException("CLiente não encontrado, verifique o Id informado ");
            #endregion

            #region Inativar o registro do cliente

            cliente.Ativo = false;
            cliente.DataUltimaAlteracao = DateTime.Now;

            this.clienteRepository.Update(cliente);

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            #endregion
        }

        public List<ClienteResponseDto> Consultar()
        {

            var response = new List<ClienteResponseDto>();

            var clientes = this.clienteRepository.GetAll();

            foreach(var item in clientes)
            {
                response.Add(new ClienteResponseDto {

                    Id = item.Id,
                    Nome = item.Nome,
                    Email = item.Email,
                    Cpf = item.Cpf,
                    DataInclusao = item.DataInclusao,
                    DataUltimaAlteracao = item.DataUltimaAlteracao

                });
            }

            return response;
        }

        public ClienteResponseDto ObterPorId(Guid id)
        {
            var cliente = this.clienteRepository.GetById(id);
            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado, verifique o ID informado.");

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };
        }
    }
}

