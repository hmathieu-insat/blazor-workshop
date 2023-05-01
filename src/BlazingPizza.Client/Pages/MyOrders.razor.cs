using System.Net.Http.Json;

namespace BlazingPizza.Client.Pages;

public partial class MyOrders
{
    private IEnumerable<OrderWithStatus>? _ordersWithStatus;

    protected override async Task OnParametersSetAsync()
    {
        _ordersWithStatus = await HttpClient.GetFromJsonAsync<List<OrderWithStatus>>("orders");
    }
}