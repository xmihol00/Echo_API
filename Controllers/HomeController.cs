using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using echo_API.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http.Features;
using System.Text;

namespace echo_API.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private string _data { get; set; } = string.Empty;
    private string _mime { get; set; } = string.Empty;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        HttpContext.Request.EnableBuffering();
        using (StreamReader stream = new StreamReader(Request.Body))
        {
            _data = stream.ReadToEndAsync().Result;
        }

        base.OnActionExecuting(context);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Route("/EchoJson")]
    public IActionResult EchoJson()
    {
        return new FileStreamResult(new MemoryStream(Encoding.UTF8.GetBytes(_data)), "application/json");
    }
    
    [Route("/EchoXml")]
    public IActionResult EchoXml()
    {
        return new FileStreamResult(new MemoryStream(Encoding.UTF8.GetBytes(_data)), "text/xml");
    }

    [Route("/EchoHeaders")]
    public IActionResult EchoHeaders()
    {
        _data = "{";
        foreach (var header in HttpContext.Request.Headers.SkipLast(1))
        {
            _data += '"' + header.Key + '"' + ':' + '"' + header.Value + '"' + ',';
        }
        _data += '"' + HttpContext.Request.Headers.Last().Key + '"' + ':' + '"' + HttpContext.Request.Headers.Last().Value + '"' + '}';
        Response.Headers.Authorization = "";
        return new FileStreamResult(new MemoryStream(Encoding.UTF8.GetBytes(_data)), "application/json");
    }
}
