using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver/list
        public ActionResult List()
        {
            HttpClient client = new HttpClient()
            {
               
            };
            string url = "https://localhost:44368/api/driverdata/listdrivers";
            HttpResponseMessage response =client.GetAsync(url).Result;

            IEnumerable<DriverDto> drivers = response.Content.ReadAsAsync<IEnumerable<DriverDto>>().Result;
            
            return View(drivers);
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/driverdata/finddriver/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            DriverDto selecteddriver = response.Content.ReadAsAsync<DriverDto>().Result;

            return View(selecteddriver);
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
