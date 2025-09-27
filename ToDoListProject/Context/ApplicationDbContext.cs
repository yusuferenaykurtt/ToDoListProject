using Microsoft.EntityFrameworkCore;

using ToDoListProject.Entity;

using Microsoft.EntityFrameworkCore;


namespace ToDoListProject.Context
{
    public class ApplicationDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("SERVER=MSI\\MSSQLSERVER01;Database=ToDoDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

        }

        public DbSet<ToDo> toDos { get; set; }


    }
}
