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
    public class TripController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static TripController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44368/api/");
        }
        // GET: Trip/List
        public ActionResult List()
        {
            // curl https://localhost:44368/api/trips/listtrips

            string url = "trips/listtrips";
            HttpResponseMessage response = client.GetAsync(url).Result;
            Debug.WriteLine("The response is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<TripDto> trips = response.Content.ReadAsAsync<IEnumerable<TripDto>>().Result;
            Debug.WriteLine("Number of trips ");
            Debug.WriteLine(trips.Count());
            return View(trips);
        }

        // GET: Trip/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            // curl https://localhost:44368/api/trips/findtrip/{id}

            string url = "trips/findtrip/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            Debug.WriteLine("The response is ");
            Debug.WriteLine(response.StatusCode);

            TripDto selectedtrip = response.Content.ReadAsAsync<TripDto>().Result;
            return View(selectedtrip);



        }

        // GET: Trip/New
        [Authorize]
        public ActionResult New()
        {
            string url = "driverdata/listdrivers";
            string url1 = "truckdata/listtrucks";
            string url2 = "destinationdata/listdestinations";
            HttpResponseMessage response = client.GetAsync(url).Result;
            HttpResponseMessage response1 = client.GetAsync(url1).Result;
            HttpResponseMessage response2 = client.GetAsync(url2).Result;


            IEnumerable<DriverDto> driversoptions = response.Content.ReadAsAsync<IEnumerable<DriverDto>>().Result;
            IEnumerable<TruckDto> truckoptions = response1.Content.ReadAsAsync<IEnumerable<TruckDto>>().Result;
            IEnumerable<DestinationDto> destinationoptions = response2.Content.ReadAsAsync<IEnumerable<DestinationDto>>().Result;


            Class1 class1 = new Class1();
            class1.driverdto = driversoptions.ToList();
            class1.truckdto= truckoptions.ToList();
            class1.destinationdto = destinationoptions.ToList();

            return View(class1);
        }

        // POST: Trip/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Trip trip)
        {
            string url = "trips/addtrip";
            String jsonpayload = jss.Serialize(trip);
            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            return RedirectToAction("List");


        }

        // GET: Trip/Edit/5
        [Authorize]
        public ActionResult Update(int id)
        {

            string url = "driverdata/listdrivers";
            string url1 = "truckdata/listtrucks";
            string url2 = "destinationdata/listdestinations";
            string url3 = "trips/findtrip/" + id;

            HttpResponseMessage response = client.GetAsync(url).Result;
            HttpResponseMessage response1 = client.GetAsync(url1).Result;
            HttpResponseMessage response2 = client.GetAsync(url2).Result;
            HttpResponseMessage response3 = client.GetAsync(url3).Result;



            IEnumerable<DriverDto> driversoptions = response.Content.ReadAsAsync<IEnumerable<DriverDto>>().Result;
            IEnumerable<TruckDto> truckoptions = response1.Content.ReadAsAsync<IEnumerable<TruckDto>>().Result;
            IEnumerable<DestinationDto> destinationoptions = response2.Content.ReadAsAsync<IEnumerable<DestinationDto>>().Result;
            TripDto tripoptions = response3.Content.ReadAsAsync<TripDto>().Result;



            Class1 class1 = new Class1();
            class1.driverdto = driversoptions.ToList();
            class1.truckdto = truckoptions.ToList();
            class1.destinationdto = destinationoptions.ToList();
            class1.tripdto=tripoptions;

            return View(class1);











        }

        // POST: Trip/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Update(int id, Trip trip)
        {
            trip.TripId = id;
            string url = "trips/UpdateTrip/" + id;
            string jsonpayload = jss.Serialize(trip);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            Debug.WriteLine(content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        // GET: Trip/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            string url = "trips/findtrip/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TripDto selectedtrip = response.Content.ReadAsAsync<TripDto>().Result;
            return View(selectedtrip);
        }

        // POST: Trip/Delete/5
        [Authorize]
        [HttpPost]

        public ActionResult Delete(int id, FormCollection collection)
        {
            string url = "trips/deletetrip/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");
        }

    }
}
