using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace BlazingPizza.Client.Pages;
public partial class MyOrders
{
    IEnumerable<OrderWithStatus>? _ordersWithStatus;

    protected override async Task OnParametersSetAsync()
    {
        _ordersWithStatus = await Http.GetFromJsonAsync<List<OrderWithStatus>>("orders");
    }
}
