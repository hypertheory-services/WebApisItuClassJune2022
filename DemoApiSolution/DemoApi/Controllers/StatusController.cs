
namespace DemoApi.Controllers;

public class StatusController : ControllerBase
{

    private readonly StatusLookup _statusLookup;

    public StatusController(StatusLookup statusLookup)
    {
        _statusLookup = statusLookup;
    }




    // GET /status
    [HttpGet("/status")]
    public async Task<ActionResult<StatusResponse>> GetStatus()
    {
        //var response = new StatusResponse
        //{
        //    CreatedAt = DateTime.Now,
        //    Message = "Awesome. Party on Wayne"
        //};
        // "Write the Code you Wish You Had" (WTCYWYH)
        StatusResponse response = await _statusLookup.GetCurrentStatusAsync();
        return Ok(response); // reponse with 200 Ok status code.
    }

    [HttpGet("/status/oncalldeveloper")]
    public async Task<ActionResult<DeveloperInfo>> GetOnCallDeveloper()
    {
        var response = new DeveloperInfo { Name = "Bob Smith", Email = "Bob@aol.com" };
        return Ok(response);
    }
}


