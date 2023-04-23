using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazingPizza.Client.Shared;
public partial class OrderReview
{
    [Parameter] public Order Order { get; set; }

}
