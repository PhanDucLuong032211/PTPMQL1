using DemoMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class AutoIDController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoIDController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create([Bind("FullName,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.PersonID = await GenerateNextPersonID();
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
    
}