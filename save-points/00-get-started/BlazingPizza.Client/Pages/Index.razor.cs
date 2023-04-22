using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Index
{
    private List<PizzaSpecial> specials;
    private Pizza configuringPizza;
    private bool showingConfigureDialog;
    private Order order = new Order();

    private void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        configuringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        showingConfigureDialog = true;
    }

    protected async override Task OnInitializedAsync()
    {
        specials = await HttpClient.GetFromJsonAsync<List<PizzaSpecial>>("specials", BlazingPizza.OrderContext.Default.ListPizzaSpecial);
    }


}
