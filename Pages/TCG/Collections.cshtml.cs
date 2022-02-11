using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace rover.webui.Pages;

public class CollectionsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public CollectionsModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}