using Microsoft.EntityFrameworkCore;
using Sprout.Exam.WebApp.Model;
using System.Xml;

namespace Sprout.Exam.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
