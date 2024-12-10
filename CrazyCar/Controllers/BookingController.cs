using CrazyCar.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyCar.Controllers
{
    public class BookingController : Controller
    {
        // Index stranica koja prikazuje formu
        public ActionResult Index()
        {
            return View(); // Vraća view za unos podataka
        }

        // Akcija koja obrađuje unos rezervacije
        [HttpPost]
        public ActionResult Index(Booking booking)
        {
            string errorMessage;

            // Validacija rezervacije
            if (booking.ValidateBooking(out errorMessage))
            {
                // Ako je rezervacija validna, prikaži poruku o uspehu
                ViewBag.SuccessMessage = "Rezervacija je uspešno kreirana!";
            }
            else
            {
                // Ako nije validna, prikaži grešku
                ViewBag.ErrorMessage = errorMessage;
            }

            // Vraća istu stranicu sa porukom
            return View(booking);
        }
    }
}
