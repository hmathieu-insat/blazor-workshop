using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazingPizza.Client.Shared;
public partial class LoginDisplay
{
    Task BeginSignOut()
    {
        Navigation.NavigateToLogout("authentication/logout");
        return Task.CompletedTask;
    }
}
