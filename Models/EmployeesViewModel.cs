using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpMangWebApp.Models
{
	public class EmployeesViewModel
	{

		public int Id { get; set; }
		[DisplayName ( " Full Name")]
		public string Name { get; set; }
		[DisplayName(" Email")]
		public string Email { get; set; }
		[DisplayName(" Address ")]
		public string Address { get; set; }
		[DisplayName(" City")]
		public string City { get; set; }
	}
}
