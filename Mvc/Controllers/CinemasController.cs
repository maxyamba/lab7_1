using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CinemasController : Controller
    {
        // GET: Cinemas
        public ActionResult Index()
        {
            IEnumerable<mvcCinemasModel> empList;
            HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Cinemas").Result;
            empList = responce.Content.ReadAsAsync<IEnumerable<mvcCinemasModel>>().Result;
            return View(empList);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcCinemasModel());
            else
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.GetAsync("Cinemas/" + id.ToString()).Result;
                return View(responce.Content.ReadAsAsync<mvcCinemasModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(mvcCinemasModel emp)
        {
            if (emp.id_cinema == 0)
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.PostAsJsonAsync("Cinemas", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage responce = GlobalVariables.WebApiClient.PutAsJsonAsync("Cinemas/" + emp.id_cinema, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage responce = GlobalVariables.WebApiClient.DeleteAsync("Cinemas/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}