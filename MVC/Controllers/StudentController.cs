using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return View(db.Tables.ToArray());
            }
            
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return View(db.Tables.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Table student)
        {
            try
            {
                // TODO: Add insert logic here
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    db.Tables.Add(student);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return View(db.Tables.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Table student)
        {
            try
            {
                // TODO: Add update logic here
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return View(db.Tables.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    Table student = db.Tables.Where(x => x.Id == id).FirstOrDefault();
                    db.Tables.Remove(student);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
