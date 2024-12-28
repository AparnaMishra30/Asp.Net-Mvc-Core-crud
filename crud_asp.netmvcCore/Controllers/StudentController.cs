using System;
using crud_asp.netmvcCore.Data;
using crud_asp.netmvcCore.Models;
using crud_asp.netmvcCore.Models.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_asp.netmvcCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext DbContext;
        public StudentController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudent viewmodel)
        {
            var Student = new Student
            {
                Name = viewmodel.Name,
                MobileNo = viewmodel.MobileNo,
                Email=viewmodel.Email
            };
            await DbContext.Students.AddAsync(Student);
            DbContext.SaveChanges();
            return RedirectToAction("List", "student");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var student= await DbContext.Students.ToListAsync();
          return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await DbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student  = await DbContext.Students.FindAsync(viewmodel.Id);
            if (student == null)
            {
                return View("Error");
            }
            else
            {
                student.Name = viewmodel.Name;
                student.MobileNo = viewmodel.MobileNo;
                student.Email = viewmodel.Email;
                
                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var student = await DbContext.Students.FindAsync(Id);
            DbContext.Students.Remove(student);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("List", "Student");
        }


        //public async Task<IActionResult> Delete(Student viewmodel)
        // {
        //     var student = await DbContext.Students.FindAsync(viewmodel.Id);
        //     if (student == null)
        //     {
        //         return View("Error");
        //     }
        //     else
        //     {
        //         DbContext.Students.Remove(viewmodel);
        //         await DbContext.SaveChangesAsync();
        //     }

        //     return RedirectToAction("List", "Student");

        // }
    }
}
