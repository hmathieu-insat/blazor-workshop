using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Index
{
    private List<PizzaSpecial>? _specials;

    public Order Order => OrderState.Order;

    protected override async Task OnInitializedAsync() =>
        _specials = await HttpClient.GetFromJsonAsync("specials", BlazingPizza.OrderContext.Default.ListPizzaSpecial);
}