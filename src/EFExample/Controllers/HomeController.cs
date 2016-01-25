using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EFExample.Models;
using Microsoft.Data.Entity;

namespace EFExample.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<IActionResult> Index(long[] schoolIDs)
        {

            var results = from x in db.Students
                          select x;


            if (schoolIDs != null && schoolIDs.Length > 0)
            {
                results = from x in results
                          where schoolIDs.Contains(x.Teacher.SchoolID)
                          select x;

            }

            return View(await results.ToListAsync());
        }

        public  IActionResult RunQuery(long[] schoolIDs)
        {

            var results = from x in db.Students
                          select x;


            if (schoolIDs != null && schoolIDs.Length > 0)
            {
                results = from x in results
                          where schoolIDs.Contains(x.Teacher.SchoolID)
                          select x;

            }

            return View(results.ToList());
        }



        public async Task<IActionResult> SeedDB()
        {
            int numberOfSchools = 3;
            int numberOfTeachersPerSchool = 4;
            int numberOfStudentsPerTeacher = 10;

            for (int i = 0; i < numberOfSchools; i++)
            {
                School school = new School() { Name = "School " + (i + 1).ToString() };

                for (int j = 0; j < numberOfTeachersPerSchool; j++)
                {
                    Teacher teacher = new Teacher() { Name = "Teacher " + (j + 1).ToString() + " from " + school.Name };


                    for (int k = 0; k < numberOfStudentsPerTeacher; k++)
                    {
                        Student student = new Student() { Name = "Student " + (k + 1).ToString() + " of " + teacher.Name };
                        teacher.Students.Add(student);

                    }

                    school.Teachers.Add(teacher);
                }

                db.Schools.Add(school);

            }
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
