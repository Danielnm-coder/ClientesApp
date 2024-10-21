﻿using ClientesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Repository
{
    /// <summary>
    /// Definição dos metodos abstratos para o repositorio de clientes
    /// </summary>
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        List<Cliente> GetAll();
        Cliente GetById(Guid id);
        bool VerifyEmail(string email);
        bool VerifyCpf(string cpf);
    }
}