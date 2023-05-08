using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpMangWebApp.Models.DbEntity
{
	public class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Column(TypeName ="varchar(50)")]
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
	
    }
}
