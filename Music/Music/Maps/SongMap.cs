using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Music.Maps
{
    class SongMap : ClassMap<SongInfo>
    {
        public SongMap()
        {
            Table("Songs");

            Id(x=> x.ID, "SongID").GeneratedBy.Native();
            Map(x => x.Name, "SongName");
            Map(x => x.Duration, "Duration");
            Map(x => x.Album, "AlbumName");

            HasManyToMany(x => x.Genres)
                .Table("SongGenre")
                .ParentKeyColumn("SongID")
                .ChildKeyColumn("GenreID")
                .Cascade.SaveUpdate();
        }

    }
}
