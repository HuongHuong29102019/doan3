using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan3.Models.Entities;
using doan3.Models.DataAccess;
using doan3.Bussiness;
namespace doan3.Controllers
{
    public class ChitietsanphamController : Controller
    {
        // GET: Chitietsanpham
        chitietsanphamBus db = new chitietsanphamBus();

        public ActionResult chitietsanpham(string masp, string maloai)
        {
            try
            {
                caycanh sp = db.Laysp(masp);
                return View(sp);
            }
            catch
            {
                return Content("lỗi rồi");
            }
        }
        //public ActionResult postimg(string masp)
        //{
        //    ImgModel ig = new ImgModel();
        //    List<Img> ds = ig.postimg().Where(x => x.masp == masp).Take(3).ToList();
        //    return PartialView(ds);
        //}
        //public ActionResult sprelative(string maloai)
        //{
        //    SanphamtrangchuModel db = new SanphamtrangchuModel();
        //    List<SanPhamtrangchu> ds = db.LaySPham().Where(x => x.maloai == maloai).Take(3).ToList();
        //    return PartialView(ds);
        //}
        //public ActionResult spother(string masp)
        //{
        //    spotherModel ig = new spotherModel();
        //    List<other> ds = ig.spother().Where(x => x.masp == masp).Take(3).ToList();
        //    return PartialView(ds);
        //}
    }
}