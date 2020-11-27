using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan3.Models.Entities;
using doan3.Bussiness;
using PagedList;
namespace doan3.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult search(string tenSPTim, int? page = 1)
        {
            loaiBus db = new loaiBus();
            ViewBag.KeyWord = tenSPTim;
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            string xauTim = tenSPTim ?? "";
            //Lưu DL vào session
            List<caycanh> l = db.LaySanPhamTK(tenSPTim);
            return View(l.ToPagedList(pnum, 9));//số bản ghi được lấy là 1
        }
    }
}