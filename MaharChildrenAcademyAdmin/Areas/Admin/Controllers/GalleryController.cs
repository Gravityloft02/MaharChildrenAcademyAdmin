using MaharChildrenAcademyAdmin.Interfaces;
using MaharChildrenAcademyAdmin.Models;
using MaharChildrenAcademyAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MaharChildrenAcademyAdmin.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
         IAdmin _admin;

        public GalleryController()
        {
            _admin = new AdminService();
        }

        // GET: Admin/Gallery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            return View(new AlbumModel());
        }

        [HttpPost]
        public async Task<JsonResult> AddAlbum(AlbumModel album)
        {
            var imgList = new List<string>();
            foreach (var imgurl in album.Image)
            {
                foreach (var img in imgurl.Split(';'))
                {
                    if (!string.IsNullOrEmpty(img))
                    {
                        var i = img.Split(',');
                        if (i[1] != null)
                        {
                            imgList.Add(i[1]);
                        }
                    }
                }
            }

            album.Image = imgList;

            var res = await _admin.AddAlbum(album);
            return Json(res, JsonRequestBehavior.AllowGet);

        }
    }
}