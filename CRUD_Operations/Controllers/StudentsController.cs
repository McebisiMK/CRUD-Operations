using System.Threading.Tasks;
using Lulalend.IRepositories;
using Lulalend.IServices;
using Lulalend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lulalend.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsRepository)
        {
            _studentsService = studentsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentsService.GetAll();

            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            var students = await _studentsService.GetBy(id);

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Age")] Students student)
        {
            if (ModelState.IsValid)
            {
                await _studentsService.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentsService.GetBy(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Age")] Students student)
        {
            if (ModelState.IsValid)
            {
                await _studentsService.Update(id);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentsService.GetBy(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}