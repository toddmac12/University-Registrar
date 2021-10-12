using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public ActionResult Index(string searchString)
    {
      List<Department> model = _db.Department.ToList();
      if (!String.IsNullOrEmpty(searchString))
      {
        model = _db.Department.Where(s => s.Name.Contains(searchString)).ToList();
      }
      return View(model);
    }
      public ActionResult Create()
    {
      return View();
    }

[HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Department.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Department thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }
    public ActionResult Delete(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      _db.Department.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Department.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department)
    {
      _db.Entry(department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}