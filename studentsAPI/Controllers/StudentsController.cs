using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private static List<Student> Students = new List<Student>
    {
        new Student { Id = 1, Name = "John Doe", Age = 20, Department = "Computer Science" },
        new Student { Id = 2, Name = "Jane Smith", Age = 22, Department = "Mathematics" }
    };

    // GET: api/students
    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(Students);
    }

    // GET: api/students/{id}
    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        student.Id = Students.Count + 1;
        Students.Add(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/students/{id} (Update)
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student updatedStudent)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        student.Name = updatedStudent.Name;
        student.Age = updatedStudent.Age;
        student.Department = updatedStudent.Department;

        return NoContent(); // 204 No Content, indicating a successful update
    }

    // DELETE: api/students/{id} (Remove)
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        Students.Remove(student);

        return NoContent(); // 204 No Content, indicating successful deletion
    }
}
