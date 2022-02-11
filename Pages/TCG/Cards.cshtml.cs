using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace rover.webui.Pages;

public class CardsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public CardsModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}