using EmpMangWebApp.Models.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace EmpMangWebApp.Data
{
	public class EmployeeContext : DbContext
	{
		public EmployeeContext(DbContextOptions options) : base(options)
		{
	
		}

		public DbSet<Employee> Employees { get; set; }
	}



}
