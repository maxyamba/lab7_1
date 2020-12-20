using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            IEnumerable<mvcCountriesModel> empList;
            HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Countries").Result;
            empList = responce.Content.ReadAsAsync<IEnumerable<mvcCountriesModel>>().Result;
            return View(empList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if(id == 0)
                return View(new mvcCountriesModel());
            else
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Countries/"+id.ToString()).Result;
                return View(responce.Content.ReadAsAsync<mvcCountriesModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(mvcCountriesModel emp)
        {
            if (emp.id_country == 0)
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.PostAsJsonAsync("Countries", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.PutAsJsonAsync("Countries/"+emp.id_country, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage responce = GlobalVariables.WebApiClient.DeleteAsync("Countries/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}