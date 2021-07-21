using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHangTTCS.Models;

namespace BanHangTTCS.Controllers
{
    public class HomeController : Controller
    {
        BanHangEntities db = new BanHangEntities();
        // GET: Home
        public ActionResult Index()
        {
            //tao viewbag

            // list ao moi nhat
            var listGiayMoi = db.SanPhams.Where(n => n.MaLoaiSP == 1 && n.Moi == 1);
            // gan vao viewbag
            ViewBag.listGiayMoi = listGiayMoi;
            // list ao moi nhat
            var listAoMoi = db.SanPhams.Where(n => n.MaLoaiSP == 2 && n.Moi == 1);
            // gan vao viewbag
            ViewBag.listAoMoi = listAoMoi;// list ao moi nhat
            var listTuiMoi = db.SanPhams.Where(n => n.MaLoaiSP == 3 && n.Moi == 1);
            // gan vao viewbag
            ViewBag.listTuiMoi = listTuiMoi;

            return View();
        }
        public ActionResult MenuPartial()
        {
            var listSP = db.SanPhams;
            return PartialView(listSP);
        }

        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangKy(ThanhVien tv)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ThongBao = "Thêm thành công";
                db.ThanhViens.Add(tv);
                db.SaveChanges();
            }
            else
            {
                ViewBag.ThongBao = "Thêm Thất Bại";
            }
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f, string notif)
        {
            string sTaiKhoan = f["txtTenDN"].ToString();
            string sMatKhau = f["txtPass"].ToString();

            ThanhVien tv = db.ThanhViens.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Fail = "Đăng Nhập Thất Bại";
                return View("viewDN");
            }

        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }


        public ActionResult viewDN()
        {
            return View();
        }

        // load cau hoi bi mat

    }
}