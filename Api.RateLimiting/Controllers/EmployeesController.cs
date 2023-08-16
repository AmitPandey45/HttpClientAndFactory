using Api.RateLimiting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.RateLimiting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = TwoSum(new int[] { 3, 3, 6}, 9);
            return Ok(Task.FromResult(GetEmployeesDetails()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(Task.FromResult(GetEmployeesDetails().FirstOrDefault(w => w.Id == id)));
        }

        private int[] TwoSum(int[] nums, int target)
        {
            var pairs = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (pairs.ContainsKey(target - nums[i]))
                    return new int[] { pairs[target - nums[i]], i };
                else
                    pairs.TryAdd(nums[i], i);

            return default;
        }

        private List<Employee> GetEmployeesDetails()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName= "Test",
                    LastName = "Name",
                    EmailId ="Test.Name@gmail.com"
                },
                new Employee()
                {
                    Id = 2,
                    FirstName= "Test",
                    LastName = "Name1",
                    EmailId ="Test.Name1@gmail.com"
                }
            };
        }
    }
}
