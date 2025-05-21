using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Web.Controllers
{
    public class ClientController : Controller
    {
        IUnitOfWork unitOfWork;
        IService<Client> ClientService;
        public ClientController(IUnitOfWork unitOfWork, IService<Client> ClientService)
        {
            this.unitOfWork = unitOfWork;
            this.ClientService = ClientService;
        }
        // GET: ClientController
        public ActionResult Index(string searchString)
        {
            var clients = ClientService.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(c => c.Login != null && c.Login.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return View(clients);
        }
        public ActionResult DetailsConseiller(int id)
        {
            // Récupérer le conseiller par son id
            var conseiller = unitOfWork.Repository<Conseiller>().GetById(id);
            if (conseiller == null)
                return NotFound();

            return View(conseiller);
        }
        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                ClientService.Add(client);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
