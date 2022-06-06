using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

public class StatusController : ControllerBase
{
    // GET /status
    [HttpGet("/status")]
    public async Task<ActionResult<StatusResponse>> GetStatus()
    {
        var response = new StatusResponse { CreatedAt = DateTime.Now, Message = "Awesome. Party on Wayne" };
        return Ok(response); // reponse with 200 Ok status code.
    }
}


public class StatusResponse
{
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

}