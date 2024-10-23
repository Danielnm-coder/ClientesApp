﻿using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repository;
using ClientesApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação do repositorio do bando de dados de cliente 
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        public void Add(Cliente cliente)
        {
           using(var dataContext = new DataContext())
           {
                dataContext.Add(cliente);
                dataContext.SaveChanges();
           }
        }

        public void Update(Cliente cliente)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(cliente);
                dataContext.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using(var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .Where(c => c.Ativo)
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Cliente GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .Where(c => c.Ativo)
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public bool VerifyEmail(string email, Guid clienteid)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .Any(c => c.Email.Equals(email) && c.Id != clienteid);
            }
        }

        public bool VerifyCpf(string cpf, Guid clienteid)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .Any(c => c.Cpf.Equals(cpf) && c.Id != clienteid);
            }
        }
    }
}
