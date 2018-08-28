using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        MULTICHOICEEntities db = new MULTICHOICEEntities();
        // GET: Home
        public ActionResult Index()
        {
            dynamic myModel = new ExpandoObject();
            myModel.lst_cauhoi = db.CAUHOIs.ToList<CAUHOI>();
            myModel.lst_traloi = db.CAUTRALOIs.ToList<CAUTRALOI>();
            return View(myModel);
        }

        [HttpPost]
        public ActionResult Check(FormCollection fc)
        {
            int num_right = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            initialDic(fc, dic);
            num_right = howmanyright(num_right, dic);
            ViewBag.num_right = num_right;
            return View();
        }

        private int howmanyright(int num_right, Dictionary<int, int> dic)
        {
            foreach (KeyValuePair<int, int> entry in dic)
            {
                if (db.CAUHOIs.Where(cauhoi => cauhoi.ID == entry.Key).First().ID_CAUTRL == entry.Value)
                    num_right += 1;
            }

            return num_right;
        }

        private void initialDic(FormCollection fc, Dictionary<int,int> dic)
        {
            for (int i = 1; i <= db.CAUHOIs.Count(); i++)
            {
                int key = i;
                int value = int.Parse(fc["cauhoi" + i.ToString()]);
                dic.Add(key, value);
            }
        }
    }
}