using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHangTTCS.Models;

namespace BanHangTTCS.Controllers
{
    public class GioHangController : Controller
    {
        BanHangEntities db = new BanHangEntities();
        // lay gio hang
        public List<ItemGioHang> GetCart()
        {
            //gio hang da ton tai
            List<ItemGioHang> listGH = Session["GioHang"] as List<ItemGioHang>;
            if(listGH == null)
            {
                //neu session gio hang chua ton tai thi tao list gio hang
                List<ItemGioHang> listGHN = new List<ItemGioHang>();
                Session["GioHang"] = listGHN;
                return listGHN;
            }
            return listGH;
        }
        
        // them gio hang thong thuong (load lai trang)
        public ActionResult AddCart(int MaSP, string strURL)
        {
            //kiem tra san pham co ton tai hay k
            SanPham sp = db.SanPhams.SingleOrDefault(n=>n.MaSP == MaSP);
            if(sp == null)
            {
                // 
                Response.StatusCode = 404;
                return null;
            }
            // lay gio hang
            List<ItemGioHang> listGH = GetCart();
            // neu sp da ton tai trong gio hang
            ItemGioHang spCheck = listGH.SingleOrDefault(n => n.MaSP == MaSP);
            if(spCheck != null)
            {
                if (sp.SoluongTon < spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }
            ItemGioHang itemGH = new ItemGioHang(MaSP);
            if (sp.SoluongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            listGH.Add(itemGH);
            return Redirect(strURL);
        }

        public double TinhTongSoLuong()
        {
            // lay gio hang
            List<ItemGioHang> listGH = Session["GioHang"] as List<ItemGioHang>;
            if (listGH == null)
            {
                return 0;
            }
            return listGH.Sum(n => n.SoLuong);
        }
        //tinh tong tien
        public decimal TinhTongTien()
        {
            // lay gio hang
            List<ItemGioHang> listGH = Session["GioHang"] as List<ItemGioHang>;
            if (listGH == null)
            {
                return 0;
            }
            return listGH.Sum(n => n.ThanhTien);
        }

        public ActionResult GioHangPartial()
        {
            if(TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }
        // GET: GioHang
        public ActionResult XemGioHang()
        {
            ViewBag.TongSoLuong = TinhTongSoLuong();
            List<ItemGioHang> listGH = GetCart();
            return View(listGH); 
        }
        [HttpGet]
        // sua gio hang
        public ActionResult SuaGioHang(int MaSP)
        {
            // kiem tra session gio hang da ton tai chua
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // kiem tra san pham ton tai trong csdl hay k
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if(sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // lay gio hang tu session
            List<ItemGioHang> listGH = GetCart();
            //kiem tra san pham co ton tai trong gio hang k
            ItemGioHang spCheck = listGH.SingleOrDefault(n => n.MaSP == MaSP);
            if(spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //laay list gio hang tao giao dien
            ViewBag.GioHang = listGH;
            return View(spCheck);
        }

        [HttpPost]
        public ActionResult CapNhatGioHang(ItemGioHang itemGH)
        {
            //kiem tra so luong ton
            SanPham spCheck = db.SanPhams.SingleOrDefault(n => n.MaSP == itemGH.MaSP);
            if (spCheck.SoluongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            //thay doi cap nhat so luong trong session gio hang
            List<ItemGioHang> listGH = GetCart();
            ItemGioHang itemGHU = listGH.Find(n => n.MaSP == itemGH.MaSP);
            itemGHU.SoLuong = itemGH.SoLuong;

            return RedirectToAction("SuaGioHang");
            //return View();

        }


    }
}