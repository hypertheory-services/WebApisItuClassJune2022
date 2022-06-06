namespace DemoApi.Domain;

public class StatusLookup
{
    public async Task<StatusResponse> GetCurrentStatusAsync()
    {
        var response = new StatusResponse
        {
            CreatedAt = DateTime.Now,
            Message = "Awesome. Party on Wayne"
        };
        return response;
    }
}
