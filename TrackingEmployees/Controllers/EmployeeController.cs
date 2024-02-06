using Microsoft.AspNetCore.Mvc;
using TrackingEmployees.Repository;

namespace TrackingEmployees.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();
                return View(employees);
            }
            catch (Exception ex)
            {
                // Obrada grešaka, npr. logovanje ili vraćanje odgovarajuće greške klijentu
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
