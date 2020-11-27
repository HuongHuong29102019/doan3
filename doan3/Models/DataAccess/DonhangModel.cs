using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan3.Models.Entities;
using System.Data;
namespace doan3.Models.DataAccess
{
    public class DonhangModel
    {
        DBContext db = new DBContext();
        public void ThemDonHang(Donhang dh)
        {
            string st = "insert into DONHANG values('" + dh.madonhang + "','" + dh.ngaytao + "','" + dh.thanhtien + "',N'" + dh.diachigh + "','" + dh.sdtgh + "',N'" + dh.makh + "','" + dh.trangthai + "')";
            db.ExcuteNonQuery(st);
        }
        public string LayDonHangCungNgay(string ngay)
        {
            string se = "Select top 1 madonhang from DONHANG where madonhang like '" + ngay + "%' order by madonhang";
            DataTable dt = db.FillDataTable(se);
            if (dt.Rows.Count <= 0)
                return "";
            else
                return Convert.ToString(dt.Rows[0][0]);
        }
    }
}