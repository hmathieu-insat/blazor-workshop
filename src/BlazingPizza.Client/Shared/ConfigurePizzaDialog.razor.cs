using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace BlazingPizza.Client.Shared;
public partial class ConfigurePizzaDialog
{
    [Parameter] public Pizza Pizza { get; set; }
    [Parameter] public bool Show { get; set; }
    [Parameter] public EventCallback OnCancel { get; set; }
    [Parameter] public EventCallback OnConfirm { get; set; }

    private List<Topping> _toppings = new();

    protected override async Task OnInitializedAsync()
    {
        _toppings = await Http.GetFromJsonAsync<List<Topping>>("toppings");
    }

    private void ToppingSelected(ChangeEventArgs e)
    {
        if (int.TryParse((string)e.Value, out var index) && index >= 0)
            AddTopping(_toppings.FirstOrDefault(tp => tp.Id == index));
    }

    private void AddTopping(Topping topping)
    {
        if (!Pizza.Toppings.Exists(pt => pt.Topping == topping))
            Pizza.Toppings.Add(new PizzaTopping { Topping = topping });
    }

    private void RemoveTopping(Topping topping) 
        => Pizza.Toppings.RemoveAll(pt => pt.Topping == topping);
}
