using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Final_Project.Models;
namespace Final_Project.Controllers
{
    public class TruckController : Controller
    {
        // GET: Truck/list
        public ActionResult List()
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/truckdata/listtrucks";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<TruckDto> trucks = response.Content.ReadAsAsync<IEnumerable<TruckDto>>().Result;

            return View(trucks);
        }

        // GET: Truck/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/truckdata/findtruck/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            TruckDto selectedtruck = response.Content.ReadAsAsync<TruckDto>().Result;

            return View(selectedtruck);
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Truck/Create
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

        // GET: Truck/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Truck/Edit/5
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

        // GET: Truck/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Truck/Delete/5
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
