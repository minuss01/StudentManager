using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WEB.DTOs.Student;
using WEB.Services;

namespace WEB.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;

        public StudentController(
            IStudentService studentService,
            IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _studentService.GetList();
            return View(list);
        }  

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new StudentCreateDto();
            model.Groups = await _groupService.GetOptions();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentService.Create(form);

                    return RedirectToAction(nameof(Index));
                }

                return View(form);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _studentService.GetByIdForFrom(id);
            model.Groups = await _groupService.GetOptions();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentEditDto form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentService.Update(form);

                    return RedirectToAction(nameof(Index));
                }

                return View(form);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _studentService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
