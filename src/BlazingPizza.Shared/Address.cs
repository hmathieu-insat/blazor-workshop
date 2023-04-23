namespace BlazingPizza;

public class Address
{
    public int Id { get; set; }

    [Required(ErrorMessage = "If you don't want to give your name go buy pizza from Anonymous hackers"), MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    public string Line1 { get; set; }

    [MaxLength(100)]
    public string Line2 { get; set; }

    [Required(ErrorMessage = "How the heck do you want to receive a pizza if you don't give me the address"), MaxLength(50)]
    public string City { get; set; }

    [Required(ErrorMessage = "The fuck are we supposed to guess the region you're in mate?"), MaxLength(20)]
    public string Region { get; set; }

    [Required, MaxLength(20)]
    public string PostalCode { get; set; }
}
