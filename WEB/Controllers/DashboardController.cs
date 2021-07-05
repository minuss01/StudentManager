using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WEB.Models;
using WEB.Services;

namespace WEB.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IPersonalTaskService _personalTaskService;

        public DashboardController(IPersonalTaskService personalTaskService)
        {
            _personalTaskService = personalTaskService;
        }

        #region Index()
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _personalTaskService.GetList();

            return View(list);
        } 
        

        [HttpPost]
        public async Task<IActionResult> Create(string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                await _personalTaskService.Create(content);

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("Content", "Zadanie nie może być puste");

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete()
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _personalTaskService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        } 
        #endregion

        [HttpGet]
        public async Task<IActionResult> ChangeState(int id)
        {
            if (id > 0)
            {
                await _personalTaskService.ChangeState(id);
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
