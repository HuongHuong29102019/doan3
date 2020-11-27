using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan3.Models.Entities;
using doan3.Models.DataAccess;
namespace doan3.Bussiness
{

    public class caycanhBus
    {
       caycanhModel spm = new caycanhModel();
        public List<caycanh> LaySPham()
        {
            List<caycanh> lsp = spm.LaySPham();
            return lsp;
        }
      
        public List<caycanh> LaySPBanChay(int so, string ngaythang)
        {
            List<caycanh> sp = spm.LaySPBanChay(so, ngaythang);
            return sp;
        }
    }
}