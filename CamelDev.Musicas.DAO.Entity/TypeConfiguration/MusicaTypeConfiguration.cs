using CamelDev.Comum.Entity;
using CamelDev.Musicas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Musicas.DAO.Entity.TypeConfiguration
{
    public class MusicaTypeConfiguration : CamelDevWebEntityAbstractConfig<Musica>
    {
        protected override void ConfigFields()
        {
            Property(p => p.Id)
                .HasColumnName("ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Lyrics)
                .HasColumnName("LYRICS")
                .IsOptional();

            Property(p => p.IdAlbum)
                .HasColumnName("ALB_ID")
                .IsRequired();
        }

        protected override void ConfigForeignKey()
        {
            HasRequired(p => p.Album)
                .WithMany(p => p.Musicas)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        protected override void ConfigNameToTable()
        {
            ToTable("MUSIC");
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }
    }
}
