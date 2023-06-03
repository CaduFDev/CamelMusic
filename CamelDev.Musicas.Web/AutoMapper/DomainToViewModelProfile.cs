using AutoMapper;
using CamelDev.Musicas.Domain;
using CamelDev.Musicas.Web.ViewModels.Album;
using CamelDev.Musicas.Web.ViewModels.Musica;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CamelDev.Musicas.Web.AutoMapper
{
    public class DomainToViewModelProfile:Profile
    {
        public DomainToViewModelProfile()
        {
            //-----------------------Domain to view for "Album"
             CreateMap<Album, AlbumShowViewModel>().ForMember(p=>p.Title,opt =>
            {
                opt.MapFrom(src => string.Format("{0} ({1})", src.Title, src.Year.ToString()));
            });

            CreateMap<Album, AlbumViewModel>();

            //-----------------------Domain to view for "Musica"
            CreateMap<Musica, MusicShowViewModel>().ForMember(p=>p.NameAlbum, opt =>
            {
                opt.MapFrom(src => src.Album.Title);
            });
            
            CreateMap<Musica, MusicViewModel>();
            //-----------------------Domain to view for "other domain"
        }
    }
}