using Inlämningsuppgift_DbTeknik.Contexts;
using Inlämningsuppgift_DbTeknik.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Repositories
{
    internal class CustomerRepo : Repo<CustomerEntity>
    {
        private readonly DataContext _context;

        public CustomerRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.Include(x => x.Address).ToListAsync();
        }
    }
}
