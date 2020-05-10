using Microsoft.AspNetCore.Mvc;
using WebApplication.DTOs.Requests;
using WebApplication.Services;


namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {

        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            _service.EnrollStudent(request);
            return Ok();
        }
    }
}