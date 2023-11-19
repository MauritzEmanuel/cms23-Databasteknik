﻿using System.Net.Http.Headers;

namespace Inlämningsuppgift_DbTeknik.Menus;

internal class MainMenu
{
    private readonly CustomerMenu _customerMenu;
    private readonly ProductMenu _productMenu;

    public MainMenu(CustomerMenu customerMenu, ProductMenu productMenu)
    {
        _customerMenu = customerMenu;
        _productMenu = productMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("-------------");

            Console.WriteLine("1. Manage Customers");
            Console.WriteLine("2. Manage Products");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _customerMenu.ManageCustomers();
                    break;
                case "2":
                    await _productMenu.ManageProducts();
                    break;
                default: 
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        while(true);

    }




}
