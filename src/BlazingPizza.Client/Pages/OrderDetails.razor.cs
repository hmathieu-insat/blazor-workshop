using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace BlazingPizza.Client.Pages;
public partial class OrderDetails
{
    [Parameter] public int OrderId { get; set; }

    OrderWithStatus? _orderWithStatus;
    bool _isOrderInvalid = false;
    CancellationTokenSource? _pollingCancellationToken;

    protected override async Task OnParametersSetAsync()
    {
        _pollingCancellationToken?.Cancel();

        await PollForUpdatesAsync();
    }

    private async Task PollForUpdatesAsync()
    {
        _pollingCancellationToken = new CancellationTokenSource();
        while (!_pollingCancellationToken.IsCancellationRequested)
        {
            try
            {
                _isOrderInvalid = false;
                _orderWithStatus = await Http.GetFromJsonAsync<OrderWithStatus>($"orders/{OrderId}");
                StateHasChanged();
            }
            catch (Exception ex)
            {
                _isOrderInvalid = true;
                _pollingCancellationToken.Cancel();
                Logger.LogError(ex, "Exception trying to update order");
                throw;
            }
        }
    }
}
