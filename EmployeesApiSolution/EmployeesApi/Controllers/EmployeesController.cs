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

    [HttpPost("/employees")]
    public async Task<ActionResult<EmployeeDocumentResponse>> HireEmployeeAsync([FromBody] EmployeeCreateRequest request)
    {

        // 2. Ask a service to save it or whatever.
        EmployeeDocumentResponse response = await _employeeCommands.CreateEmployeeAsync(request);
        // 3. Response (default)
        //   -- Return a 201 Status Code
        //   -- Consider putting a Location header on the response with the URL of the new resource.
        //                 Location: http://localhost:1339/employees/398398398938
        //   -- Be nice and send them a copy of that resource they would get if they followed that location url.
        //   -- Add a cache header to the response, and that cache header will be for the Location
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
