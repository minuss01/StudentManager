using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using WEB.DTOs.Group;
using WEB.Helpers;
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
            try
            {
                var list = await _groupService.GetList();
                return View(list);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var model = new GroupCreateDto();
                model.Teachers = await _teacherService.GetOptions();
                model.Teachers.Insert(0, new SelectListItem("", ""));

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
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
                ErrorLog.Log(ex);
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _groupService.GetByIdForFrom(id);
            model.Teachers = await _teacherService.GetOptions();
            model.Teachers.Insert(0, new SelectListItem("", ""));

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
                ErrorLog.Log(ex);
                throw ex;
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

                await _groupService.Delete(id);

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
