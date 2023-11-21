using Inlämningsuppgift_DbTeknik.Contexts;
using Inlämningsuppgift_DbTeknik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_DbTeknik.Repositories
{
    internal class PricingUnitRepo : Repo<PricingUnitEntity>
    {
        public PricingUnitRepo(DataContext context) : base(context)
        {
        }
    }
}
