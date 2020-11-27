using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan3.Models.Entities;
using doan3.Models.DataAccess;
namespace doan3.Bussiness
{
    public class chitietsanphamBus
    {
        caycanhModel db = new caycanhModel();
        public caycanh Laysp(string masp)
        {
            caycanh sp = db.LaySanPhamMa(masp);
            return sp;
        }
    }
}