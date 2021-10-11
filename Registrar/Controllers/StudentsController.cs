using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly RegistrarContext _db;

    public StudentsController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student Student, int CourseId)
    {
      _db.Students.Add(Student);
      _db.SaveChanges();
      if (CourseId != 0)
      {
        _db.Enrollment.Add(new Enrollment() { CourseId = CourseId, StudentId = Student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisItem = _db.Students
          .Include(Student => Student.JoinEntities)
          .ThenInclude(join => join.Course)
          .FirstOrDefault(Student => Student.StudentId == id);
      return View(thisItem);
    }

    public ActionResult Edit(int id)
    {
      var thisItem = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Student Student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.Enrollment.Add(new Enrollment() { CourseId = CourseId, StudentId = Student.StudentId });
      }
      _db.Entry(Student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      var thisItem = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Categories, "CourseId", "Name");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult AddCourse(Student Student, int CourseId)
    {
      if (CourseId != 0)
      {
      _db.Enrollment.Add(new Enrollment() { CourseId = CourseId, StudentId = Student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisItem = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisItem = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
      _db.Students.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.Enrollment.FirstOrDefault(entry => entry.EnrollmentId == joinId);
      _db.Enrollment.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}