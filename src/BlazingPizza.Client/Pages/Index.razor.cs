using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Index
{
    private List<PizzaSpecial> _specials;
    private Pizza _configuringPizza;
    private bool _showingConfigureDialog;
    private Order order = new Order();

    private void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        _configuringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        _showingConfigureDialog = true;
    }

    protected async override Task OnInitializedAsync() => 
        _specials = await HttpClient.GetFromJsonAsync("specials", BlazingPizza.OrderContext.Default.ListPizzaSpecial);

    private void CancelConfigurePizzaDialog()
    {
        _configuringPizza = null;
        _showingConfigureDialog = false;
    }

    private void ConfirmConfigurePizzaDialog()
    {
        order.Pizzas.Add(_configuringPizza);
        _configuringPizza = null;

        _showingConfigureDialog = false;
    }
}
