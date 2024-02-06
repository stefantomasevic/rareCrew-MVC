using Newtonsoft.Json;
using TrackingEmployees.Models;

namespace TrackingEmployees.Repository
{
    public class EmployeeApiService:IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync()
        
        {
            // HTTP client
            var apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
            var response = await _httpClient.GetStringAsync(apiUrl);

            // Deserijalizacija odgovora u listu zaposlenih
            var employees = JsonConvert.DeserializeObject<List<Employee>>(response);

            var groupedEmployeesWithHours = employees
            .Where(e => e.StarTimeUtc <= e.EndTimeUtc)
            .GroupBy(e => e.EmployeeName)
            .Select(group => new EmployeeViewModel
            {
                Id = group.First().Id,
                EmployeeName = group.Key,
                TotalHours = group.Sum(e => (e.EndTimeUtc - e.StarTimeUtc).TotalHours)
            })
            .Select(viewModel =>
            {
                // Zaokruži ukupne sate na ceo broj
                viewModel.TotalHours = (int)Math.Round(viewModel.TotalHours);
                return viewModel;
            });
      

            return groupedEmployeesWithHours;
            
        }
    }
}
