using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CamelDev.Musicas.DAO.Entity.Context;
using CamelDev.Musicas.Domain;
using CamelDev.Musicas.Web.AutoMapper;
using CamelDev.Musicas.Web.Filters;
using CamelDev.Musicas.Web.ViewModels.Album;
using CamelDev.Musics.Repositories.Entity;
using CamelDev.Repositories.Comum;
using Microsoft.Ajax.Utilities;

namespace CamelDev.Musicas.Web.Controllers
{
    [Authorize]
    public class AlbunsController : Controller
    {
        private IRepositoriesGenerics<Album, int> repositorieAlbuns = new AlbunsRepositories(new MusicasDbContext());

        private readonly IMapper _mapper;
        public AlbunsController()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelProfile>();
                cfg.AddProfile<ViewModelToDomainProfile>();
                //More profiels
            });

            _mapper = configuration.CreateMapper();
        }

        // GET: Albuns                
        public ActionResult Index()
        {
            return View(_mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorieAlbuns.Select()));
        }


        public ActionResult FilterForName(string search)
        {
           
            List<Album> albuns = repositorieAlbuns.Select().Where(p => p.Title.Contains(search)).ToList();
            List<AlbumShowViewModel> viewModels = _mapper.Map<List<Album>, List<AlbumShowViewModel>>(albuns);
            
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Albuns/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorieAlbuns.SelectForId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(_mapper.Map<Album, AlbumShowViewModel>(album));
        }

        // GET: Albuns/Create
        [Authorize (Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Year,Title,Description,Email")] AlbumViewModel albumVM)
        {
            if (ModelState.IsValid)
            {
                Album album = _mapper.Map<AlbumViewModel, Album>(albumVM);
                repositorieAlbuns.Inser(album);
                return RedirectToAction("Index");
            }

            return View(albumVM);
        }

        // GET: Albuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorieAlbuns.SelectForId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(_mapper.Map<Album, AlbumViewModel>(album));
        }

        // POST: Albuns/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Title,Description,Email")] AlbumViewModel albumVM)
        {
            if (ModelState.IsValid)
            {
                Album album = _mapper.Map<AlbumViewModel, Album>(albumVM);
                repositorieAlbuns.Update(album);
                return RedirectToAction("Index");
            }
            return View(albumVM);
        }

        // GET: Albuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorieAlbuns.SelectForId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(_mapper.Map<Album, AlbumShowViewModel>(album));
        }

        // POST: Albuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorieAlbuns.DeleteForId(id);
            return RedirectToAction("Index");
        }
    }
}
