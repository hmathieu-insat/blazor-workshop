namespace BlazingPizza.Client;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }

    public Pizza? ConfiguringPizza { get; private set; }

    public Order Order { get; private set; } = new();

    /// <summary>
    /// Shows the configure pizza dialog.
    /// </summary>
    /// <param name="pizzaSpecial">The pizza special.</param>
    public void ShowConfigurePizzaDialog(PizzaSpecial pizzaSpecial)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = pizzaSpecial,
            SpecialId = pizzaSpecial.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };
        ShowingConfigureDialog = true;
    }

    /// <summary>
    /// Cancels the configure pizza dialog.
    /// </summary>
    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    /// <summary>Confirms the configure pizza dialog.</summary>
    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza is not null)
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;
        }
        ShowingConfigureDialog = false;
    }

    /// <summary>Removes the configured pizza.</summary>
    /// <param name="pizza">The pizza.</param>
    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }

    /// <summary>
    /// Resets the order.
    /// </summary>
    public void ResetOrder()
    {
        Order = new();
    }
}
