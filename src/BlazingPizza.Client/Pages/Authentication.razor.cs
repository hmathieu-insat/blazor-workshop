using Microsoft.AspNetCore.Components;

namespace BlazingPizza.Client.Pages;

public partial class Authentication
{
    [Parameter]
    public string Action { get; set; }
}