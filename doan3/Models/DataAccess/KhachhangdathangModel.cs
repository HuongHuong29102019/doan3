using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using doan3.Models.Entities;

namespace doan3.Models.DataAccess
{
    public class KhachhangdathangModel
    {
        DBContext db = new DBContext();
        public bool ThemKhach(Khachhang kh)
        {
            DataTable dt = db.FillDataTable("select*from KHACHHANG");
            string st = "insert into khachhang values('" + kh.makh + "',N'" + kh.tenkh + "','" + kh.email + "',N'" + kh.diachi + "','" + kh.sdt + "','" + kh.trangthai + "')";
            db.ExcuteNonQuery(st);
            return true;
        }
    }
}