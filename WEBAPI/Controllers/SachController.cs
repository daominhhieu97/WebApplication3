using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WEBAPI.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        public ActionResult Index()
        {
            List<WEBAPI.Models.DTO.Sach> list_sach = new List<Models.DTO.Sach>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:22586/api/");
                var responseTask = client.GetAsync("Sach");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<WEBAPI.Models.DTO.Sach>>();
                    readTask.Wait();
                    list_sach = readTask.Result;
                }
            }
                return View(list_sach);
        }
    }
}