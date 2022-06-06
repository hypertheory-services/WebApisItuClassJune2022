
namespace DemoApi.Controllers;

public class StatusController : ControllerBase
{
    // GET /status
    [HttpGet("/status")]
    public async Task<ActionResult<StatusResponse>> GetStatus()
    {
        var response = new StatusResponse
        {
            CreatedAt = DateTime.Now,
            Message = "Awesome. Party on Wayne"
        };
        return Ok(response); // reponse with 200 Ok status code.
    }

    [HttpGet("/status/oncalldeveloper")]
    public async Task<ActionResult<DeveloperInfo>> GetOnCallDeveloper()
    {
        var response = new DeveloperInfo { Name = "Bob Smith", Email = "Bob@aol.com" };
        return Ok(response);
    }
}


