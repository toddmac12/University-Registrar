using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Registrar.Controllers
{
  public class DepartmentController : Controller
  {
    private readonly RegistrarContext _db;

    public DepartmentController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Department> model = _db.Department.ToList();
      return View(model);
    }

    // public ActionResult Create()
    // {
    //   ViewBag.DepartmentId = new SelectList(_db.Department, "DepartmentId", "Name");
    //   return View();
    // }

    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Department.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDepartment = _db.Department
          .Include(department => Department.JoinEntities)
          .ThenInclude(join => join.Student)
          .FirstOrDefault(Department => department.DepartmentId == id);
      return View(thisCourse);
    }
    public ActionResult Edit(int id)
    {
      Course thisDepartment = _db.Department.FirstOrDefault(Department => Department.DepartmentId == id);
      ViewBag.DepartmentId = new SelectList(_db.Department, "DepartmentId", "Name");///
      return View(thisDepartment);
    }
    [HttpPost]
    public ActionResult Edit(Department Department)
    {
      _db.Entry(Department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddStudent(int id)
    {
      Department thisDepartment = _db.Department.FirstOrDefault(Department => Department.DepartmentId == id);
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
      return View(thisDepartment);
    }
    [HttpPost]
    public ActionResult AddStudent(Department Department, int StudentId)
    {
      if (StudentId != 0)
      {
        List<Enrollment> model = _db.Enrollment.ToList();

        for (int i = 0; i < model.Count; i++)
        {
          if (model[i].DepartmentId == Department.DepartmentId && model[i].StudentId == StudentId)
          {
            return RedirectToAction("ErrorPage", "Students");
          }
        }
        _db.Enrollment.Add(new Enrollment() { DepartmentId = Department.DepartmentId, StudentId = StudentId });
        _db.SaveChanges();
      }

      return RedirectToAction("Details", new { id = Department.DepartmentId });
    }
    public ActionResult Delete(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(Department => Department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(Department => Department.DepartmentId == id);
      _db.Department.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}