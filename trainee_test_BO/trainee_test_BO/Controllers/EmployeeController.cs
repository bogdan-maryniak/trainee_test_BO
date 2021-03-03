using Domain.Abstractions.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainee_test_BO.API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var employees = await repository.GetAll();
            return View(employees);           
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var employee = await repository.GetById(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var employee = await repository.GetById(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            return await Task.Run<ActionResult>(async () =>
            {
                if (!ModelState.IsValid)
                    return View(employee);

                await repository.Update(employee);

                return RedirectToAction(nameof(Index));
            });
        }
     

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
