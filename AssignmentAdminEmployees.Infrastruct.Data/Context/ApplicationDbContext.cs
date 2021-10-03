using AssignmentAdminEmployees.Domain.Moduls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Infrastruct.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GENDER> GENDERS{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EMPLOYEE> EMPLOYEES { get; set; }
        public DbSet<STATUS> STATUS { get; set; }
        public DbSet<RECOREDSTATUS> RECOREDSTATUSES { get; set; }
        public DbSet<DEPARTMENT> DEPARTMENTS { get; set; }

    }
}
