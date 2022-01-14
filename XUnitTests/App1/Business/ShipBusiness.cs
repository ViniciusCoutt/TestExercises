using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Business
{
    public class ShipBusiness
    {
        public decimal ShipCalc(int distanceKm)
        {
            if (distanceKm <= 5)
                return 0.00m;

            else if (distanceKm > 5 && distanceKm < 15)
                return 10.00m;

            else
                return 30.00m;
        }
    }
}
