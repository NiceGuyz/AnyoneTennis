﻿using AnyoneTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyoneTennis.Controllers
{
    public class HomeController : Controller
    {

      /*  private readonly tennisContext _db;

        public HomeController(tennisContext db)
        {
            _db = db;
        } */
        
        public ActionResult Index()
        {
     //       var coach = _db.Coach.OrderByDescending(x => x.CoachId).Take(5).ToArray();
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}