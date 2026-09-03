using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentRegistrationMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentController> _logger;

        // Static in-memory storage for practical/offline scenarios
        private static readonly List<Student> _inMemoryStudents = new();
        private static int _nextInMemoryId = 1001;

        public StudentController(ApplicationDbContext context, ILogger<StudentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /Student or /Student/Index
        // Displays the student registration form
        [HttpGet]
        public IActionResult Index()
        {
            PopulateDropdownOptions();
            return View("Create");
        }

        // GET: /Student/Create
        // Displays the student registration form
        [HttpGet]
        public IActionResult Create()
        {
            PopulateDropdownOptions();
            var student = new Student
            {
                Country = "India",
                RegistrationDate = DateTime.Now
            };
            return View(student);
        }

        // POST: /Student/Create
        // Validates and submits student data to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            // Conditional validation: If student is hosteller, HostelName is required
            if (student.IsHosteller && string.IsNullOrWhiteSpace(student.HostelName))
            {
                ModelState.AddModelError(nameof(student.HostelName), "Hostel Name is required when 'Is Hosteller' is checked.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Save to SQL Server Database via Entity Framework Core
                    student.RegistrationDate = DateTime.Now;
                    _context.Students.Add(student);
                    await _context.SaveChangesAsync();

                    // Also mirror to in-memory list for practical verification
                    _inMemoryStudents.Add(student);

                    _logger.LogInformation("Student successfully registered with ID {StudentId}", student.StudentId);

                    // Redirect to Success page with the new StudentId
                    return RedirectToAction(nameof(Success), new { id = student.StudentId });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error saving student to database. Falling back to in-memory store.");

                    // Fallback to in-memory list if database encountered an issue
                    student.StudentId = _nextInMemoryId++;
                    _inMemoryStudents.Add(student);

                    return RedirectToAction(nameof(Success), new { id = student.StudentId });
                }
            }

            // If validation failed, re-populate dropdowns and redisplay form
            PopulateDropdownOptions();
            return View(student);
        }

        // GET: /Student/Success/{id?}
        // Displays successful registration message and enrollment details
        [HttpGet]
        public async Task<IActionResult> Success(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Create));
            }

            // Find in database, or fallback to in-memory list
            Student? student = null;
            try
            {
                student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not fetch student from database; searching in-memory cache.");
            }

            student ??= _inMemoryStudents.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound("Registered student record could not be found.");
            }

            return View(student);
        }

        // GET: /Student/Details/{id}
        // Displays comprehensive student details in a clean Bootstrap card
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Student? student = null;
            try
            {
                student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not fetch student from database; searching in-memory cache.");
            }

            student ??= _inMemoryStudents.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound($"Student with ID #{id} was not found.");
            }

            return View(student);
        }

        // GET: /Student/List
        // Lists all registered students in the system
        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<Student> students;
            try
            {
                students = await _context.Students.OrderByDescending(s => s.StudentId).ToListAsync();
                if (students.Count == 0 && _inMemoryStudents.Count > 0)
                {
                    students = _inMemoryStudents.OrderByDescending(s => s.StudentId).ToList();
                }
            }
            catch
            {
                students = _inMemoryStudents.OrderByDescending(s => s.StudentId).ToList();
            }

            return View(students);
        }

        // Helper to populate select dropdowns
        private void PopulateDropdownOptions()
        {
            ViewBag.BloodGroups = new SelectList(new[]
            {
                "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
            });

            ViewBag.Courses = new SelectList(new[]
            {
                "BCA", "MCA", "B.Tech", "M.Tech", "BBA", "MBA", "B.Sc", "M.Sc"
            });

            ViewBag.Departments = new SelectList(new[]
            {
                "Computer Science",
                "Information Technology",
                "Electronics",
                "Mechanical",
                "Civil",
                "Management"
            });

            ViewBag.Semesters = new SelectList(new[]
            {
                "Semester 1", "Semester 2", "Semester 3", "Semester 4",
                "Semester 5", "Semester 6", "Semester 7", "Semester 8"
            });
        }
    }
}
