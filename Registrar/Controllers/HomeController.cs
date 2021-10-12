using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registrar.Controllers


{
    public class HomeController : Controller
    {
private readonly RegistrarContext _db;
public HomeController(RegistrarContext db)
{
_db = db;
}
  [HttpGet("/")]
    public ActionResult Index()
    {
      List<Student> studentModel = _db.Students.ToList();
      List<Course> courseList = _db.Courses.ToList();
      ViewBag.courseModel = courseList;
      return View(studentModel);
    }

  }
}