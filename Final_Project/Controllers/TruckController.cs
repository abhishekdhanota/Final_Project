using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Final_Project.Models;
using System.Web.Script.Serialization;
using Microsoft.SqlServer.Server;
using Final_Project.Migrations;

namespace Final_Project.Controllers
{
    public class TruckController : Controller
    {

        private JavaScriptSerializer jss = new JavaScriptSerializer();
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
        public ActionResult New()
        {
            return View();
        }

        // POST: Truck/Create
        [HttpPost]
        public ActionResult Create(Truck truck)
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/truckdata/addtruck";
            String jsonpayload = jss.Serialize(truck);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            return RedirectToAction("List");
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
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/truckdata/findtruck/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TruckDto selectedtruck = response.Content.ReadAsAsync<TruckDto>().Result;
            return View(selectedtruck);
        }

        // POST: Truck/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Truck truck)
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/truckdata/deletetruck/" + id;
            String jsonpayload = jss.Serialize(truck);
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");

        }
    }
}
