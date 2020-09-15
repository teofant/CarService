using CS.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Context
{
    public class MainContext : IdentityDbContext<IdentityUser>
    {
        public MainContext() { }

        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constr = "workstation id=CarService.mssql.somee.com;packet size=4096;user id=teofant_SQLLogin_1;pwd=9ip2gfdswm;data source=CarService.mssql.somee.com;persist security info=False;initial catalog=CarService";
            optionsBuilder.UseSqlServer(constr);
        }

        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<HistoryStatus> HistoryStatuses { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerRepair> OwnerRepairs { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairStatus> RepairStatuses { get; set; }
    }
}
