using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanHangTTCS.Models;

namespace BanHangTTCS.Controllers
{
    public class SanPhamController : Controller
    {
        BanHangEntities db = new BanHangEntities();
        // GET: SanPham
        [ChildActionOnly]
        public ActionResult SanPhamPartial()
        {
            return PartialView();
        }
        // detail product
        public ActionResult XemChiTiet(int? id, string tenbidanh)
        {
            // phan quyen co dc xem hay k
            //if(Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id && n.DaXoa == false);
            if (sp == null)
            {
                return HttpNotFound();
            }

            return View(sp);
        }
        // product list
        public ActionResult SanPham(int? MaLoaiSP, int? MaNSX)
        {
            //load theo 2 tieu chi
            if (MaLoaiSP == null || MaNSX == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var listSP = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP && n.MaNSX == MaNSX);
            if( listSP.Count() == 0)
            {
                return HttpNotFound();
            }
            

            return View(listSP);
        }
    }
}