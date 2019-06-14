namespace WindowsFormsApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WindowsFormsApp1.Model;

    public partial class CodeFirstModel : DbContext
    {
        public CodeFirstModel()
            : base("name=CodeFirstContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
