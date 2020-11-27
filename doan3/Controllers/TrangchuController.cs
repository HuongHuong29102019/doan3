using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan3.Models;
using doan3.Models.Entities;
using doan3.Models.DataAccess;
using doan3.Bussiness;
using PagedList;
namespace doan3.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Trangchu
        caycanhBus db = new caycanhBus();
        public ActionResult trangchu(int? page = 1)
        {
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            List<caycanh> lsp = db.LaySPham();
            return View(lsp.ToPagedList(pnum, 8));//ds sp trên view
        }

        public ActionResult sanphambanchay(int so, string ngaythang, int? page = 1)
        {
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            caycanhModel db = new caycanhModel();
            List<caycanh> ds = db.LaySPBanChay(so, ngaythang).ToList();
            return PartialView(ds.ToPagedList(pnum, 8));
        }
    }
}