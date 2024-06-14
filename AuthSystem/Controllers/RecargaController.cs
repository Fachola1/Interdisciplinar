using Microsoft.AspNetCore.Mvc;
using AuthSystem.Models;
using AuthSystem.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using AuthSystem.Areas.Identity.Data;

namespace AuthSystem.Controllers
{
    public class RecargaController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecargaController(AuthDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Recarregar()
        {
            return View("~/Views/Home/Recarregar.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Enviar(RecargaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        model.IdUsuario = user.Id;
                        model.DataRecarga = DateTime.Now;
                        _context.Recargas.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ocorreu um erro ao processar a recarga: {ex.Message}");
            }

            return View("Recarregar", model);
        }

    }
}
