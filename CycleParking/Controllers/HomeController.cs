using CycleParking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CycleParking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService _dbService;
        public HomeController(IDbService dbService)
        {
            _dbService = dbService;
        }
        public ActionResult Index(string searchTerm)
        {
            List<CycleParkingService> cycleParkings;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                cycleParkings = _dbService.GetCycleParkings()
                    .Where(p => p.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                cycleParkings = _dbService.GetCycleParkings();
            }
            return View(cycleParkings);
        }

        public ActionResult Details(int id)
        {
            CycleParkingService cycleParkings = _dbService.GetCycleParkingDetails(id);
            var viewModel = cycleParkings;
            return View(viewModel);
        }

  
    }
}