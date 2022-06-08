namespace EmployeesApi.Controllers;

[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly ILookupEmployees _employeeLookup;
    private readonly IManageEmployees _employeeCommands;

    public EmployeesController(ILookupEmployees employeeLookup, IManageEmployees employeeCommands)
    {
        _employeeLookup = employeeLookup;
        _employeeCommands = employeeCommands;
    }

    [HttpDelete("/employees/{id:bsonid}")]
    public async Task<ActionResult> RemoveEmployee(string id)
    {
        await _employeeCommands.FireAsync(id);
        return NoContent(); // "Fine"
    }

    [HttpPost("/employees")]
    public async Task<ActionResult<EmployeeDocumentResponse>> HireEmployeeAsync([FromBody] EmployeeCreateRequest request)
    {

       
        EmployeeDocumentResponse response = await _employeeCommands.CreateEmployeeAsync(request);
       
        return CreatedAtRoute("employee#getemployeebyid", new
        {
            id = response.Id
        }, response);
    }

    [HttpGet("/employees")]
    public async Task<ActionResult<CollectionResponse<EmployeeSummaryResponse>>> GetEmployeesCollectionAsync()
    {

        List<EmployeeSummaryResponse> data = await  _employeeLookup.GetAllEmployeeSummariesAsync();

        var response = new CollectionResponse<EmployeeSummaryResponse> { Data = data };
        return Ok(response);
    }

    [HttpGet("/employees/{id:bsonid}", Name ="employee#getemployeebyid")]
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
