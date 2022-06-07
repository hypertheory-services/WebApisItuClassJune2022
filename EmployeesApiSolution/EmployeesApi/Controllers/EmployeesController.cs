namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{

    [HttpGet("/employees/{id}")]
    public async Task<ActionResult<EmployeeDocumentResponse>> GetEmployeeByIdAsync(string id)
    {
        if(int.Parse(id) > 100)
        {
            return NotFound();
        }
        var response = new EmployeeDocumentResponse
        {
            Id = id,
            Name = new EmployeeNameInformation { FirstName = "Bob", LastName = "Smith" },
            Department = "DEV"

        };
        return Ok(response);
    }
}
