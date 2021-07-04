using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WEB.DTOs.Group;
using WEB.Services;

namespace WEB.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly ITeacherService _teacherService;

        public GroupController(
            IGroupService groupService,
            ITeacherService teacherService)
        {
            _groupService = groupService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _groupService.GetList();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new GroupCreateDto();
            model.Teachers = await _teacherService.GetOptions();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateDto form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _groupService.Create(form);

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
            var model = await _groupService.GetByIdForFrom(id);
            model.Teachers = await _teacherService.GetOptions();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GroupEditDto form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _groupService.Update(form);

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

            await _groupService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
