using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Check01001.Controllers
{
    public class NVController : ApiController
    {
        [HttpGet]
        public List<NV> Layds()
        {
            NhanVienDataContext context = new NhanVienDataContext();
            List<NV> dsnv = context.NVs.ToList();
            return dsnv;
        }
        [HttpPost]
        public bool Them(string ma, string ten, string hs)
        {
            try
            {
                NhanVienDataContext context = new NhanVienDataContext();
                NV nv = new NV();
                nv.MaNV = ma;
                nv.TenNV = ten;
                nv.HSLuong = hs;
                context.NVs.InsertOnSubmit(nv);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }
        [HttpDelete]
        public bool Xoa(string ma)
        {
            NhanVienDataContext context = new NhanVienDataContext();
            NV nv = context.NVs.FirstOrDefault(x => x.MaNV == ma);
            if (nv != null)
            {
                context.NVs.DeleteOnSubmit(nv);
                context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
