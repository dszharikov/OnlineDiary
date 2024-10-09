using Microsoft.AspNetCore.Mvc;

namespace OnlineDiary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] Student student)
    {
        var result = await _studentService.CreateStudent(student);

        
        return Ok(result);
    }
}
