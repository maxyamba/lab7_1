using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace Mvc.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        public ActionResult Index()
        {
            IEnumerable<mvcCitiesModel> empList;
            HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Cities").Result;
            empList = responce.Content.ReadAsAsync<IEnumerable<mvcCitiesModel>>().Result;
            return View(empList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcCitiesModel());
            else
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Cities/" + id.ToString()).Result;
                return View(responce.Content.ReadAsAsync<mvcCitiesModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(mvcCitiesModel emp)
        {
            if (emp.id_city == 0)
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.PostAsJsonAsync("Cities", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.PutAsJsonAsync("Cities/" + emp.id_city, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage responce = GlobalVariables.WebApiClient.DeleteAsync("Cities/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}