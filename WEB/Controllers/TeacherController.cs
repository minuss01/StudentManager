using Microsoft.AspNetCore.Mvc;
using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB.DTOs;
using WEB.DTOs.Teacher;
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
            var list = await _teacherService.GetList();

            return View(list);
        } 

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TeacherCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateDto form)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.Create(form);

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _teacherService.GetByIdForFrom(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherEditDto form)
        {
            if (ModelState.IsValid)
            {
                await _teacherService.Update(form);

                return RedirectToAction(nameof(Index));
            }

            return View(form);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _teacherService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
