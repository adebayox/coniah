using System;
using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Debt> Debts { get; set; }
    }
}

