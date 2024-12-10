using CrazyCar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CrazyCar.Controllers
{
    public class CarsController : Controller
    {
        // Akcija koja prikazuje početnu stranicu sa formom
        public IActionResult Index()
        {
            var cars = new List<Cars>
        {
            new Cars { ID = 1, Make = "Audi", Model = "A1 AllStreet", PricePerDay = 50, IsAvailable = true, Image = "a1allstreet.jpg"},
            new Cars { ID = 2, Make = "Audi", Model = "A3 Sportback", PricePerDay = 60, IsAvailable = false, Image = "a3 Sportback.jpg" },
            new Cars { ID = 3, Make = "Audi", Model = "A3 AllStreet", PricePerDay = 30, IsAvailable = false, Image = "a3allstreet.jpg" },
            new Cars { ID = 4, Make = "Audi", Model = "A3 Limuzina", PricePerDay = 40, IsAvailable = false, Image = "a3Limuzina.jpg" },
            new Cars { ID = 5, Make = "Audi", Model = "A4 AllRoadQuattro", PricePerDay = 70, IsAvailable = false, Image = "a4allroadquattro.jpg" },
            new Cars { ID = 6, Make = "Audi", Model = "A4 Avant", PricePerDay = 90, IsAvailable = false, Image = "a4avant.jpg" },
            new Cars { ID = 7, Make = "Audi", Model = "A4 Limuzina", PricePerDay = 100, IsAvailable = false, Image = "a4limuzina.jpg" },
        };
            return View(cars);
        }

        // Akcija koja prikazuje rezultate pretrage
        [HttpPost]
        public IActionResult SearchResult(string make, string model, decimal? minPrice, decimal? maxPrice)
        {
            // Kreiraj listu automobila (ili uzmite listu iz baze podataka)
            var cars = new List<Cars>
        {
            new Cars { ID = 1, Make = "Audi", Model = "A1 AllStreet", PricePerDay = 50, IsAvailable = true, Image = "a1allstreet.jpg"},
            new Cars { ID = 2, Make = "Audi", Model = "A3 Sportback", PricePerDay = 60, IsAvailable = false, Image = "a3 Sportback.jpg" },
            new Cars { ID = 3, Make = "Audi", Model = "A3 AllStreet", PricePerDay = 30, IsAvailable = false, Image = "a3allstreet.jpg" },
            new Cars { ID = 4, Make = "Audi", Model = "A3 Limuzina", PricePerDay = 40, IsAvailable = true, Image = "a3Limuzina.jpg" },
            new Cars { ID = 5, Make = "Audi", Model = "A4 AllRoadQuattro", PricePerDay = 70, IsAvailable = false, Image = "a4allroadquattro.jpg" },
            new Cars { ID = 6, Make = "Audi", Model = "A4 Avant", PricePerDay = 90, IsAvailable = true, Image = "a4avant.jpg" },
            new Cars { ID = 7, Make = "Audi", Model = "A4 Limuzina", PricePerDay = 100, IsAvailable = false, Image = "a4limuzina.jpg" },
        };

            // Filtriraj listu prema parametrima
            if (!string.IsNullOrEmpty(make))
            {
                cars = cars.Where(c => c.Make.Contains(make, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(c => c.Model.Contains(model, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (minPrice.HasValue)
            {
                cars = cars.Where(c => c.PricePerDay >= minPrice.Value).ToList();
            }
            if (maxPrice.HasValue)
            {
                cars = cars.Where(c => c.PricePerDay <= maxPrice.Value).ToList();
            }

            // Osigurajte da vraćate praznu listu umesto null
            return View(cars ?? new List<Cars>());
        }

    }
}
