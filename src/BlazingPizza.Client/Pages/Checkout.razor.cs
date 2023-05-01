using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class Checkout
{
    private bool _isSubmitting = false;

    /// <summary>
    /// Places the order asynchronous.
    /// </summary>
    async Task PlaceOrderAsync()
    {
        _isSubmitting = true;
        try
        {
            var response = await Http.PostAsJsonAsync("orders", OrderState.Order);
            var newOrderId = await response.Content.ReadFromJsonAsync<int>();
            OrderState.ResetOrder();
            NavigationManager.NavigateTo($"/myorders/{newOrderId}");
        }
        finally
        {
            _isSubmitting = false;
        }
    }
}