using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using doan3.Models.Entities;
namespace doan3.Models.DataAccess
{
    public class caycanhModel
    {
        DataContext db = new DataContext();
        DBContext db1 = new DBContext();
        DataTable dt = new DataTable();
        public List<caycanh> LaySanPhamTheoLoai(string maloai)
        {
            DataTable dt = db.getData("select *from CAYCANH where( maloai='" + maloai + "')");
            List<caycanh> sp = new List<caycanh>();
            foreach (DataRow r in dt.Rows)
            {
                caycanh p = new caycanh();
                p.macaycanh = Convert.ToString(r[0]);
                p.tencaycanh = Convert.ToString(r[1]);
                p.hinhanh = Convert.ToString(r[2]);
                p.maloai = Convert.ToString(r[3]);
                p.gia = int.Parse(Convert.ToString(r[4]));
                p.cachchamsoc = Convert.ToString(r[6]);
                p.chieucao = Convert.ToString(r[7]);
                p.ynghia = Convert.ToString(r[8]);
                sp.Add(p);
            }
            return sp;
        }
        public caycanh LaySanPhamMa(string ma)
        {
            DataTable dt = db.getData("Select * from CAYCANH where manhan='" + ma + "'");
            caycanh sp = new caycanh();
            if (dt.Rows.Count > 0)
            {
                sp.macaycanh = Convert.ToString(dt.Rows[0][0]);
                sp.tencaycanh = Convert.ToString(dt.Rows[0][1]);
                sp.hinhanh = Convert.ToString(dt.Rows[0][2]);
                sp.maloai = Convert.ToString(dt.Rows[0][3]);
                sp.gia = int.Parse(Convert.ToString(dt.Rows[0][4]));
                sp.cachchamsoc = Convert.ToString(dt.Rows[0][6]);
                sp.chieucao = Convert.ToString(dt.Rows[0][7]);
                sp.ynghia = Convert.ToString(dt.Rows[0][7]);
            }
            else sp = null;
            return sp;
        }

        public List<caycanh> LaySPham()
        {
            DataTable dt = db.getData("select * from CAYCANH");//lấy tt từ bảng sp
            List<caycanh> l = new List<caycanh>();
            foreach (DataRow r in dt.Rows)//duyệt qua các đtg dòng của datarow
            {
                caycanh sp = new caycanh();
                sp.macaycanh = Convert.ToString(r[0]);
                sp.tencaycanh = Convert.ToString(r[1]);
                sp.hinhanh = Convert.ToString(r[2]);
                sp.maloai = Convert.ToString(r[3]);
                sp.gia = int.Parse(Convert.ToString(r[4]));
                sp.cachchamsoc = Convert.ToString(r[6]);
                sp.chieucao = Convert.ToString(r[7]);
                sp.ynghia = Convert.ToString(r[8]);
                l.Add(sp);

            }
            return l;
        }
     
        public List<caycanh> LaySPBanChay(int so, string ngaythang)
        {
            DataTable dt = db.StoreReader("LaySPBanChay", so, ngaythang);
            List<caycanh> sp = new List<caycanh>();
            foreach (DataRow r in dt.Rows)
            {
                caycanh p = new caycanh();
                p.macaycanh = Convert.ToString(r[0]);
                p.tencaycanh = Convert.ToString(r[1]);
                p.hinhanh = Convert.ToString(r[2]);
                p.maloai = Convert.ToString(r[3]);
                p.gia = int.Parse(Convert.ToString(r[4]));
                p.cachchamsoc = Convert.ToString(r[6]);
                p.chieucao = Convert.ToString(r[7]);
                p.ynghia = Convert.ToString(r[8]);
                sp.Add(p);
            }
            return sp;
        }
        public bool SuaSLSP(string masp, int sl)
        {
            try
            {
                string st = "Update CAYCANH set soluong = soluong - " + sl + " where macaycanh = '" + masp + "'";
                return db1.ExcuteNonQuery(st);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}