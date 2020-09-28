namespace VirtualMusicStore.WebApp.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using VirtualMusicStore.WebApp.Models;
    using VirtualMusicStore.WebApp.Service.Interface;
    public class VirtualMusicController : Controller
    {
        private IMusicService musicService;
        public VirtualMusicController(IMusicService service)
        {
            musicService = service;
        }
        // GET: VirtualMusic
        public ActionResult Index()
        {
            var list = musicService.GetAllMusicAlbum();
            var albumsList = list.Select(a => new AlbumVm
            {
                Id = a.Id,
                AlbumName = a.AlbumName,
                Artist = a.Artist,
                Label = a.Label,
                LabelType = (LabelTypeVm)a.LabelType,
                Stock = a.Stock
            }).ToList();

            return View(albumsList);
        }

        // GET: VirtualMusic/Details/5
        public ActionResult Details(int id)
        {
            var album = musicService.GetMusicAlbum(id);
            var albumvm = new AlbumVm
            {
                Id = album.Id,
                AlbumName = album.AlbumName,
                Label = album.Label,
                Artist = album.Artist,
                Stock = album.Stock,
                LabelType = (LabelTypeVm)album.LabelType
            };

            return View(albumvm);
        }

        // GET: VirtualMusic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VirtualMusic/Create
        [HttpPost]
        public ActionResult Create(AlbumVm albumVm)
        {
            musicService.AddMusicAlbum(albumVm);
            return RedirectToAction("Index");
        }

        // GET: VirtualMusic/Edit/5
        public ActionResult Edit(int id)
        {
            var albumVm = musicService.GetMusicAlbum(id);
            return View(albumVm);
        }

        // POST: VirtualMusic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AlbumVm albumVm)
        {
            musicService.UpdateMusicAlbum(albumVm);

            return RedirectToAction("Index");


        }

        // GET: VirtualMusic/Delete/5
        public ActionResult Delete(int id)
        {
            var albumvm = musicService.GetMusicAlbum(id);

            return View(albumvm);
        }

        // POST: VirtualMusic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AlbumVm albumVm)
        {
            try
            {
                // TODO: Add delete logic here
                var albumFlag = musicService.DeleteMusicAlbum(albumVm.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
