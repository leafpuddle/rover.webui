using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace rover.webui.Pages;

public class TcgModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public TcgModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}