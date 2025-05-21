using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;

namespace App.ApplicationCore.Services
{
    public class ClientService : Service<Client>, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
       
        public double gettotalPaiement(Client client)
        {
            if (client?.Reservations == null)
                return 0;

            return client.Reservations
                .Where(r => r.Pack != null && r.Pack.Activites != null)
                .Sum(r => r.Pack.Activites.Sum(a => a.Prix));
        }

       
    }
    }
   
    
   