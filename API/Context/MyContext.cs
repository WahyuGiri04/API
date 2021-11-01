using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    { 
        public MyContext(DbContextOptions<MyContext> options) : base (options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relasi one to one
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.account)
                .WithOne(b => b.employee)
                .HasForeignKey<Account>(b => b.NIK);
            //Relasi one to one
            modelBuilder.Entity<Account>()
                .HasOne(a => a.profiling)
                .WithOne(b => b.account)
                .HasForeignKey<Profiling>(b => b.NIK);
            //Relasi Many to One
            modelBuilder.Entity<Education>()
               .HasMany(c => c.profilings)
               .WithOne(e => e.education);
            //Relasi Many to One
            modelBuilder.Entity<University>()
               .HasMany(c => c.educations)
               .WithOne(e => e.university);

            modelBuilder.Entity<AccountRole>()
                .HasKey(bc => new { bc.NIK, bc.RoleId });
            modelBuilder.Entity<AccountRole>()
                .HasOne(bc => bc.Account)
                .WithMany(b => b.AccountRole)
                .HasForeignKey(bc => bc.NIK);
            modelBuilder.Entity<AccountRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.AccountRole)
                .HasForeignKey(bc => bc.RoleId);
            /* //Many to many
             modelBuilder.Entity<AccountRole>()
                 .HasKey(ac => new { ac.NIK, ac.RoleId });
             modelBuilder.Entity<AccountRole>()
                 .HasOne(ac => ac.Account)
                 .WithMany(acc => acc.AccountRole)
                 .HasForeignKey(acc => acc.NIK);
             modelBuilder.Entity<AccountRole>()
                 .HasOne(ac => ac.Role)
                 .WithMany(r => r.AccountRole)
                 .HasForeignKey(r => r.RoleId);*/
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
