using Inlämningsuppgift_DbTeknik.Models;
using Inlämningsuppgift_DbTeknik.Services;

namespace Inlämningsuppgift_DbTeknik.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerSercice)
    {
        _customerService = customerSercice;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("CUSTOMER MENU");
        Console.WriteLine("-------------");

        Console.WriteLine("1. Add one customer");
        Console.WriteLine("1. List all customers");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await CreateAsync();
                break;
            case "2":
                await ListAllAsync();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    public async Task CreateAsync()
    {
        var customer = new Customer();

        Console.Clear();
        Console.WriteLine("First name: ");
        customer.FirstName = Console.ReadLine()!;

        Console.WriteLine("Last name: ");
        customer.LastName = Console.ReadLine()!;

        Console.WriteLine("Email: ");
        customer.Email = Console.ReadLine()!;

        Console.WriteLine("Streetname: ");
        customer.StreetName = Console.ReadLine()!;

        Console.WriteLine("Postalcode (xxx xx): ");
        customer.PostalCode = Console.ReadLine()!;

        Console.WriteLine("City: ");
        customer.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(customer);
        if (result)
            Console.WriteLine("Customer created.");
        else
            Console.WriteLine("Something went wrong");
    }

    public async Task ListAllAsync()
    {
        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            Console.WriteLine($"{customer.Address.StreetName} {customer.Address.PostalCode} {customer.Address.City}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }
}
