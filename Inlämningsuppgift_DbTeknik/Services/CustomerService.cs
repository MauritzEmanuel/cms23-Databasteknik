using Inlämningsuppgift_DbTeknik.Entities;
using Inlämningsuppgift_DbTeknik.Models;
using Inlämningsuppgift_DbTeknik.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Services
{
    internal class CustomerService
    {
        private readonly AddressRepo _addressRepo;
        private readonly CustomerRepo _customerRepo;

        public CustomerService(AddressRepo addressRepo, CustomerRepo customerRepo)
        {
            _addressRepo = addressRepo;
            _customerRepo = customerRepo;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            //Kontrollera kund
            if (!await _customerRepo.ExistsAsync(x => x.Email == customer.Email))
            {
                //Kontrollerar via adress
                AddressEntity addressEntity = await _addressRepo.GetAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode);
                if (addressEntity == null)
                    addressEntity = await _addressRepo.CreateAsync(new AddressEntity { StreetName = customer.StreetName, PostalCode = customer.PostalCode, City = customer.City });

                CustomerEntity customerEntity = await _customerRepo.CreateAsync(new CustomerEntity { FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, AddressId = addressEntity.Id });
                if (customerEntity != null)
                    return true;

            }

            return false;


        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            return customers;
        }
    }
}
