using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySQL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQL.Controllers
{
    public class HomeController : Controller
    {
        private BowlingContext context { get; set; }
        public HomeController(BowlingContext temp)
        {
            context = temp;
        }

        public IActionResult Index()
        {
            var x = context.Bowlers.ToList();
            return View(x);
        }

        [HttpGet]
        public IActionResult Edit(int bowl_id)
        {
            var temp = context.Bowlers.
                FirstOrDefault(x => x.BowlerID == bowl_id);
            return View(temp);
        }
        [HttpPost]
        public IActionResult Edit(Bowler temp)
        {
            context.Update(temp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int bowl_id)
        {
            var temp = context.Bowlers.Single(x => x.BowlerID == bowl_id);
            context.Remove(temp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var a = context.Bowlers.ToList();
            int temp_id = a.Last().BowlerID;
            temp_id++;
            Bowler temp = new Bowler();
            temp.BowlerID = temp_id;
            temp.TeamID = 1;
            context.Add(temp);
            context.SaveChanges();
            return View("Edit", temp);
        }
    }
}
