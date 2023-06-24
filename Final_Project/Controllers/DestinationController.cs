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
    public class DestinationController : Controller
    {
        public ActionResult List()
        {
            HttpClient client = new HttpClient()
            {

            };
            string url = "https://localhost:44368/api/destinationdata/listdestinations";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<DestinationDto> destinations = response.Content.ReadAsAsync<IEnumerable<DestinationDto>>().Result;

            return View(destinations);
        }

        // GET: Destination/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Destination/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destination/Create
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

        // GET: Destination/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Destination/Edit/5
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

        // GET: Destination/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Destination/Delete/5
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
