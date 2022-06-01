using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoveisPlanejados.Models;

    public class MoveisPlanejadosContext : DbContext
    {
        public MoveisPlanejadosContext (DbContextOptions<MoveisPlanejadosContext> options)
            : base(options)
        {
        }

        public DbSet<MoveisPlanejados.Models.Funcionario> Funcionario { get; set; }

        public DbSet<MoveisPlanejados.Models.Movel> Movel { get; set; }
    }
