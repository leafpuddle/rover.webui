using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace rover.webui.Pages;

public class CardsModel : PageModel
{
    public ModelCard[] commonCards;
    public ModelCard[] uncommonCards;
    public ModelCard[] rareCards;
    public ModelCard[] legendaryCards;
    public ModelCard[] mythicCards;

    private readonly ILogger<IndexModel> _logger;

    public CardsModel(ILogger<IndexModel> logger)
    {
        _logger = logger;

        commonCards = new ModelCard[0];
        uncommonCards = new ModelCard[0];
        rareCards = new ModelCard[0];
        legendaryCards = new ModelCard[0];
        mythicCards = new ModelCard[0];
    }

    public void OnGet()
    {
        commonCards = QueryModelCards.GetCards(rarity: 1).Result;
        uncommonCards = QueryModelCards.GetCards(rarity: 2).Result;
        rareCards = QueryModelCards.GetCards(rarity: 3).Result;
        legendaryCards = QueryModelCards.GetCards(rarity: 4).Result;
        mythicCards = QueryModelCards.GetCards(rarity: 5).Result;
    }
}