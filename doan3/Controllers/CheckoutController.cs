﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using doan3.Models.Entities;
using doan3.Models.DataAccess;
using doan3.Bussiness;
namespace doan3.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpPost]
        public JsonResult DatHang(string tenkh, string email, string diachinhan, string sdtnhan, int trangthai)
        {
            //lay thong tin cac mat hang dat tu session
            Khachhang kh = new Khachhang();
            kh.tenkh = tenkh;
            kh.email = email;
            kh.sdt = sdtnhan;
            kh.diachi = diachinhan;
            kh.email = email;
            kh.trangthai = trangthai;
            int thanhtien = 0;
            List<CTDHang> ds = new List<CTDHang>();
            int total = 0;
            if (Session["GioHang"] == null)
            {
                Session["GioHang"] = new List<CTDHang>();
                thanhtien = 0;
            }
            else
            {
                ds = Session["GioHang"] as List<CTDHang>;
                thanhtien = Convert.ToInt32(ds.Sum(s => s.DonGia * s.SoLuong));
            }
            ds = Session["GioHang"] as List<CTDHang>;
            caycanhModel a = new caycanhModel();
            List<caycanh> dsss = a.LaySPham();
            foreach (CTDHang ct in ds)
            {
                foreach (caycanh sp in dsss)
                {
                    if (sp.macaycanh == ct.MaSP)
                    {
                        a.SuaSLSP(ct.MaSP, ct.SoLuong);
                    }
                }
            }
            checkoutBus mhb = new checkoutBus();
            mhb.MuaHang(kh, thanhtien, ds, diachinhan, sdtnhan, trangthai);
            Session["GioHang"] = null;

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult checkout()
        {
            List<CTDHang> gh = null;
            int tongtien = 0;
            ViewBag.tongtien = "";
            int count = 0;
            if (Session["giohang"] != null)
            {
                gh = (List<CTDHang>)Session["giohang"];
                foreach (CTDHang a in gh)
                {
                    tongtien += a.SoLuong * a.DonGia;
                }
                count = gh.Count;
            }
            ViewBag.count = count;
            ViewBag.tongtien = tongtien;
            return View(gh);
        }
    }
}