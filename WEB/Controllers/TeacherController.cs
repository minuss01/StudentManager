using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WEB.DTOs.Teacher;
using WEB.Helpers;
using WEB.Services;

namespace WEB.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _teacherService.GetList();

                return View(list);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        } 

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TeacherCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateDto form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _teacherService.Create(form);

                    return RedirectToAction(nameof(Index));
                }

                return View(form);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _teacherService.GetByIdForFrom(id);

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherEditDto form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _teacherService.Update(form);

                    return RedirectToAction(nameof(Index));
                }

                return View(form);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                await _teacherService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
    }
}
