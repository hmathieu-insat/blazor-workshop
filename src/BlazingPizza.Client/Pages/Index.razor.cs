using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Index
{
    private List<PizzaSpecial>? _specials;

    protected override async Task OnInitializedAsync() =>
        _specials = await HttpClient.GetFromJsonAsync("specials", BlazingPizza.OrderContext.Default.ListPizzaSpecial);

    private async Task PlaceOrderAsync()
    {
        var response = await HttpClient.PostAsJsonAsync("orders", OrderState.Order);
        var newOrderId = await response.Content.ReadFromJsonAsync<int>();
        OrderState.ResetOrder();

        NavigationManager.NavigateTo($"myorders/{newOrderId}");
    }
}