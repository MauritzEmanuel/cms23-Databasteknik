using Inlämningsuppgift_DbTeknik.Models;
using Inlämningsuppgift_DbTeknik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Menus
{
    internal class ProductMenu
    {
        private readonly ProductService _productService;

        public ProductMenu(ProductService productService)
        {
            _productService = productService;
        }

        public async Task ManageProducts()
        {
            Console.Clear();
            Console.WriteLine("PRODUCTS MENU");
            Console.WriteLine("-------------");

            Console.WriteLine("1. Add product");
            Console.WriteLine("2. List all products");

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
            var product = new Products();

            Console.Clear();
            Console.WriteLine("Product name: ");
            product.ProductName = Console.ReadLine()!;

            Console.WriteLine("Description: ");
            product.ProductDescription = Console.ReadLine()!;

            Console.WriteLine("Category: ");
            product.ProductCategory = Console.ReadLine()!;

            Console.WriteLine("Price: ");
            product.ProductPrice = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine("Pricing unit: ");
            product.PricingUnit = Console.ReadLine()!;

            var result = await _productService.CreateProductAsync(product);
            if (result)
                Console.WriteLine("Product created.");
            else
                Console.WriteLine("Something went wrong");
        }

        public async Task ListAllAsync()
        {
            var products = await _productService.GetAllAsync();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductName} ({product.ProductCategory.CategoryName})");
                Console.WriteLine($"{product.ProductPrice} ({product.PricingUnit.Unit})");
            }

            Console.ReadKey();
        }
    }
}
