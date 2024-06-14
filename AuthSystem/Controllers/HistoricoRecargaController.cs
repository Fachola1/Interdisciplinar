using Microsoft.AspNetCore.Mvc;
using AuthSystem.Models;
using AuthSystem.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AuthSystem.Areas.Identity.Data;

namespace AuthSystem.Controllers
{
    public class HistoricoRecargaController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HistoricoRecargaController(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var recargas = await _context.Recargas
                .Where(r => r.IdUsuario == user.Id)
                .OrderByDescending(r => r.DataRecarga)
                .ToListAsync();

            return View("~/Views/Home/HistoricoRecarga.cshtml", recargas);
        }
    }
}
