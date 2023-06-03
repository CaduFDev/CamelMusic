using CamelDev.Comum.Entity;
using CamelDev.Musicas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Musicas.DAO.Entity.TypeConfiguration
{
    internal class AlbumTypeConfiguration : CamelDevWebEntityAbstractConfig<Album>
    {
        protected override void ConfigFields()
        {
            Property(opt => opt.Id)
                .IsRequired()
                .HasColumnName("ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(opt => opt.Year)
                .HasColumnName("YEAR")
                .IsRequired();

            Property(opt => opt.Title)
                .IsRequired()
                .HasColumnName("TITLE");

            Property(opt => opt.Description)
                .IsOptional()
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(500);

            Property(opt => opt.Email)
                .HasColumnName("EMAIL")
                .IsOptional();                
        }

        protected override void ConfigForeignKey()
        {
            //HasMany(p => p.Musicas)
            //    .WithRequired(p => p.Album)
            //    .HasForeignKey(fk => fk.IdAlbum);
        }

        protected override void ConfigNameToTable()
        {
            ToTable("ALBUM");
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }
    }
}
