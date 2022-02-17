using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace rover.webui.Pages;

public class CardInfoModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Id { get; set; }

    public ModelCard[] card;

    private readonly ILogger<IndexModel> _logger;

    public CardInfoModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        card = new ModelCard[0];
    }

    public void OnGet()
    {
        card = QueryModelCards.GetCards(id: Id).Result;
    }
}