using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using doan3.Models.Entities;
using doan3.Models.DataAccess;

namespace doan3.Bussiness
{
    public class loaiBus
    {
        caycanhModel db = new caycanhModel();
        public List<caycanh> LaySanPhamTheoLoai(string maloai)
        {
            List<caycanh> sp = db.LaySanPhamTheoLoai(maloai);
            return sp;
        }
        public List<caycanh> LaySanPhamTK(string tk)
        {
            return db.LaySPham().Where(x => (x.tencaycanh.ToLower().Contains(tk.ToLower()))).ToList();
        }
    }
}