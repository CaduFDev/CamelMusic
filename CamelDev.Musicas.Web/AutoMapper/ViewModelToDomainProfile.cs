using AutoMapper;
using CamelDev.Musicas.Domain;
using CamelDev.Musicas.Web.ViewModels.Album;
using CamelDev.Musicas.Web.ViewModels.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamelDev.Musicas.Web.AutoMapper
{
    public class ViewModelToDomainProfile:Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<AlbumViewModel, Album>();
            CreateMap<MusicViewModel, Musica>();
        }
    }
}