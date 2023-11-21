using Inlämningsuppgift_DbTeknik.Contexts;
using Inlämningsuppgift_DbTeknik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Repositories
{
        internal class ProductRepo : Repo<ProductEntity>
        {
            private readonly DataContext _context;

            public ProductRepo(DataContext context) : base(context)
            {
                _context = context;
            }


        }
}


