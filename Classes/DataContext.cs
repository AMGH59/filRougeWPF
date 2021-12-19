using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Techno> Technos { get; set; }
        public DbSet<Topic> Topics { get; set; }
        private static DataContext instance = null;

        public DataContext() : base() { }

        public static DataContext Instance
        {
            get {
                if (instance == null)
                    instance = new DataContext();
                return instance;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\coursDotNet;Integrated Security=True");
        }
    }
}
