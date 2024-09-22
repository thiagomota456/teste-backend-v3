﻿using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKataAPI.Data
{
    public class ApplicationDbContext  : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Play> Plays { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
