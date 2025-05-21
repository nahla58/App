using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;

namespace App.ApplicationCore.Interfaces
{
    public interface IPackService
    {
        public double PrixTotalPack(Pack pack);
        public double PourcentagePackLongueDuree(Pack pack);
    }
}
