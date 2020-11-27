using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan3.Models.Entities;
using doan3.Models.DataAccess;
using System.Data;

namespace doan3.Models.DataAccess
{
    public class ChiTietDonHangModel
    {
        DBContext db = new DBContext();
        public void LuuDanhSachCTDH(List<CTDHang> ds)
        {
            List<caycanh> ds1 = new List<caycanh>();
            DataTable dt = new DataTable();
            dt.Columns.Add("madonhang");
            dt.Columns.Add("macaycanh");
            dt.Columns.Add("soluong");
            dt.Columns.Add("dongia");
            foreach (CTDHang item in ds)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.MaDHang;
                dr[1] = item.MaSP;
                dr[2] = item.SoLuong;
                dr[3] = item.DonGia;
                dt.Rows.Add(dr);
            }
            db.UpdateDataBase(dt, "CHITIETDONHANG");
        }
    }
}