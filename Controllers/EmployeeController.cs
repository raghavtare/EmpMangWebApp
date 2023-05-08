using EmpMangWebApp.Data;
using EmpMangWebApp.Models;
using EmpMangWebApp.Models.DbEntity;
using Microsoft.AspNetCore.Mvc;

namespace EmpMangWebApp.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly EmployeeContext _context;

		public EmployeeController(EmployeeContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var employees = _context.Employees.ToList();
			List<EmployeesViewModel> employeesList = new List<EmployeesViewModel>();
			if (employees != null)
			{
				foreach (var employee in employees)
				{
					var EmployeesViewModel = new EmployeesViewModel()
					{
						Id = employee.Id,
						Name = employee.Name,
						Address = employee.Address,
						City = employee.City,
						Email = employee.Email

					};
					employeesList.Add(EmployeesViewModel);

				}
				return View(employeesList);
			}
			return View(employeesList);
		}


		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Create(EmployeesViewModel employeeData)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var employee = new Employee()
					{
						Name = employeeData.Name,
						Email = employeeData.Email,
						Address = employeeData.Address,
						City = employeeData.City


					};
					_context.Employees.Add(employee);
					_context.SaveChanges();
					TempData["successMessage"] = " Employee created successfully";
					return RedirectToAction("Index");
				}
				else
				{

					TempData["errorMessage"] = " model is not valid";
					return View();
				}
			}
			catch (Exception e)
			{
				TempData["errorMessage"] = e.Message;

				return View();
			}
		}

		[HttpGet]
		public IActionResult Edit(int Id)
		{
			try
			{
				var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);

				if (employee != null)
				{
					var employeesView = new EmployeesViewModel()
					{
						Id = employee.Id,
						Name = employee.Name,
						Email = employee.Email,
						Address = employee.Address,
						City = employee.City

					};
					return View(employeesView);
				}
				else
				{
					TempData["errorMessage"] = $"Employee details not this Id {Id}";
					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				TempData["errorMessage"] = e.Message;
				return RedirectToAction("Index");

			}
		}

		[HttpPost]
		public IActionResult Edit(EmployeesViewModel Model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var employee = new Employee()
					{

						Id = Model.Id,
						Name = Model.Name,
						Email = Model.Email,
						Address = Model.Address,
						City = Model.City,


					};
					_context.Employees.Update(employee);
					_context.SaveChanges();
					TempData["sucessMessage"] = " update successfully";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["errorMessage"] = " Model data is Invalid";
					return View();
				}


			}
			catch (Exception e)
			{
				TempData["errorMessage"] = e.Message;
				return View();
			}
		}

		[HttpGet]
		public IActionResult Delete(int Id)
		{
			try
			{
				var employee = _context.Employees.SingleOrDefault(x => x.Id == Id);

				if (employee != null)
				{
					var employeesView = new EmployeesViewModel()
					{
						Id = employee.Id,
						Name = employee.Name,
						Email = employee.Email,
						Address = employee.Address,
						City = employee.City

					};
					return View(employeesView);
				}
				else
				{
					TempData["errorMessage"] = $"Employee details not this Id {Id}";
					return RedirectToAction("Index");
				}
			}
			catch (Exception e)
			{
				TempData["errorMessage"] = e.Message;
				return RedirectToAction("Index");

			}
		}

		[HttpPost]
		public IActionResult Delete(EmployeesViewModel model)
		{
			try
			{
				var employee = _context.Employees.SingleOrDefault(x=> x.Id==model.Id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
					_context.SaveChanges();
					TempData["sucessMessage"] = " update successfully";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["errorMessage"] = " Model data is Invalid";
					return RedirectToAction("Index");
				}

			}
			catch (Exception e){

				TempData["errorMessage"] = e.Message;
				return View();
			}
		}   
	}
}
