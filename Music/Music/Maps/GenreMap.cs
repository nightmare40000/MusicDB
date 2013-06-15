using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Music.Maps
{
    class GenreMap : ClassMap<GenreInfo>
    {
        public GenreMap()
        {
            Table("Genres");

            Id(x => x.ID, "GenreID").GeneratedBy.Native();

            Map(x => x.Name, "GenreName");
        }    
    }
}
