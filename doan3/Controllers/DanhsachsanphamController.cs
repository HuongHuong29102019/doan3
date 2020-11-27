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
    public class DanhsachsanphamController : Controller
    {
        // GET: Danhsachsanpham
        loaiBus db = new loaiBus();
        public ActionResult danhsachsanpham(string maloai, string tenloai, string tenSPTim, int? page = 1)
        {
            ViewBag.tenloai = tenloai;
            ViewBag.maloai = maloai;
            ViewBag.KeyWord = tenSPTim;
            int pnum = page ?? 1;//nếu ko có ??(null) thì mặc định là 1
            string xauTim = tenSPTim ?? "";
            //Lưu DL vào session
            List<caycanh> l;
            if (Session["SanPham" + maloai] == null)
            {
                //Lấy từ CSDL về
                l = db.LaySanPhamTheoLoai(maloai);//LaySanPhamTheoLoai: phương thức lấy trong Bussiness- DanhsachsanphamBus
                Session["SanPham" + maloai] = l;//Ném Dl vào session
            }
            else
            {
                //Lấy ở trong Session
                l = Session["SanPham" + maloai] as List<caycanh>;
            }
            ////bay loi
            //List<SanPhamtrangchu> l = db.LaySanPhamTheoLoai(maloai,gt);
            return View(l.FindAll(m => m.tencaycanh.ToLower().Contains(xauTim.ToLower())).ToPagedList(pnum, 9));//số bản ghi được lấy là 1
        }
    }
}