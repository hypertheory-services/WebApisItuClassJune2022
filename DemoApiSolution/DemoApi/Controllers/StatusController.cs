using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

public class StatusController : ControllerBase
{
    // GET /status
    [HttpGet("/status")]
    public async Task<ActionResult<StatusResponse>> GetStatus()
    {
        var response = new StatusResponse { 
            CreatedAt = DateTime.Now, 
            Message = "Awesome. Party on Wayne", 
            OnCallDeveloper = new DeveloperInfo
            {
                Name = "Bob Smith",
                Email = "Bob@aol.com"
            }
        };
        return Ok(response); // reponse with 200 Ok status code.
    }
}


public class StatusResponse
{
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public DeveloperInfo OnCallDeveloper { get; set; } = new();

}

public class DeveloperInfo
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}