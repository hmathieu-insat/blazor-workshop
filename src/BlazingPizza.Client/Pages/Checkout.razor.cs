using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Checkout
{
    /// <summary>
    /// Places the order asynchronous.
    /// </summary>
    async Task PlaceOrderAsync()
    {
        var response = await Http.PostAsJsonAsync("orders", OrderState.Order);
        var newOrderId = await response.Content.ReadFromJsonAsync<int>();
        OrderState.ResetOrder();
        NavigationManager.NavigateTo($"/myorders/{newOrderId}");
    }
}