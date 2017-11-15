﻿using System;
using System.Linq;
using System.Web.Mvc;
using HelperMethods.Models;
using System.Collections.Generic;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData =
        {
            new Person{FirstName="Adam", LastName="Freeman", Role=Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Person> GetData(string selectedRole)
        {
            IEnumerable<Person> data = personData;
            if(selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role)), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            IEnumerable<Person> data = GetData(selectedRole);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            return PartialView(GetData(selectedRole));
        }

        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    IEnumerable<Person> data = personData;
        //    if(selectedRole != "All")
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        data = personData.Where(p => p.Role == selected);
        //    }
        //    return PartialView(data);
        //}

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

        //public ActionResult GetPeople()
        //{
        //    return View(personData);
        //}

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if(selectedRole == null || selectedRole == "All")
        //    {
        //        return View(personData);
        //    }
        //    else
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        return View(personData.Where(p => p.Role == selected));
        //    }
        //}
    }
}