using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;

namespace App.ApplicationCore.Services
{
    public class PackService : Service<Pack>, IPackService
    {
        public PackService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public double PourcentagePackLongueDuree(Pack pack)
        {
            var packs = UnitOfWork.Repository<Pack>().GetAll();
            if (packs == null || !packs.Any())
                return 0;

            int total = packs.Count();
            int longueDuree = packs.Count(p => p.Duree > 7);

            return (double)longueDuree / total * 100;
        }

        public double PrixTotalPack(Pack pack)
        {

            if (pack?.Activites == null)
                return 0;

            return pack.Activites.Sum(a => a.Prix);
        }
    }

}

