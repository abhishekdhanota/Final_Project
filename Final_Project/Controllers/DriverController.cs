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


namespace Final_Project.Controllers
{
    public class DriverController : Controller
    {
        private JavaScriptSerializer jss = new JavaScriptSerializer();
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
        public ActionResult New()
        {
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(Driver driver)
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/driverdata/adddriver";
            String jsonpayload = jss.Serialize(driver);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            return RedirectToAction("List");
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
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/driverdata/finddriver/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            DriverDto selecteddriver = response.Content.ReadAsAsync<DriverDto>().Result;
            return View(selecteddriver);
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Driver driver)
        {

            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/driverdata/deletedriver/" + id;
            String jsonpayload = jss.Serialize(driver);
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");


        }
    }
}
