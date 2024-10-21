using ClientesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para conecxão com bando de dados através do EntityFremework
    /// </summary>
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ClientesBD");
        }

        /// <summary>
        /// Operalões com clientes em memoria
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }
    }
}
