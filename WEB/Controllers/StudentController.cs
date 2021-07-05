using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WEB.DTOs.Student;
using WEB.Helpers;
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

        #region Index()
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _studentService.GetList();

                return View(list);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region Create()
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var model = new StudentCreateDto();
                model.Groups = await _groupService.GetOptions();

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
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
                ErrorLog.Log(ex);
                throw ex;
            }
        }
        #endregion

        #region Edit()
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _studentService.GetByIdForFrom(id);
                model.Groups = await _groupService.GetOptions();

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
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
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region Delete()
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                await _studentService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region Import()
        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(FileDto form)
        {
            try
            {
                if (form.File.Length > 20971520) // ~20mb
                {
                    ModelState.AddModelError("File", "Plik jest za duży (maksymalnie 20mb)");
                }

                if (form.File.ContentType != "text/csv" &&
                    form.File.ContentType != "application/vnd.ms-excel")
                {
                    ModelState.AddModelError("File", "Podany plik ma być z rozszerzeniem CSV");
                }

                if (ModelState.IsValid)
                {
                    var list = FileHelper.ReadCsvFile(form.File);
                    await _studentService.CreateRange(list);
                }

                return View(form);
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region Export()
        [HttpGet]
        public async Task<IActionResult> Export()
        {
            try
            {

                var list = await _studentService.GetList();

                var path = FileHelper.CreateCsvListFromFile(list);

                var bytes = await System.IO.File.ReadAllBytesAsync(path);

                return File(bytes, "text/csv", "Students.csv");
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region DownloadFile()
        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Example.csv");

                if (System.IO.File.Exists(path))
                {
                    var bytes = await System.IO.File.ReadAllBytesAsync(path);

                    return File(bytes, "text/csv", "Example.csv");
                }

                throw new FileNotFoundException("Nie znaleziono pliku");
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        } 
        #endregion
    }
}
