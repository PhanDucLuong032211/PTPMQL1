using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore; 
using DemoMVC.Data;
using DemoMVC.Models.Process;
using System.Data;
using System.Xml;
using OfficeOpenXml;
namespace DemoMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    // Rename file when upload to server
                    var fileName = DateTime.Now.ToShortTimeString().Replace(":", "") + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        // Save file to server
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);

                        // Duyệt từng dòng trong DataTable
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            // Tạo đối tượng Person mới
                            var ps = new Student();

                            // Gán giá trị từ Excel vào các thuộc tính
                            ps.PersonID = dt.Rows[i][0].ToString();
                            ps.FullName = dt.Rows[i][1].ToString();
                            ps.Address = dt.Rows[i][2].ToString();


                            // Thêm đối tượng vào context
                            _context.Add(ps);
                        }

                        // Lưu các thay đổi vào database
                        await _context.SaveChangesAsync();

                        // Chuyển hướng về Index
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return View();
        }
        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {

            AutoID autoGenerateId = new AutoID();
            //1. Lay ra ban ghi moi nhat cua Student
            var student = _context.Student.OrderByDescending(s => s.PersonID).FirstOrDefault();
            //2. Neu student == null thi gan StudentID = ST0
            var studentID = student == null ? "ST000" : student.PersonID;
            var newStudentID = autoGenerateId.GenerateId(studentID);
            var newStudent = new Student
            {
                PersonID = newStudentID,
                FullName = string.Empty
            };
            return View(newStudent);
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FullName,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,FullName,Address")] Student student)
        {
            if (id != student.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.PersonID == id);
        }
             public IActionResult Download()
    {
        // Cấu hình license để tránh lỗi
      

        var fileName = "DanhSachNguoiDung_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

        using (ExcelPackage excelPackage = new ExcelPackage())
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

            // Header
            worksheet.Cells["A1"].Value = "PersonID";
            worksheet.Cells["B1"].Value = "FullName";
            worksheet.Cells["C1"].Value = "Address";
            // Lấy dữ liệu từ database
            var personList = _context.Student.ToList();

            // Đổ dữ liệu vào từ hàng 2
            worksheet.Cells["A2"].LoadFromCollection(personList, false);

            // Xuất ra stream
            var stream = new MemoryStream(excelPackage.GetAsByteArray());

            // Trả về file excel
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }}
    }
}