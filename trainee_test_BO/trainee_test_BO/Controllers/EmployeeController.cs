using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace trainee_test_BO.API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index()
        {
            var employees = await service.GetAll();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var employee = await service.GetById(id);
            return View(employee);
        }


        // POST: EmployeeController/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");
            if (file.FileName.EndsWith(".csv"))
            {
                var employees = CSVAdapter.GetFromCSV(file);
                await service.AddRange(employees);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var employee = await service.GetById(id);
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

                await service.Update(employee);

                return RedirectToAction(nameof(Index));
            });
        }


        // GET: EmployeeController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
