using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Index
{
    private List<PizzaSpecial>? _specials;
    private Pizza? _configuringPizza;
    private bool _showingConfigureDialog;
    private Order _order = new();

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
        if (_configuringPizza is not null)
        {
            _order.Pizzas.Add(_configuringPizza);
            _configuringPizza = null;
        }

        _showingConfigureDialog = false;
    }

    private void RemoveConfiguredPizza(Pizza pizza)
    {
        _order.Pizzas.Remove(pizza);
    }

    private async Task PlaceOrderAsync()
    {
        await HttpClient.PostAsJsonAsync("orders", _order);

        _order = new();
    }
}
