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
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Cliente GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public bool VerifyEmail(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .Any(c => c.Email.Equals(email));
            }
        }

        public bool VerifyCpf(string cpf)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Clientes
                    .Any(c => c.Cpf.Equals(cpf));
            }
        }
    }
}