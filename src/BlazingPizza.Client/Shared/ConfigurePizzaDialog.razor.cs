using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazingPizza.Client.Shared;

public partial class ConfigurePizzaDialog
{
    private List<Topping> _toppings = new();

    [Parameter] public required Pizza Pizza { get; set; }

    [Parameter] public bool Show { get; set; }

    [Parameter] public EventCallback OnCancel { get; set; }

    [Parameter] public EventCallback OnConfirm { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _toppings = await Http.GetFromJsonAsync<List<Topping>>("toppings") ?? new();
    }

    private void ToppingSelected(ChangeEventArgs e)
    {
        if (_toppings is null)
            return;

        if (int.TryParse((string)e.Value!, out var index) && index >= 0)
        {
            var topping = _toppings[index];
            if (topping is null)
                return;

            AddTopping(topping);
        }
    }

    private void AddTopping(Topping topping)
    {
        if (Pizza is null)
            return;

        if (!Pizza.Toppings.Exists(pt => pt.Topping == topping))
            Pizza.Toppings.Add(new PizzaTopping { Topping = topping });
    }

    private void RemoveTopping(Topping topping)
        => Pizza.Toppings.RemoveAll(pt => pt.Topping == topping);
}