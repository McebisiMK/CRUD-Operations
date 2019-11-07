using System.Threading.Tasks;
using Lulalend.IRepositories;
using Lulalend.IServices;
using Lulalend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lulalend.Controllers
{
    public class LecturersController : Controller
    {
        private readonly ILecturersService _lecturersService;

        public LecturersController(ILecturersService lecturersRepository)
        {
            _lecturersService = lecturersRepository;;
        }

        public async Task<IActionResult> Index()
        {
            var lectures = await _lecturersService.GetAll();

            return View(lectures);
        }

        public async Task<IActionResult> Details(int id)
        {
            var lecturers = await _lecturersService.GetBy(id);

            return View(lecturers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Age,Salary")] Lecturers lecturer)
        {
            if (ModelState.IsValid)
            {
                await _lecturersService.Add(lecturer);
                return RedirectToAction(nameof(Index));
            }
            return View(lecturer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var lecturer = await _lecturersService.GetBy(id);

            if (lecturer == null)
                return NotFound();

            return View(lecturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Age,Salary")] Lecturers lecturer)
        {
            if (ModelState.IsValid)
            {
                await _lecturersService.Update(id);
                return RedirectToAction(nameof(Index));
            }
            return View(lecturer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lecturer = await _lecturersService.GetBy(id);

            if (lecturer == null)
                return NotFound();

            return View(lecturer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _lecturersService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}