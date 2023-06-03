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
using CamelDev.Musicas.Web.ViewModels.Album;
using CamelDev.Musicas.Web.ViewModels.Musica;
using CamelDev.Musics.Repositories.Entity;
using CamelDev.Repositories.Comum;

namespace CamelDev.Musicas.Web.Controllers
{
    [Authorize]
    public class MusicasController : Controller
    {
        private IRepositoriesGenerics<Musica, long> repositorieMusic = new MusicRepositories(new MusicasDbContext());
        private IRepositoriesGenerics<Album, int> repositorieAlbum = new AlbunsRepositories(new MusicasDbContext());

        private readonly IMapper _mapper;
        public MusicasController()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelProfile>();
                cfg.AddProfile<ViewModelToDomainProfile>();
            });
            _mapper = configuration.CreateMapper();
        }
        // GET: Musicas
        public ActionResult Index()
        {
            return View(_mapper.Map<List<Musica>, List<MusicShowViewModel>>(repositorieMusic.Select()));
        }

        // GET: Musicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorieMusic.SelectForId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(_mapper.Map<Musica, MusicShowViewModel>(musica));
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            List<AlbumShowViewModel> album = _mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorieAlbum.Select());            
            ViewBag.IdAlbum = new SelectList(album, "Id", "Title");
            
            return View();
        }

        // POST: Musicas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Lyrics,IdAlbum")] MusicViewModel musicaVM)
        {
            if (ModelState.IsValid)
            {
                Musica music = _mapper.Map<MusicViewModel, Musica>(musicaVM);
                repositorieMusic.Inser(music);
                return RedirectToAction("Index");
            }

            List<AlbumShowViewModel> album = _mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorieAlbum.Select());
            ViewBag.IdAlbum = new SelectList(album, "Id", "Title", album);
            return View(musicaVM);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorieMusic.SelectForId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }

            List<AlbumShowViewModel> album = _mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorieAlbum.Select());

            ViewBag.IdAlbum = new SelectList(album, "Id", "Title", musica.IdAlbum);
            return View(_mapper.Map<Musica, MusicViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Lyrics,IdAlbum")] MusicViewModel musicaVM)
        {
            if (ModelState.IsValid)
            {
                Musica musica = _mapper.Map<MusicViewModel,Musica>(musicaVM);
                repositorieMusic.Update(musica);
                return RedirectToAction("Index");
            }

            List<AlbumShowViewModel> album = _mapper.Map<List<Album>, List<AlbumShowViewModel>>(repositorieAlbum.Select());

            ViewBag.IdAlbum = new SelectList(album, "Id", "Title", album);
            return View(musicaVM);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorieMusic.SelectForId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(_mapper.Map<Musica, MusicShowViewModel>(musica));
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorieMusic.DeleteForId(id);
            return RedirectToAction("Index");
        }
    }
}
