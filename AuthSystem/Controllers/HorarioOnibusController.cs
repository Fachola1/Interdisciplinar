using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Controllers
{
    public class HorarioOnibusController : Controller
    {
        private readonly AuthDbContext _onibuscontext;

        public HorarioOnibusController(AuthDbContext _context)
        {
            _onibuscontext = _context;

        }

        public async Task<IActionResult> Index()
        {
            var onibus = await _onibuscontext.HorarioOnibus
                .OrderBy(oni => oni.HorarioSaida)
                .ToListAsync();

            return View("~/Views/HorarioOnibus/HorarioDosOnibus.cshtml", onibus);
        }



    }
}