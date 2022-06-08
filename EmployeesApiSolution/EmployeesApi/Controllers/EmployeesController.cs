namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{
    private readonly ILookupEmployees _employeeLookup;

    public EmployeesController(ILookupEmployees employeeLookup)
    {
        _employeeLookup = employeeLookup;
    }

    [HttpGet("/employees")]
    public async Task<ActionResult<CollectionResponse<EmployeeSummaryResponse>>> GetEmployeesCollectionAsync()
    {

        List<EmployeeSummaryResponse> data = await  _employeeLookup.GetAllEmployeeSummariesAsync();

        var response = new CollectionResponse<EmployeeSummaryResponse> { Data = data };
        return Ok(response);
    }

    [HttpGet("/employees/{id:bsonid}")]
    public async Task<ActionResult<EmployeeDocumentResponse>> GetEmployeeByIdAsync(string id)
    {
       
        EmployeeDocumentResponse response = await _employeeLookup.GetEmployeeByIdAsync(id);
        if (response == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }
}
