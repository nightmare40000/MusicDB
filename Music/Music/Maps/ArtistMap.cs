using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Music.Maps
{
    class ArtistMap : ClassMap<ArtistInfo>
    {
        public ArtistMap()
        {
            Table("Artists");

            Id(x => x.ID, "ArtistID").GeneratedBy.Native();

            Map(x => x.ArtistName, "ArtistName");
            
            HasManyToMany(x => x.Songs)
                .Table("ArtistSong")
                .ParentKeyColumn("ArtistID")
                .ChildKeyColumn("SongID")
                .Cascade.SaveUpdate();
        }
    }
}
