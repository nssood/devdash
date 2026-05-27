using Microsoft.AspNetCore.Mvc;
 
namespace DevDash.Api.Controllers;
 
[ApiController]
[Route("api/github")]
public class GithubController : ControllerBase
{
    private readonly HttpClient _http;
 
    public GithubController(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("github");
    }
 
    [HttpGet("{username}")]
    public async Task<IActionResult> GetUser(string username)
    {
        var response = await _http.GetAsync($"users/{username}");
        if (!response.IsSuccessStatusCode) return NotFound();
        var json = await response.Content.ReadAsStringAsync();
        return Content(json, "application/json");
    }
}
