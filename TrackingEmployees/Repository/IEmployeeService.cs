using TrackingEmployees.Models;

namespace TrackingEmployees.Repository
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync();
    }
}
